using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class ucBanHang : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
        DataTable gioHang = new DataTable();
        public ucBanHang()
        {
            InitializeComponent();
        }
        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (DataRow row in gioHang.Rows)
            {
                tong += (decimal)row["ThanhTien"];
            }
            txtTongHoaDon.Text = tong.ToString("N0");
        }
        private void ucBanHang_Load(object sender, EventArgs e)
        {
            ucThemThongTinKhachHang1.OnKhachHangAdded += (id, ten) =>
            {
                txtTenKhachHang.Text = ten;   // hiển thị ra textbox
                currentKhachHangID = id;      // lưu ID để dùng khi lưu hóa đơn

                ucThemThongTinKhachHang1.Visible = false; // ẩn UC
            };
            dtpNgayLap.Value = DateTime.Now;

            // Thiết lập cấu trúc DataTable cho giỏ hàng
            if (gioHang.Columns.Count == 0)
            {
                gioHang.Columns.Add("SachID", typeof(int));
                gioHang.Columns.Add("TenSach", typeof(string));
                gioHang.Columns.Add("TheLoai", typeof(string));
                gioHang.Columns.Add("SoLuong", typeof(int));
                gioHang.Columns.Add("DonGia", typeof(decimal));
                gioHang.Columns.Add("ThanhTien", typeof(decimal));
            }

            dgvGioHang.DataSource = gioHang;

            ucThongTinChiTietHoaDon1.OnThemSach += (id, ten, loai, sl, gia) =>
            {
                ThemSach(ten, loai, sl, gia);
                CapNhatTongTien();
            };
        }
        private void ThemSachHandler(int id, string ten, string loai, int sl, decimal gia)
        {
            ThemSach(ten, loai, sl, gia);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSachVaHoaDon_click(object sender, EventArgs e)
        {
            ucThongTinChiTietHoaDon1.Visible = true;

            
            ucThongTinChiTietHoaDon1.BringToFront();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            ucThemThongTinKhachHang1.Visible = true;
            ucThemThongTinKhachHang1.BringToFront();
        }

        private void ucThemKhachHang1_Load(object sender, EventArgs e)
        {

        }

        private void ucThongTinChiTietHoaDon1_Load(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (gioHang.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sách!");
                return;
            }

            if (currentKhachHangID == 0)
            {
                MessageBox.Show("Chưa chọn khách hàng!");
                return;
            }

            decimal tienKhachTra;
            if (!decimal.TryParse(txtTienDaNhan.Text, out tienKhachTra))
            {
                MessageBox.Show("Tiền khách trả không hợp lệ!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    //  Tạo mã hóa đơn
                    string maHoaDon = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");

                    //  1. Lưu hóa đơn
                    string queryHD = @"INSERT INTO HoaDon(MaHoaDon, KhachHangID, NgayLap)
                               OUTPUT INSERTED.ID
                               VALUES (@MaHD, @KHID, GETDATE())";

                    SqlCommand cmdHD = new SqlCommand(queryHD, conn, tran);
                    cmdHD.Parameters.AddWithValue("@MaHD", maHoaDon);
                    cmdHD.Parameters.AddWithValue("@KHID", currentKhachHangID);

                    int hoaDonID = (int)cmdHD.ExecuteScalar();

                    // 2. Lưu chi tiết hóa đơn
                    foreach (DataRow row in gioHang.Rows)
                    {
                        SqlCommand cmdCT = new SqlCommand(
                            @"INSERT INTO ChiTietHoaDon(HoaDonID, SachID, SoLuong, DonGia)
                            VALUES (@HDID, @SachID, @SL, @Gia)", conn, tran);

                        cmdCT.Parameters.AddWithValue("@HDID", hoaDonID);
                        cmdCT.Parameters.AddWithValue("@SachID", row["SachID"]);
                        cmdCT.Parameters.AddWithValue("@SL", row["SoLuong"]);
                        cmdCT.Parameters.AddWithValue("@Gia", row["DonGia"]);

                        cmdCT.ExecuteNonQuery();

                        SqlCommand checkSL = new SqlCommand(
                        "SELECT SoLuong FROM Sach WHERE ID = @SachID", conn, tran);
                        checkSL.Parameters.AddWithValue("@SachID", row["SachID"]);

                        int tonKho = (int)checkSL.ExecuteScalar();
                        int soLuongBan = Convert.ToInt32(row["SoLuong"]);

                        if (tonKho < soLuongBan)
                        {
                            throw new Exception("Sách không đủ số lượng!");
                        }

                        // TRỪ SỐ LƯỢNG SÁCH
                        SqlCommand cmdUpdateSach = new SqlCommand(
                            @"UPDATE Sach
                            SET SoLuong = SoLuong - @SL
                            WHERE ID = @SachID", conn, tran);

                        cmdUpdateSach.Parameters.AddWithValue("@SL", row["SoLuong"]);
                        cmdUpdateSach.Parameters.AddWithValue("@SachID", row["SachID"]);

                        cmdUpdateSach.ExecuteNonQuery();
                    }

                    // 3. Tính tổng tiền (an toàn)
                    decimal tongTien = gioHang.AsEnumerable()
                        .Sum(r => Convert.ToDecimal(r["ThanhTien"]));

                    // 4. Tính phát sinh công nợ
                    decimal phatSinh = tongTien - tienKhachTra;

                    // làm tròn tránh lỗi số lẻ
                    phatSinh = Math.Round(phatSinh, 0);

                    // nếu = 0 thì không xử lý công nợ
                    if (phatSinh != 0)
                    {
                        string check = @"SELECT ID, NoCuoi 
                     FROM BaoCaoCongNo
                     WHERE Thang = @Thang 
                       AND Nam = @Nam 
                       AND KhachHangID = @KHID";

                        SqlCommand cmdCheck = new SqlCommand(check, conn, tran);
                        cmdCheck.Parameters.AddWithValue("@Thang", DateTime.Now.Month);
                        cmdCheck.Parameters.AddWithValue("@Nam", DateTime.Now.Year);
                        cmdCheck.Parameters.AddWithValue("@KHID", currentKhachHangID);

                        int? id = null;
                        decimal noCuoiCu = 0;

                        using (SqlDataReader reader = cmdCheck.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = (int)reader["ID"];
                                noCuoiCu = Convert.ToDecimal(reader["NoCuoi"]);
                            }
                        }

                        if (id.HasValue)
                        {
                            // 🔥 CẬP NHẬT
                            decimal noMoi = noCuoiCu + phatSinh;

                            SqlCommand cmdUpdate = new SqlCommand(
                                @"UPDATE BaoCaoCongNo
                                  SET PhatSinh = PhatSinh + @PhatSinh,
                                      NoCuoi = @NoMoi
                                  WHERE ID = @ID", conn, tran);

                            cmdUpdate.Parameters.AddWithValue("@PhatSinh", phatSinh);
                            cmdUpdate.Parameters.AddWithValue("@NoMoi", noMoi);
                            cmdUpdate.Parameters.AddWithValue("@ID", id.Value);

                            cmdUpdate.ExecuteNonQuery();
                        }
                        else
                        {
                            // 🔥 THÊM MỚI
                            decimal noDau = 0;
                            
                            // 🔍 Lấy nợ cuối tháng trước
                            string getNoDauQuery = @"
                                SELECT TOP 1 NoCuoi 
                                FROM BaoCaoCongNo
                                WHERE KhachHangID = @KHID
                                ORDER BY Nam DESC, Thang DESC";

                            SqlCommand cmdNoDau = new SqlCommand(getNoDauQuery, conn, tran);
                            cmdNoDau.Parameters.AddWithValue("@KHID", currentKhachHangID);

                            object result = cmdNoDau.ExecuteScalar();
                            if (result != null)
                            {
                                noDau = Convert.ToDecimal(result);
                            }

                            // Tính nợ mới
                            decimal noCuoi = noDau + phatSinh;

                            // INSERT đúng chuẩn
                            SqlCommand cmdInsert = new SqlCommand(
                                @"INSERT INTO BaoCaoCongNo
                                  (Thang, Nam, KhachHangID, NoDau, PhatSinh, NoCuoi)
                                  VALUES (@Thang, @Nam, @KHID, @NoDau, @PhatSinh, @NoCuoi)", conn, tran);

                            cmdInsert.Parameters.AddWithValue("@Thang", DateTime.Now.Month);
                            cmdInsert.Parameters.AddWithValue("@Nam", DateTime.Now.Year);
                            cmdInsert.Parameters.AddWithValue("@KHID", currentKhachHangID);
                            cmdInsert.Parameters.AddWithValue("@NoDau", noDau);
                            cmdInsert.Parameters.AddWithValue("@PhatSinh", phatSinh);
                            cmdInsert.Parameters.AddWithValue("@NoCuoi", noCuoi);

                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                    // ✅ 5. Commit
                    tran.Commit();

                    MessageBox.Show("Thanh toán thành công!");

                    // 🔥 Reset
                    gioHang.Clear();
                    txtTienDaNhan.Text = "";
                    txtTenKhachHang.Text = "";
                    currentKhachHangID = 0;
                    txtTongHoaDon.Text = "0";
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnLichSuBanHang_Click(object sender, EventArgs e)
        {
            var frm = (frmBaoCaoThang_BaoCaoTon)this.FindForm();
            frm.HienThiUserControl(new ucLichSuBanHang());
        }

        private void ucThemThongTinKhachHang1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private int currentKhachHangID; // lưu lại ID

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        public void ThemSach(string tenSach, string theLoai, int soLuong, decimal donGia)
        {
            foreach (DataRow row in gioHang.Rows)
            {
                // 🔍 so sánh theo tên
                if (row["TenSach"].ToString() == tenSach)
                {
                    row["SoLuong"] = (int)row["SoLuong"] + soLuong;
                    row["ThanhTien"] = (int)row["SoLuong"] * donGia;
                    return;
                }
            }

            decimal thanhTien = soLuong * donGia;
            int a = 0;
            for (int i = 0; i < gioHang.Rows.Count; i++)
            {
                int id = (int)gioHang.Rows[i]["ID"];
                if (id > a)
                    a = id;
            }
            a++; 
            gioHang.Rows.Add(a, tenSach, theLoai, soLuong, donGia, thanhTien);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtTongHoaDon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

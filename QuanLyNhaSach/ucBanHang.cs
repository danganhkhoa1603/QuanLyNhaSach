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
using static QuanLyNhaSach.frmBaoCaoThang_BaoCaoTon;

namespace QuanLyNhaSach
{
    public partial class ucBanHang : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
        DataTable gioHang = new DataTable();
        bool isEditing = false;
        public ucBanHang()
        {
            InitializeComponent();
            dgvGioHang.ReadOnly = true;
        }
        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (DataRow row in gioHang.Rows)
            {
                tong += Convert.ToDecimal(row["ThanhTien"]);
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
                ThemSach(id, ten, loai, sl, gia);
                CapNhatTongTien();
            };
        }
        private void ThemSachHandler(int id, string ten, string loai, int sl, decimal gia)
        {
            ThemSach(id, ten, loai, sl, gia);
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

            if (!decimal.TryParse(txtTienDaNhan.Text, out decimal tienKhachDaNhan))
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
                    // ================== 1. TẠO HÓA ĐƠN ==================
                    string maHoaDon = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");

                    string queryHD = @"
                INSERT INTO HoaDon(MaHoaDon, KhachHangID, NgayLap)
                OUTPUT INSERTED.ID
                VALUES (@MaHD, @KHID, GETDATE())";

                    SqlCommand cmdHD = new SqlCommand(queryHD, conn, tran);
                    cmdHD.Parameters.AddWithValue("@MaHD", maHoaDon);
                    cmdHD.Parameters.AddWithValue("@KHID", currentKhachHangID);

                    int hoaDonID = (int)cmdHD.ExecuteScalar();

                    // ================== 2. CHI TIẾT HÓA ĐƠN + TỒN KHO ==================
                    foreach (DataRow row in gioHang.Rows)
                    {
                        int sachID = Convert.ToInt32(row["SachID"]);
                        int soLuongBan = Convert.ToInt32(row["SoLuong"]);

                        // kiểm tra tồn kho
                        SqlCommand checkSL = new SqlCommand(
                            "SELECT SoLuong FROM Sach WHERE ID = @SachID", conn, tran);
                        checkSL.Parameters.AddWithValue("@SachID", sachID);

                        int tonKho = Convert.ToInt32(checkSL.ExecuteScalar());

                        if (tonKho < soLuongBan)
                            throw new Exception("Không đủ số lượng sách!");

                        // insert chi tiết hóa đơn
                        SqlCommand cmdCT = new SqlCommand(@"
                    INSERT INTO ChiTietHoaDon(HoaDonID, SachID, SoLuong, DonGia)
                    VALUES (@HDID, @SachID, @SL, @Gia)", conn, tran);

                        cmdCT.Parameters.AddWithValue("@HDID", hoaDonID);
                        cmdCT.Parameters.AddWithValue("@SachID", sachID);
                        cmdCT.Parameters.AddWithValue("@SL", soLuongBan);
                        cmdCT.Parameters.AddWithValue("@Gia", row["DonGia"]);

                        cmdCT.ExecuteNonQuery();

                        // trừ tồn kho
                        SqlCommand updateSach = new SqlCommand(@"
                    UPDATE Sach
                    SET SoLuong = SoLuong - @SL
                    WHERE ID = @SachID", conn, tran);

                        updateSach.Parameters.AddWithValue("@SL", soLuongBan);
                        updateSach.Parameters.AddWithValue("@SachID", sachID);

                        updateSach.ExecuteNonQuery();
                    }

                    // ================== 3. TÍNH CÔNG NỢ ==================
                    decimal tongTien = gioHang.AsEnumerable()
                        .Sum(r => Convert.ToDecimal(r["ThanhTien"]));

                    decimal phatSinh = tongTien - tienKhachDaNhan;
                    phatSinh = Math.Round(phatSinh, 0);

                    if (phatSinh > 0)
                    {
                        decimal noToiDa = QuyDinhBUS.LaySoTienNoToiDa();

                        int? id = null;
                        decimal noCuoiCu = 0;

                        // lấy công nợ hiện tại
                        string check = @"
                    SELECT ID, NoCuoi 
                    FROM BaoCaoCongNo
                    WHERE Thang = @Thang 
                      AND Nam = @Nam 
                      AND KhachHangID = @KHID";

                        using (SqlCommand cmdCheck = new SqlCommand(check, conn, tran))
                        {
                            cmdCheck.Parameters.AddWithValue("@Thang", DateTime.Now.Month);
                            cmdCheck.Parameters.AddWithValue("@Nam", DateTime.Now.Year);
                            cmdCheck.Parameters.AddWithValue("@KHID", currentKhachHangID);

                            using (SqlDataReader reader = cmdCheck.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    id = Convert.ToInt32(reader["ID"]);
                                    noCuoiCu = Convert.ToDecimal(reader["NoCuoi"]);
                                }
                            }
                        }

                        decimal noMoi = noCuoiCu + phatSinh;

                        // kiểm tra hạn mức
                        if (noMoi > noToiDa)
                        {
                            decimal noConLai = noToiDa - noMoi;

                            MessageBox.Show(
                                "Khách hàng vượt hạn mức công nợ!\n\n" +
                                $"• Nợ hiện tại: {noMoi:N0}\n" +
                                $"• Hạn mức: {noToiDa:N0}"
                            );

                            tran.Rollback();
                            return;
                        }

                        // update hoặc insert
                        if (id.HasValue)
                        {
                            SqlCommand cmdUpdate = new SqlCommand(@"
                        UPDATE BaoCaoCongNo
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
                            decimal noDau = 0;

                            SqlCommand cmdNoDau = new SqlCommand(@"
                        SELECT TOP 1 NoCuoi 
                        FROM BaoCaoCongNo
                        WHERE KhachHangID = @KHID
                        ORDER BY Nam DESC, Thang DESC", conn, tran);

                            cmdNoDau.Parameters.AddWithValue("@KHID", currentKhachHangID);

                            object result = cmdNoDau.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                                noDau = Convert.ToDecimal(result);

                            decimal noCuoi = noDau + phatSinh;
                            MessageBox.Show($"DEBUG: noCuoi={noCuoi} | noToiDa={noToiDa}");

                            if (noCuoi > noToiDa)
                            {
                                MessageBox.Show($"Khách hàng vượt hạn mức công nợ!");
                                tran.Rollback();
                                return;
                            }

                            SqlCommand cmdInsert = new SqlCommand(@"
                        INSERT INTO BaoCaoCongNo
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

                    // ================== 4. COMMIT ==================
                    tran.Commit();

                    MessageBox.Show("Thanh toán thành công!");

                    // reset form
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
        public void ThemSach(int sachID, string tenSach, string theLoai, int soLuong, decimal donGia)
        {
            foreach (DataRow row in gioHang.Rows)
            {
                if ((int)row["SachID"] == sachID)
                {
                    row["SoLuong"] = (int)row["SoLuong"] + soLuong;
                    row["ThanhTien"] = (int)row["SoLuong"] * donGia;
                    return;
                }
            }

            decimal thanhTien = soLuong * donGia;

            gioHang.Rows.Add(sachID, tenSach, theLoai, soLuong, donGia, thanhTien);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtTongHoaDon_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa dòng đã chọn không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvGioHang.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dgvGioHang.Rows.Remove(row);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                // 👉 BẮT ĐẦU SỬA
                if (dgvGioHang.CurrentRow == null)
                {
                    MessageBox.Show("Chọn dòng cần sửa!");
                    return;
                }

                isEditing = true;
                btnSua.Text = "Lưu";

                // Cho sửa
                dgvGioHang.ReadOnly = false;

                // Chỉ cho sửa 1 số cột (khuyên dùng)
                dgvGioHang.Columns["SachID"].ReadOnly = true;
                dgvGioHang.Columns["TenSach"].ReadOnly = true;
                MessageBox.Show("Bạn có thể chỉnh sửa rồi!");
            }
            else
            {
                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    if (row.IsNewRow) continue;

                    int sachID = Convert.ToInt32(row.Cells["SachID"].Value);
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                    int tonHienTai = QuyDinhBUS.LaySoLuongTonTheoID(sachID);
                    int tonToiThieu = QuyDinhBUS.LaySoLuongTonToiThieuSauBan();

                    int maxBan = tonHienTai - tonToiThieu;

                    if (maxBan <= 0)
                    {
                        MessageBox.Show($"Sách ID {sachID} không thể bán thêm!");
                        return;
                    }

                    if (soLuong > maxBan)
                    {
                        MessageBox.Show($"Sách ID {sachID} chỉ được bán tối đa {maxBan} quyển!");
                        return;
                    }
                }

                // 👉 OK thì lưu
                isEditing = false;
                btnSua.Text = "Sửa";
                dgvGioHang.ReadOnly = true;

                MessageBox.Show("Đã lưu chỉnh sửa hợp lệ!");
            }
        }

        private void txtTienDaNhan_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}

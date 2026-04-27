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
using ExcelDataReader;
using System.IO;

namespace QuanLyNhaSach
{

    public partial class ucNhapSach : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
        DataTable gioNhap = new DataTable();
        public ucNhapSach()
        {
            InitializeComponent();
        }
        void LoadSach()
        {
            string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                            ID,
                            TenSach,
                            TheLoai,
                            TacGia,
                            SoLuong,
                            DonGia
                         FROM Sach";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // 👉 Hiển thị tiếng Việt cho đẹp
                dataGridView1.Columns["TenSach"].HeaderText = "Tên Sách";
                dataGridView1.Columns["TheLoai"].HeaderText = "Thể Loại";
                dataGridView1.Columns["TacGia"].HeaderText = "Tác Giả";
                dataGridView1.Columns["SoLuong"].HeaderText = "Số Lượng";
                dataGridView1.Columns["DonGia"].HeaderText = "Đơn Giá";
            }
        }
        private string GetValue(DataRow row, string col1, string col2)
        {
            if (row.Table.Columns.Contains(col1))
                return row[col1]?.ToString().Trim() ?? "";

            if (row.Table.Columns.Contains(col2))
                return row[col2]?.ToString().Trim() ?? "";

            return "";
        }
        private void btnNhapSachMoi_Click(object sender, EventArgs e)
        {
            ucNhapSachMoi ucNhap = new ucNhapSachMoi();

            // truyền chính grid này qua
            ucNhap.SetGrid(this);

            // mở dạng popup
            Form f = new Form();
            f.Text = "Nhập Sách";
            f.Size = new Size(500, 400);

            ucNhap.Dock = DockStyle.Fill;
            f.Controls.Add(ucNhap);

            f.ShowDialog();
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            var frm = (frmBaoCaoThang_BaoCaoTon)this.FindForm();
            frm.HienThiUserControl(new ucLichSuNhap());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void ThemSach(string ten, string theLoai, string tacGia, int soLuongNhap, decimal DonGia)
        {
            if (gioNhap.Columns.Count == 0)
            {
                gioNhap.Columns.Add("TenSach");
                gioNhap.Columns.Add("TheLoai");
                gioNhap.Columns.Add("TacGia");
                gioNhap.Columns.Add("SoLuong");
                gioNhap.Columns.Add("DonGia");
                gioNhap.Columns.Add("ThanhTien");

                dataGridView1.DataSource = gioNhap;
            }

            decimal thanhTien = soLuongNhap * DonGia;

            gioNhap.Rows.Add(ten, theLoai, tacGia, soLuongNhap, DonGia, thanhTien);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    decimal tongTien = 0;

                    // ================== 1. TẠO PHIẾU ==================
                    string insertPhieu = @"
                    INSERT INTO PhieuNhapSach (NgayNhap, TongTien)
                    OUTPUT INSERTED.ID, INSERTED.MaPhieuNhap
                    VALUES (GETDATE(), 0)";

                    SqlCommand cmdPhieu = new SqlCommand(insertPhieu, conn, tran);
                    SqlDataReader reader = cmdPhieu.ExecuteReader();

                    int phieuID = 0;
                    string maPhieu = "";

                    if (reader.Read())
                    {
                        phieuID = Convert.ToInt32(reader["ID"]);
                        maPhieu = reader["MaPhieuNhap"].ToString();
                    }
                    reader.Close();

                    // ================== 2. DUYỆT GRID ==================
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string tenSach = row.Cells["TenSach"]?.Value?.ToString() ?? "";
                        string theLoai = row.Cells["TheLoai"]?.Value?.ToString() ?? "";
                        string tacGia = row.Cells["TacGia"]?.Value?.ToString() ?? "";

                        int soLuong = int.TryParse(row.Cells["SoLuong"]?.Value?.ToString(), out int sl) ? sl : 0;
                        decimal donGia = decimal.TryParse(row.Cells["DonGia"]?.Value?.ToString(), out decimal dg) ? dg : 0;

                        decimal thanhTien = soLuong * donGia;
                        tongTien += thanhTien;

                        int sachID = 0;

                        // ================== 3. CHECK SÁCH ==================
                        string check = @"SELECT ID FROM Sach 
                                 WHERE TenSach = @TenSach AND TacGia = @TacGia";

                        SqlCommand cmdCheck = new SqlCommand(check, conn, tran);
                        cmdCheck.Parameters.AddWithValue("@TenSach", tenSach);
                        cmdCheck.Parameters.AddWithValue("@TacGia", tacGia);

                        object result = cmdCheck.ExecuteScalar();

                        if (result != null)
                        {
                            // ===== UPDATE =====
                            sachID = Convert.ToInt32(result);

                            string update = @"
                            UPDATE Sach
                            SET SoLuong = SoLuong + @SoLuong,
                                DonGia = @DonGia,
                                TheLoai = @TheLoai
                            WHERE ID = @ID";

                            SqlCommand cmdUpdate = new SqlCommand(update, conn, tran);
                            cmdUpdate.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmdUpdate.Parameters.AddWithValue("@DonGia", donGia);
                            cmdUpdate.Parameters.AddWithValue("@TheLoai", theLoai);
                            cmdUpdate.Parameters.AddWithValue("@ID", sachID);

                            cmdUpdate.ExecuteNonQuery();
                        }
                        else
                        {
                            // ===== INSERT SÁCH MỚI =====
                            string insertSach = @"
                            INSERT INTO Sach (TenSach, TheLoai, TacGia, SoLuong, DonGia)
                            OUTPUT INSERTED.ID
                            VALUES (@TenSach, @TheLoai, @TacGia, @SoLuong, @DonGia)";

                            SqlCommand cmdInsert = new SqlCommand(insertSach, conn, tran);
                            cmdInsert.Parameters.AddWithValue("@TenSach", tenSach);
                            cmdInsert.Parameters.AddWithValue("@TheLoai", theLoai);
                            cmdInsert.Parameters.AddWithValue("@TacGia", tacGia);
                            cmdInsert.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmdInsert.Parameters.AddWithValue("@DonGia", donGia);

                            // ✅ LẤY ID TRƯỚC
                            sachID = Convert.ToInt32(cmdInsert.ExecuteScalar());

                            // ✅ SAU ĐÓ mới tạo MaSach
                            string maSach = "MS" + sachID.ToString("D3");

                            string updateMa = "UPDATE Sach SET MaSach = @MaSach WHERE ID = @ID";
                            SqlCommand cmdUpdateMa = new SqlCommand(updateMa, conn, tran);
                            cmdUpdateMa.Parameters.AddWithValue("@MaSach", maSach);
                            cmdUpdateMa.Parameters.AddWithValue("@ID", sachID);
                            cmdUpdateMa.ExecuteNonQuery();
                        }

                        // ================== 4. LƯU CHI TIẾT ==================
                        string insertCT = @"
                        INSERT INTO ChiTietPhieuNhap
                        (PhieuNhapID, SachID, SoLuongNhap, DonGiaNhap)
                        VALUES (@PhieuID, @SachID, @SoLuong, @DonGia)";

                        SqlCommand cmdCT = new SqlCommand(insertCT, conn, tran);
                        cmdCT.Parameters.AddWithValue("@PhieuID", phieuID);
                        cmdCT.Parameters.AddWithValue("@SachID", sachID);
                        cmdCT.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmdCT.Parameters.AddWithValue("@DonGia", donGia);
                        
                        cmdCT.ExecuteNonQuery();
                    }

                    // ================== 5. UPDATE TỔNG ==================
                    string updateTong = "UPDATE PhieuNhapSach SET TongTien=@TongTien WHERE ID=@ID";
                    SqlCommand cmdTong = new SqlCommand(updateTong, conn, tran);
                    cmdTong.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdTong.Parameters.AddWithValue("@ID", phieuID);

                    cmdTong.ExecuteNonQuery();

                    tran.Commit();

                    MessageBox.Show("Lưu thành công!\nMã phiếu: " + maPhieu);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                gioNhap.Clear();
                dataGridView1.DataSource = null;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                gioNhap.Clear();
                gioNhap.Columns.Clear();

                // ✅ dùng tên giống DB
                gioNhap.Columns.Add("TenSach");
                gioNhap.Columns.Add("TheLoai");
                gioNhap.Columns.Add("TacGia");
                gioNhap.Columns.Add("SoLuong");
                gioNhap.Columns.Add("DonGia");
                gioNhap.Columns.Add("ThanhTien");

                using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });

                    DataTable dt = result.Tables[0];

                    foreach (DataRow row in dt.Rows)
                    {
                        string tenSach = GetValue(row, "TenSach", "Tên Sách");
                        string theLoai = GetValue(row, "TheLoai", "Thể Loại");
                        string tacGia = GetValue(row, "TacGia", "Tác Giả");

                        int soLuong = int.TryParse(GetValue(row, "SoLuong", "Số Lượng"), out int sl) ? sl : 0;
                        decimal donGia = decimal.TryParse(GetValue(row, "DonGia", "Đơn Giá"), out decimal dg) ? dg : 0;

                        decimal thanhTien = soLuong * donGia;

                        gioNhap.Rows.Add(tenSach, theLoai, tacGia, soLuong, donGia, thanhTien);
                    }
                }

                // ✅ đặt header SAU khi bind
                dataGridView1.DataSource = gioNhap;

                // ✅ đặt header sau bind
                dataGridView1.Columns["TenSach"].HeaderText = "Tên Sách";
                dataGridView1.Columns["TheLoai"].HeaderText = "Thể Loại";
                dataGridView1.Columns["TacGia"].HeaderText = "Tác Giả";
                dataGridView1.Columns["SoLuong"].HeaderText = "Số Lượng";
                dataGridView1.Columns["DonGia"].HeaderText = "Đơn Giá";
                dataGridView1.Columns["ThanhTien"].HeaderText = "Thành Tiền";

                // ✅ format tiền
                dataGridView1.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

                dataGridView1.ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ucNhapSach_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;

            // ✅ thêm 2 dòng này
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += (s, ev) =>
            {
                if (dataGridView1.IsCurrentCellDirty)
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // ❗ tránh lỗi index
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // ❗ tránh lỗi khi grid chưa có cột
            if (!dataGridView1.Columns.Contains("SoLuong") ||
                !dataGridView1.Columns.Contains("DonGia") ||
                !dataGridView1.Columns.Contains("ThanhTien"))
                return;

            string colName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (colName == "SoLuong" || colName == "DonGia")
            {
                var row = dataGridView1.Rows[e.RowIndex];

                int soLuong = int.TryParse(row.Cells["SoLuong"]?.Value?.ToString(), out int sl) ? sl : 0;
                decimal donGia = decimal.TryParse(row.Cells["DonGia"]?.Value?.ToString(), out decimal dg) ? dg : 0;

                row.Cells["ThanhTien"].Value = soLuong * donGia;
            }
        }
    }
}

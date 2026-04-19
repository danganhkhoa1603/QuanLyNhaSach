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
    public partial class ucNhapSach : UserControl
    {
        public ucNhapSach()
        {
            InitializeComponent();
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
            dataGridView1.Rows.Add(
                dataGridView1.Rows.Count + 1,
                ten,
                theLoai,
                tacGia,
                soLuongNhap,
                DonGia
            );
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    decimal tongTien = 0;

                    // 1. Tạo phiếu nhập (SQL tự sinh MaPhieu)
                    string insertPhieu = @"
            INSERT INTO PhieuNhapSach (NgayNhap, TongTien)
            OUTPUT INSERTED.ID, INSERTED.MaPhieuNhap
            VALUES (GETDATE(), 0);";

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

                    // 2. Duyệt grid
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string tenSach = row.Cells["colTenSach"].Value?.ToString() ?? "";
                        string theLoai = row.Cells["colTheLoai"].Value?.ToString() ?? "";
                        string tacGia = row.Cells["colTacGia"].Value?.ToString() ?? "";

                        if (string.IsNullOrWhiteSpace(tenSach)) continue;

                        int soLuong;
                        if (!int.TryParse(row.Cells["colSoLuong"].Value?.ToString(), out soLuong))
                            soLuong = 0;

                        decimal donGia;
                        if (!decimal.TryParse(row.Cells["colDonGia"].Value?.ToString(), out donGia))
                            donGia = 0;

                        decimal thanhTien = soLuong * donGia;
                        tongTien += thanhTien;

                        int sachID = 0;

                        // kiểm tra sách
                        string check = "SELECT ID FROM Sach WHERE TenSach = @TenSach";
                        SqlCommand cmdCheck = new SqlCommand(check, conn, tran);
                        cmdCheck.Parameters.AddWithValue("@TenSach", tenSach);

                        object result = cmdCheck.ExecuteScalar();

                        if (result != null)
                        {
                            sachID = Convert.ToInt32(result);

                            // update
                            string update = @"
                    UPDATE Sach
                    SET SoLuong = SoLuong + @SoLuong,
                        DonGia = @DonGia,
                        TheLoai = @TheLoai,
                        TacGia = @TacGia
                    WHERE ID = @ID";

                            SqlCommand cmdUpdate = new SqlCommand(update, conn, tran);
                            cmdUpdate.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmdUpdate.Parameters.AddWithValue("@DonGia", donGia);
                            cmdUpdate.Parameters.AddWithValue("@TheLoai", theLoai);
                            cmdUpdate.Parameters.AddWithValue("@TacGia", tacGia);
                            cmdUpdate.Parameters.AddWithValue("@ID", sachID);

                            cmdUpdate.ExecuteNonQuery();
                        }
                        else
                        {
                            // insert sách mới
                            string insertSach = @"
                    INSERT INTO Sach (TenSach, TheLoai, TacGia, SoLuong, DonGia)
                    VALUES (@TenSach, @TheLoai, @TacGia, @SoLuong, @DonGia);
                    SELECT SCOPE_IDENTITY();";

                            SqlCommand cmdInsertSach = new SqlCommand(insertSach, conn, tran);
                            cmdInsertSach.Parameters.AddWithValue("@TenSach", tenSach);
                            cmdInsertSach.Parameters.AddWithValue("@TheLoai", theLoai);
                            cmdInsertSach.Parameters.AddWithValue("@TacGia", tacGia);
                            cmdInsertSach.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmdInsertSach.Parameters.AddWithValue("@DonGia", donGia);

                            sachID = Convert.ToInt32(cmdInsertSach.ExecuteScalar());
                        }

                        // lưu chi tiết (DB tự tính ThanhTien)
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

                    // 3. update tổng tiền
                    string updateTong = "UPDATE PhieuNhapSach SET TongTien = @TongTien WHERE ID = @ID";
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
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace QuanLyNhaSach
{
    public partial class ucPhieuThuTien : UserControl
    {
        private string connectionString = @"Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

        private int maKhachHangHienTai = -1;

        public ucPhieuThuTien()
        {
            InitializeComponent();
        }

        private void ucPhieuThuTien_Load(object sender, EventArgs e)
        {
            txtSDT.TextChanged += txtSDT_TextChanged;
            txtSDT.KeyDown += txtSDT_KeyDown;
        }

        // =========================
        // CHỈ SEARCH KHI ĐỦ 10 SỐ
        // =========================
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();

            // chỉ cho nhập số (lọc nhẹ)
            if (sdt.Length > 10)
            {
                txtSDT.Text = sdt.Substring(0, 10);
                txtSDT.SelectionStart = txtSDT.Text.Length;
                return;
            }

            if (sdt.Length == 10)
            {
                TimKiemThongTinKhachHang(sdt);
            }
        }

        // =========================
        // NHẤN ENTER ĐỂ SEARCH
        // =========================
        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sdt = txtSDT.Text.Trim();

                if (sdt.Length == 10)
                {
                    TimKiemThongTinKhachHang(sdt);
                }
                else
                {
                    MessageBox.Show("Số điện thoại phải đủ 10 số!");
                }

                e.SuppressKeyPress = true;
            }
        }

        // =========================
        // TÌM KHÁCH HÀNG
        // =========================
        // =========================
        // TÌM KHÁCH HÀNG (ĐÃ SỬA TÊN CỘT)
        // =========================
        private void TimKiemThongTinKhachHang(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Sửa lại tên cột: ID, TenKhachHang, DienThoai
                    // Thêm ORDER BY Nam DESC, Thang DESC để luôn lấy công nợ của tháng mới nhất
                    string query = @"
                        SELECT TOP 1
                            kh.ID,
                            kh.TenKhachHang,
                            kh.Email,
                            kh.DiaChi,
                            ISNULL(cn.NoCuoi, 0) AS NoCuoi
                        FROM KhachHang kh
                        LEFT JOIN BaoCaoCongNo cn 
                            ON kh.ID = cn.KhachHangID
                        WHERE kh.DienThoai = @Key
                        ORDER BY cn.Nam DESC, cn.Thang DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Key", keyword);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Đọc dữ liệu theo đúng tên cột mới
                                maKhachHangHienTai = Convert.ToInt32(reader["ID"]);

                                txtHoTen.Text = reader["TenKhachHang"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtDiaChi.Text = reader["DiaChi"].ToString();
                                txtCongNo.Text = reader["NoCuoi"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy khách hàng!");

                                maKhachHangHienTai = -1;
                                txtHoTen.Clear();
                                txtEmail.Clear();
                                txtDiaChi.Clear();
                                txtCongNo.Text = "0";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // =========================
        // THANH TOÁN (ĐÃ SỬA UPDATE CÔNG NỢ)
        // =========================
        // =========================
        // THANH TOÁN (Đã sửa lỗi cột MaKH và LyDo)
        // =========================
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (maKhachHangHienTai == -1)
            {
                MessageBox.Show("Chưa chọn khách hàng!");
                return;
            }

            if (!decimal.TryParse(txtSoTienThu.Text, out decimal soTienThu) || soTienThu <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // ===== 1. PHIẾU THU =====
                    // Đã đổi MaKH thành KhachHangID và xóa cột LyDo
                    // Lưu ý: Kiểm tra lại tên cột NgayThu, SoTienThu xem đã khớp với Database chưa nhé!
                    string insertPT = @"
                        INSERT INTO PhieuThu(KhachHangID, NgayThu, SoTienThu)
                        VALUES (@MaKH, @Ngay, @Tien)";

                    SqlCommand cmdPT = new SqlCommand(insertPT, conn, tran);
                    cmdPT.Parameters.AddWithValue("@MaKH", maKhachHangHienTai);
                    cmdPT.Parameters.AddWithValue("@Ngay", DateTime.Now);
                    cmdPT.Parameters.AddWithValue("@Tien", soTienThu);
                    // Đã bỏ dòng gán giá trị cho @LyDo

                    cmdPT.ExecuteNonQuery();

                    // ===== 2. CÔNG NỢ =====
                    string updateCN = @"
                        UPDATE BaoCaoCongNo
                        SET PhatSinh = PhatSinh - @Tien,
                            NoCuoi = NoCuoi - @Tien
                        WHERE KhachHangID = @MaKH AND Thang = MONTH(GETDATE()) AND Nam = YEAR(GETDATE())";

                    SqlCommand cmdCN = new SqlCommand(updateCN, conn, tran);
                    cmdCN.Parameters.AddWithValue("@Tien", soTienThu);
                    cmdCN.Parameters.AddWithValue("@MaKH", maKhachHangHienTai);

                    cmdCN.ExecuteNonQuery();

                    tran.Commit();

                    MessageBox.Show("Thu tiền thành công!");

                    txtSoTienThu.Clear();
                    txtLyDo.Clear(); // Trên form vẫn clear text bình thường cho sạch form

                    // reload lại info
                    TimKiemThongTinKhachHang(txtSDT.Text.Trim());
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        // Sự kiện click nút Xuất File
        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã có thông tin khách hàng chưa
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập/tìm thông tin khách hàng trước khi xuất file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở hộp thoại cho phép người dùng chọn nơi lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            saveFileDialog.Title = "Lưu phiếu thu Excel";
            // Tên file mặc định (ví dụ: PhieuThu_0908817384.xlsx)
            saveFileDialog.FileName = "PhieuThu_" + txtSDT.Text.Trim() + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                XuatFileExcel(saveFileDialog.FileName);
            }
        }

        // Hàm xử lý xuất Excel
        // Hàm xử lý xuất Excel sử dụng ClosedXML (Không cần cài Excel trên máy)
        private void XuatFileExcel(string filePath)
        {
            try
            {
                // Khởi tạo một Workbook mới
                using (var workbook = new XLWorkbook())
                {
                    // Thêm một Worksheet
                    var worksheet = workbook.Worksheets.Add("Phiếu Thu");

                    // --- ĐỊNH DẠNG VÀ GHI DỮ LIỆU ---

                    // Tiêu đề
                    worksheet.Cell(1, 1).Value = "PHIẾU THU TIỀN";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontSize = 16;

                    // Ghi thông tin Khách hàng
                    worksheet.Cell(3, 1).Value = "Họ và tên khách hàng:";
                    worksheet.Cell(3, 2).Value = txtHoTen.Text;

                    worksheet.Cell(4, 1).Value = "Số điện thoại:";
                    // Thêm dấu nháy đơn (') để giữ nguyên số 0 ở đầu số điện thoại
                    worksheet.Cell(4, 2).Value = "'" + txtSDT.Text;

                    worksheet.Cell(5, 1).Value = "Email:";
                    worksheet.Cell(5, 2).Value = txtEmail.Text;

                    worksheet.Cell(6, 1).Value = "Địa chỉ:";
                    worksheet.Cell(6, 2).Value = txtDiaChi.Text;

                    // Ghi thông tin Thanh toán
                    worksheet.Cell(8, 1).Value = "Ngày thu tiền:";
                    worksheet.Cell(8, 2).Value = "'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                    worksheet.Cell(9, 1).Value = "Số tiền thu:";
                    worksheet.Cell(9, 2).Value = txtSoTienThu.Text;

                    worksheet.Cell(10, 1).Value = "Lý do thu tiền:";
                    worksheet.Cell(10, 2).Value = txtLyDo.Text;

                    // Căn chỉnh tự động độ rộng của tất cả các cột cho đẹp
                    worksheet.Columns().AdjustToContents();

                    // Lưu file lại
                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
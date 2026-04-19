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
    public partial class ucLichSuNhap : UserControl
    {
        public ucLichSuNhap()
        {
            InitializeComponent();
            LoadLichSuNhap();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            var frm = (frmBaoCaoThang_BaoCaoTon)this.FindForm();
            frm.HienThiUserControl(new ucXemChiTiet());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var frm = (frmBaoCaoThang_BaoCaoTon)this.FindForm();
            frm.HienThiUserControl(new ucNhapSach());
        }
        public void LoadLichSuNhap()
        {
            string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Truy vấn lấy thông tin từ bảng PhieuNhapSach
                    string sql = "SELECT MaPhieuNhap AS [Mã Phiếu], NgayNhap AS [Ngày Nhập], TongTien AS [Tổng Tiền] FROM PhieuNhapSach";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Đổ vào DataGridView (ví dụ tên là dtgvLichSu)
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

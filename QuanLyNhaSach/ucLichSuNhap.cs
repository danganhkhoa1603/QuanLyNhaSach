using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class ucLichSuNhap : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

        public ucLichSuNhap()
        {
            InitializeComponent();
            LoadLichSuNhap();
        }

        public void LoadLichSuNhap()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"SELECT 
                                   MaPhieuNhap, 
                                   NgayNhap, 
                                   TongTien 
                                   FROM PhieuNhapSach";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // 👉 CLICK DÒNG
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maPhieuNhap = dataGridView1.Rows[e.RowIndex]
                                        .Cells["MaPhieuNhap"].Value.ToString();

                var frm = (frmBaoCaoThang_BaoCaoTon)this.FindForm();
                frm.HienThiUserControl(new ucXemChiTiet(maPhieuNhap));
            }
        }

        // 👉 NÚT XEM CHI TIẾT
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string maPhieuNhap = dataGridView1.CurrentRow
                                        .Cells["MaPhieuNhap"].Value.ToString();

                var frm = (frmBaoCaoThang_BaoCaoTon)this.FindForm();
                frm.HienThiUserControl(new ucXemChiTiet(maPhieuNhap));
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var frm = (frmBaoCaoThang_BaoCaoTon)this.FindForm();
            frm.HienThiUserControl(new ucNhapSach());
        }
    }
}
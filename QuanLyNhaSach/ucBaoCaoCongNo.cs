using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanLyNhaSach
{
    public partial class ucBaoCaoCongNo : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

        public ucBaoCaoCongNo()
        {
            InitializeComponent();
            XoaCongNoBang0();  
            LoadBaoCaoCongNo();
        }
        void XoaCongNoBang0()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM BaoCaoCongNo WHERE NoCuoi = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        void LoadBaoCaoCongNo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    b.ID,
                    k.TenKhachHang,
                    b.Thang,
                    b.Nam,
                    b.NoDau,
                    b.PhatSinh,
                    b.NoCuoi
                FROM BaoCaoCongNo b
                JOIN KhachHang k ON b.KhachHangID = k.ID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.Columns["TenKhachHang"].HeaderText = "Tên khách hàng";
                dataGridView1.Columns["Thang"].HeaderText = "Tháng";
                dataGridView1.Columns["Nam"].HeaderText = "Năm";
                dataGridView1.Columns["NoDau"].HeaderText = "Nợ đầu";
                dataGridView1.Columns["PhatSinh"].HeaderText = "Phát sinh";
                dataGridView1.Columns["NoCuoi"].HeaderText = "Nợ cuối";

                dataGridView1.Font = new Font("Segoe UI", 10);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        private void btnBaoCaoTon_Click(object sender, EventArgs e)
        {
            Form mainForm = this.FindForm();
            Control pnl = mainForm.Controls.Find("pnlMain", true).FirstOrDefault();
            if (pnl != null)
            {
                pnl.Controls.Clear();

                ucBaoCaoTon ucTon = new ucBaoCaoTon();
                ucTon.Dock = DockStyle.Fill;
                pnl.Controls.Add(ucTon);
            }
        }

        private void btnBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã ở trang này rồi!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class ucBaoCaoTon : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
        public ucBaoCaoTon()
        {
            InitializeComponent();
        }

        private void btnBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            Form mainForm = this.FindForm();
            Control pnl = mainForm.Controls.Find("pnlMain", true).FirstOrDefault();
            if (pnl != null)
            {
                pnl.Controls.Clear();

                ucBaoCaoCongNo ucCongNo = new ucBaoCaoCongNo();
                ucCongNo.Dock = DockStyle.Fill;
                pnl.Controls.Add(ucCongNo);
            }
        }

        void LoadBaoCaoTon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    b.ID,
                    s.TenSach,
                    b.Thang,
                    b.Nam,
                    b.TonDau,
                    b.PhatSinh,
                    b.TonCuoi
                FROM BaoCaoTon b
                JOIN Sach s ON b.SachID = s.ID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                dataGridView1.Columns["TenSach"].HeaderText = "Tên sách";
                dataGridView1.Columns["Thang"].HeaderText = "Tháng";
                dataGridView1.Columns["Nam"].HeaderText = "Năm";
                dataGridView1.Columns["TonDau"].HeaderText = "Tồn đầu";
                dataGridView1.Columns["PhatSinh"].HeaderText = "Phát sinh";
                dataGridView1.Columns["TonCuoi"].HeaderText = "Tồn cuối";
            }
        }
        private void btnBaoCaoTon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã ở trang này rồi!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucBaoCaoTon_Load(object sender, EventArgs e)
        {
            LoadBaoCaoTon();
        }
    }
}

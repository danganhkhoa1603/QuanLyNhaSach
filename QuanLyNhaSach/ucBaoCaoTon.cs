using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class ucBaoCaoTon : UserControl
    {
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

        private void btnBaoCaoTon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã ở trang này rồi!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

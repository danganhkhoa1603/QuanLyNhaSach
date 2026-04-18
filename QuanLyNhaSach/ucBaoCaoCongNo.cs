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
    public partial class ucBaoCaoCongNo : UserControl
    {
        public ucBaoCaoCongNo()
        {
            InitializeComponent();
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
    }
}

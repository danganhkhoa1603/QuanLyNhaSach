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
    public partial class frmBaoCaoThang_BaoCaoCongNo : Form
    {
        public frmBaoCaoThang_BaoCaoCongNo()
        {
            InitializeComponent();
        }

        private void btnBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã ở trang này rồi!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBaoCaoTon_Click(object sender, EventArgs e)
        {
            var frm = new frmBaoCaoThang_BaoCaoTon();
            frm.ShowDialog();
            this.Hide();
        }
    }
}

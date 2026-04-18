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
    public partial class NhapSach : Form
    {
        public NhapSach()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnNhapSachMoi_Click(object sender, EventArgs e)
        {
            frmChiTietNhap frm = new frmChiTietNhap();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            frmLichSuNhap frm = new frmLichSuNhap();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}

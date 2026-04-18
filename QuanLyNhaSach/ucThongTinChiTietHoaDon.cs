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
    public partial class ucThongTinChiTietHoaDon : UserControl
    {
        public ucThongTinChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void ucThongTinChiTietHoaDon_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}

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
    public partial class ucBanHang : UserControl
    {
        public ucBanHang()
        {
            InitializeComponent();
        }

        private void ucBanHang_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSachVaHoaDon_click(object sender, EventArgs e)
        {
            ucThongTinChiTietHoaDon1.Visible = true;

            
            ucThongTinChiTietHoaDon1.BringToFront();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            ucThemKhachHang1.Visible = true;
            ucThemKhachHang1.BringToFront(); 
        }

        private void ucThemKhachHang1_Load(object sender, EventArgs e)
        {

        }

        private void ucThongTinChiTietHoaDon1_Load(object sender, EventArgs e)
        {

        }
    }
}

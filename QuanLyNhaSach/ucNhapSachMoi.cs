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
    public partial class ucNhapSachMoi : UserControl
    {
        public ucNhapSachMoi()
        {
            InitializeComponent();
            
        }
        ucNhapSach grid;

        public void SetGrid(ucNhapSach g)
        {
            grid = g;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            int soLuong;
            if (!int.TryParse(txtSoLuongNhap.Text, out soLuong))
            {
                MessageBox.Show("Số lượng phải là số!");
                return;
            }

            grid.ThemSach(
                txtTenSach.Text,
                txtTheLoai.Text,
                txtTacGia.Text,
                soLuong,
                decimal.Parse(txtDonGia.Text)
            );

            this.ParentForm.Close(); // đóng popup
        }

    }
}

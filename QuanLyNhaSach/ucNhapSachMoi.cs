using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLyNhaSach.frmBaoCaoThang_BaoCaoTon;

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

            decimal donGia;
            if (!decimal.TryParse(txtDonGia.Text, out donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            string tenSach = txtTenSach.Text;

            // ===== QUY ĐỊNH 1 =====
            int soLuongMin = QuyDinhBUS.LaySoLuongNhapToiThieu();

            if (soLuong < soLuongMin)
            {
                MessageBox.Show($"Số lượng nhập phải >= {soLuongMin}");
                return;
            }

            // ===== QUY ĐỊNH 2 =====
            int tonToiThieu = QuyDinhBUS.LaySoLuongNhapToiThieu();

            // ❗ THÊM DÒNG NÀY (bạn bị thiếu)
            int soLuongTon = QuyDinhBUS.LaySoLuongTon(tenSach);

            // nếu sách đã tồn tại
            if (soLuongTon != -1)
            {
                if (soLuongTon >= tonToiThieu)
                {
                    MessageBox.Show($"Chỉ được nhập khi tồn < {tonToiThieu}");
                    return;
                }
            }

            // ===== OK thì cho nhập =====
            grid.ThemSach(
                tenSach,
                txtTheLoai.Text,
                txtTacGia.Text,
                soLuong,
                donGia
            );

            this.ParentForm.Close();
        }

    }
}

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
    public partial class ucThayDoiQuyDinh : UserControl
    {
        public ucThayDoiQuyDinh()
        {
            InitializeComponent();
        }

        private void ucThayDoiQuyDinh_Load(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn đăng xuất và quay lại màn hình đăng nhập?", "Xác nhận", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}

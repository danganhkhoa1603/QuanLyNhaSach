using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            // 1. Khởi tạo Form đăng nhập (ví dụ tên là Form1)
            Form1 fLogin = new Form1();

            // 2. Đăng ký sự kiện: Khi Form đăng nhập đóng thì tắt hẳn app luôn
            fLogin.FormClosed += (s, args) => Application.Exit();

            // 3. Hiển thị Form đăng nhập
            fLogin.Show();

            // 4. Tìm Form chính và ẨN nó đi (Đừng Close nếu nó là Main Form)
            Form parent = this.FindForm();
            if (parent != null)
            {
                parent.Hide();
            }
        }
    }
}

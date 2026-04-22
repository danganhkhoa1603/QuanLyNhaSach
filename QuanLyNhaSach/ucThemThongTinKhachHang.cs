using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class ucThemThongTinKhachHang : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

        public event Action<int, string> OnKhachHangAdded;

        public ucThemThongTinKhachHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (!txtSDT.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return;
            }
            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO KhachHang(TenKhachHang, DiaChi, DienThoai, Email)
                         OUTPUT INSERTED.ID
                         VALUES (@Ten, @DiaChi, @DT, @Email)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@DT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                int khachHangID = (int)cmd.ExecuteScalar();

                // 🔥 Gửi dữ liệu ra ngoài
                OnKhachHangAdded?.Invoke(khachHangID, txtHoTen.Text);

                MessageBox.Show("Thêm khách hàng thành công!");

                this.Visible = false; // ẩn UC sau khi thêm
            }
        }
    }
}

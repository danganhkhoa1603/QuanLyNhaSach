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

        int currentKhachHangID = 0;

        public ucThemThongTinKhachHang()
        {
            InitializeComponent();
            txtSDT.TextChanged += txtSDT_TextChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            // tránh query liên tục khi đang nhập ít số
            if (txtSDT.Text.Length < 5)
                return;
            if (!txtSDT.Text.All(char.IsDigit)) return;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT ID, TenKhachHang, DiaChi, Email 
                         FROM KhachHang 
                         WHERE DienThoai = @DT";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DT", txtSDT.Text.Trim());

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // AUTO FILL
                    txtHoTen.Text = reader["TenKhachHang"].ToString();
                    txtDiaChi.Text = reader["DiaChi"].ToString();
                    txtEmail.Text = reader["Email"].ToString();

                    // lưu ID để dùng sau (quan trọng cho công nợ)
                    currentKhachHangID = Convert.ToInt32(reader["ID"]);
                }
                else
                {
                    currentKhachHangID = 0;
                }

                reader.Close();
            }
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            // 1. Nếu đã tồn tại → dùng luôn
            if (currentKhachHangID != 0)
            {
                OnKhachHangAdded?.Invoke(currentKhachHangID, txtHoTen.Text);
                MessageBox.Show("Đã chọn khách hàng có sẵn!");
                this.Visible = false;
                return;
            }

            // 2. Validate khi thêm mới
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!txtSDT.Text.All(char.IsDigit) || txtSDT.Text.Length < 9)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }

            // 3. Thêm mới khách hàng
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO KhachHang(TenKhachHang, DiaChi, DienThoai, Email)
                         OUTPUT INSERTED.ID
                         VALUES (@Ten, @DiaChi, @DT, @Email)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten", txtHoTen.Text.Trim());
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@DT", txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                int newID = (int)cmd.ExecuteScalar();

                OnKhachHangAdded?.Invoke(newID, txtHoTen.Text);

                MessageBox.Show("Thêm khách hàng thành công!");

                this.Visible = false;
            }
        }
    }
}

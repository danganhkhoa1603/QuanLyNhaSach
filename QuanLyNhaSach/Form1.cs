using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BCrypt.Net;

namespace QuanLyNhaSach
{
    public partial class Form1 : Form
    {
        string connStr = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================
        // LOGIN BUTTON
        // =========================
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    SELECT PasswordHash, Role 
                    FROM Users 
                    WHERE UserName = @u";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedHash = reader["PasswordHash"].ToString();
                    string role = reader["Role"]?.ToString() ?? "NhanVien";

                    // =========================
                    // CHECK PASSWORD (BCrypt)
                    // =========================
                    bool isCorrect = BCrypt.Net.BCrypt.Verify(password, storedHash);

                    if (isCorrect)
                    {
                        MessageBox.Show("Đăng nhập thành công! Quyền: " + role);

                        // =========================
                        // MỞ FORM CHÍNH + TRUYỀN ROLE
                        // =========================
                        frmBaoCaoThang_BaoCaoTon frm = new frmBaoCaoThang_BaoCaoTon();

                        frm.QuyenTruyCap = role; // 🔥 QUAN TRỌNG NHẤT

                        frm.StartPosition = FormStartPosition.CenterScreen;

                        this.Hide(); // ẩn login

                        frm.FormClosed += (s, args) => this.Close();

                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu!");
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại!");
                }
            }
        }

        // =========================
        // SHOW PASSWORD
        // =========================
        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkShowPass.Checked;
        }
    }
}
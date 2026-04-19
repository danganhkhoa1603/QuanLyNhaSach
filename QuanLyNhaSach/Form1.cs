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
using BCrypt.Net;

namespace QuanLyNhaSach
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
        
private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            string connStr = @"Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";



            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // ❌ BỎ so sánh password trong SQL
                string query = "SELECT PasswordHash, Role FROM Users WHERE UserName=@u";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedHash = reader["PasswordHash"].ToString();
                    string role = reader["Role"].ToString();

                    // ✅ So sánh bằng BCrypt
                    bool isCorrect = BCrypt.Net.BCrypt.Verify(password, storedHash);

                    if (isCorrect)
                    {
                        MessageBox.Show("Đăng nhập thành công với quyền: " + role);

                        var frm = new frmBaoCaoThang_BaoCaoTon();
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
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

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (chkShowPass.Checked)
                    txtMatKhau.UseSystemPasswordChar = false;
                else
                    txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }


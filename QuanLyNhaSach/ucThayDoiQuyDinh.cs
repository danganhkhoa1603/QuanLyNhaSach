using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
        bool isEditing = false;

        public ucThayDoiQuyDinh()
        {
            InitializeComponent();
        }

        private void ucThayDoiQuyDinh_Load(object sender, EventArgs e)
        {
            LoadQuyDinh();
            SetReadOnly(true);   // 👉 ban đầu chỉ đọc
            btnCapNhat.Text = "Cập nhật";
        }
        void SetReadOnly(bool isReadOnly)
        {
            txtNhapMin.ReadOnly = isReadOnly;
            txtTonMin.ReadOnly = isReadOnly;
            txtTonSauBan.ReadOnly = isReadOnly;
            txtNoMax.ReadOnly = isReadOnly;

            chkChoPhep.Enabled = !isReadOnly;
        }
        void LoadQuyDinh()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 * FROM QuyDinh";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNhapMin.Text = reader["SoLuongNhapToiThieu"].ToString();
                    txtTonMin.Text = reader["SoLuongTonToiThieu"].ToString();
                    txtTonSauBan.Text = reader["TonToiThieuSauBan"].ToString();
                    txtNoMax.Text = reader["NoToiDa"].ToString();

                    bool choPhep = Convert.ToBoolean(reader["ChoPhepThuVuotNo"]);
                    chkChoPhep.Checked = choPhep;
                }

                reader.Close();
            }
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

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                // 👉 BẮT ĐẦU SỬA
                isEditing = true;
                btnCapNhat.Text = "Lưu";

                SetReadOnly(false);

                MessageBox.Show("Bạn có thể chỉnh sửa!");
            }
            else
            {
                // 👉 XÁC NHẬN TRƯỚC KHI LƯU
                var confirm = MessageBox.Show(
                    "Bạn có chắc muốn lưu thay đổi không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                // 👉 VALIDATE
                if (!int.TryParse(txtNhapMin.Text, out int nhapMin) ||
                    !int.TryParse(txtTonMin.Text, out int tonMin) ||
                    !int.TryParse(txtTonSauBan.Text, out int tonBanMin) ||
                    !decimal.TryParse(txtNoMax.Text, out decimal noMax))
                {
                    MessageBox.Show("Dữ liệu không hợp lệ!");
                    return;
                }

                // 👉 LƯU DB
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string update = @"
                    UPDATE QuyDinh SET
                        SoLuongNhapToiThieu = @NhapMin,
                        SoLuongTonToiThieu = @TonMin,
                        TonToiThieuSauBan = @TonBanMin,
                        NoToiDa = @NoMax,
                        ChoPhepThuVuotNo = @ChoPhep";

                    SqlCommand cmd = new SqlCommand(update, conn);

                    cmd.Parameters.AddWithValue("@NhapMin", nhapMin);
                    cmd.Parameters.AddWithValue("@TonMin", tonMin);
                    cmd.Parameters.AddWithValue("@TonBanMin", tonBanMin);
                    cmd.Parameters.AddWithValue("@NoMax", noMax);
                    cmd.Parameters.AddWithValue("@ChoPhep", chkChoPhep.Checked);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật thành công!");

                // 👉 KHÓA LẠI
                isEditing = false;
                btnCapNhat.Text = "Cập nhật";
                SetReadOnly(true);
            }
        }

        
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class ucTraCuuSach : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
        bool isEditing = false;

        public ucTraCuuSach()
        {
            InitializeComponent();
        }

        // ================= LOAD DATA =================
        void LoadSach()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                    ID,
                                    MaSach,
                                    TenSach,
                                    TheLoai,
                                    TacGia,
                                    SoLuong,
                                    DonGia
                                 FROM Sach";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // 👉 Header tiếng Việt
                if (dataGridView1.Columns["MaSach"] != null)
                    dataGridView1.Columns["MaSach"].HeaderText = "Mã Sách";

                if (dataGridView1.Columns["TenSach"] != null)
                    dataGridView1.Columns["TenSach"].HeaderText = "Tên Sách";

                if (dataGridView1.Columns["TheLoai"] != null)
                    dataGridView1.Columns["TheLoai"].HeaderText = "Thể Loại";

                if (dataGridView1.Columns["TacGia"] != null)
                    dataGridView1.Columns["TacGia"].HeaderText = "Tác Giả";

                if (dataGridView1.Columns["SoLuong"] != null)
                    dataGridView1.Columns["SoLuong"].HeaderText = "Số Lượng";

                if (dataGridView1.Columns["DonGia"] != null)
                    dataGridView1.Columns["DonGia"].HeaderText = "Đơn Giá";

                // 👉 Không cho sửa ID + MaSach
                if (dataGridView1.Columns["ID"] != null)
                {
                    dataGridView1.Columns["ID"].ReadOnly = true;
                    dataGridView1.Columns["ID"].Visible = false; // ẩn luôn cho đẹp
                }

                if (dataGridView1.Columns["MaSach"] != null)
                    dataGridView1.Columns["MaSach"].ReadOnly = true;
            }
        }

        // ================= LOAD COMBOBOX =================
        void LoadComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT TenSach FROM Sach
                                 UNION
                                 SELECT TacGia FROM Sach";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                cbTimKiem.Items.Clear();

                while (reader.Read())
                {
                    cbTimKiem.Items.Add(reader[0].ToString());
                }

                cbTimKiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbTimKiem.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }

        // ================= FORM LOAD =================
        private void ucTraCuuSach_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;

            LoadSach();
            LoadComboBox();
        }

        // ================= SEARCH =================
        private void cbTimKiem_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                    ID,
                                    MaSach,
                                    TenSach,
                                    TheLoai,
                                    TacGia,
                                    SoLuong,
                                    DonGia
                                 FROM Sach
                                 WHERE TenSach LIKE @key OR TacGia LIKE @key";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@key", "%" + cbTimKiem.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                // 👉 set lại header + khóa cột
                if (dataGridView1.Columns["ID"] != null)
                {
                    dataGridView1.Columns["ID"].ReadOnly = true;
                    dataGridView1.Columns["ID"].Visible = false;
                }

                if (dataGridView1.Columns["MaSach"] != null)
                {
                    dataGridView1.Columns["MaSach"].HeaderText = "Mã Sách";
                    dataGridView1.Columns["MaSach"].ReadOnly = true;
                }
            }
        }

        // ================= UPDATE =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                // 👉 Bật sửa
                dataGridView1.ReadOnly = false;
                isEditing = true;
                btnSua.Text = "Lưu";

                if (dataGridView1.Columns["ID"] != null)
                    dataGridView1.Columns["ID"].ReadOnly = true;

                if (dataGridView1.Columns["MaSach"] != null)
                    dataGridView1.Columns["MaSach"].ReadOnly = true;
            }
            else
            {
                // 👉 Lưu
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string query = @"UPDATE Sach 
                                         SET TenSach=@TenSach,
                                             TheLoai=@TheLoai,
                                             TacGia=@TacGia,
                                             SoLuong=@SoLuong,
                                             DonGia=@DonGia
                                         WHERE ID=@ID";

                        SqlCommand cmd = new SqlCommand(query, conn);

                        cmd.Parameters.AddWithValue("@ID", row.Cells["ID"].Value ?? 0);
                        cmd.Parameters.AddWithValue("@TenSach", row.Cells["TenSach"].Value ?? "");
                        cmd.Parameters.AddWithValue("@TheLoai", row.Cells["TheLoai"].Value ?? "");
                        cmd.Parameters.AddWithValue("@TacGia", row.Cells["TacGia"].Value ?? "");
                        cmd.Parameters.AddWithValue("@SoLuong", row.Cells["SoLuong"].Value ?? 0);
                        cmd.Parameters.AddWithValue("@DonGia", row.Cells["DonGia"].Value ?? 0);

                        cmd.ExecuteNonQuery();
                    }
                }

                dataGridView1.ReadOnly = true;
                isEditing = false;
                btnSua.Text = "Sửa";

                MessageBox.Show("Cập nhật thành công!");
                LoadSach();
            }
        }

        // ================= DELETE =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn dòng hợp lệ!");
                return;
            }

            if (dataGridView1.CurrentRow.Cells["ID"].Value == null)
            {
                MessageBox.Show("Không có ID!");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            DialogResult r = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (r != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM Sach WHERE ID=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Xóa thành công!");
                LoadSach();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể xóa (có thể có khóa ngoại)\n\n" + ex.Message);
            }
        }
    }
}
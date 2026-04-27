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

                SetupGrid();
            }
        }

        // ================= SETUP GRID =================
        void SetupGrid()
        {
            if (dataGridView1.Columns["ID"] != null)
            {
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["ID"].ReadOnly = true;
            }

            if (dataGridView1.Columns["MaSach"] != null)
            {
                dataGridView1.Columns["MaSach"].HeaderText = "Mã Sách";
                dataGridView1.Columns["MaSach"].ReadOnly = true;
            }

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
            cbTimKiem.TextChanged += cbTimKiem_TextChanged;
        }

        // ================= SEARCH XỊN =================
        private void cbTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = cbTimKiem.Text.Trim();

            // Nếu rỗng → load lại toàn bộ
            if (string.IsNullOrEmpty(keyword))
            {
                LoadSach();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
        SELECT *
        FROM Sach
        WHERE TenSach LIKE '%' + @key + '%'
           OR TacGia LIKE '%' + @key + '%'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@key", keyword);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                SetupGrid();
            }
        }

        // ================= DELETE =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn dòng!");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);

            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

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
                MessageBox.Show("Không thể xóa!\n" + ex.Message);
            }
        }

        // ================= UPDATE =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
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

                        cmd.Parameters.AddWithValue("@ID", row.Cells["ID"].Value);
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
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class ucLichSuBanHang : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

        public ucLichSuBanHang()
        {
            InitializeComponent();

            // 🔥 gắn event click dòng
            dataGridView1.CellClick += dataGridView1_CellClick;

            LoadHoaDon();
        }

        // 🔥 LOAD DANH SÁCH HÓA ĐƠN
        public void LoadHoaDon()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            hd.ID,
                            hd.MaHoaDon,
                            kh.TenKhachHang,
                            hd.NgayLap
                        FROM HoaDon hd
                        JOIN KhachHang kh ON hd.KhachHangID = kh.ID
                        ORDER BY hd.NgayLap DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 🔥 reset tránh lỗi không có cột
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = true;

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load hóa đơn: " + ex.Message);
            }
        }

        // 🔥 CLICK DÒNG → XEM CHI TIẾT
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cell = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value;
            if (cell == null) return;

            int hoaDonID = Convert.ToInt32(cell);

            MoChiTiet(hoaDonID);
        }

        // 🔥 NÚT XEM CHI TIẾT
        private void btnXemChiTietBanHang_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var cell = dataGridView1.CurrentRow.Cells["ID"].Value;
            if (cell == null) return;

            int hoaDonID = Convert.ToInt32(cell);

            MoChiTiet(hoaDonID);
        }

        // 🔥 MỞ CHI TIẾT HÓA ĐƠN
        private void MoChiTiet(int hoaDonID)
        {
            var frm = (frmBaoCaoThang_BaoCaoTon)this.FindForm();
            if (frm == null)
            {
                return;
            }
            frm.HienThiUserControl(new ucXemChiTietBanHang(hoaDonID));
        }

        // 🔥 QUAY LẠI BÁN HÀNG
        private void button1_Click(object sender, EventArgs e)
        {
            var frm = (frmBaoCaoThang_BaoCaoTon)this.FindForm();
            frm.HienThiUserControl(new ucBanHang());
        }
    }
}
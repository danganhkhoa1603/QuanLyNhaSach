using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class ucXemChiTietBanHang : UserControl
    {
        private int hoaDonID;
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

        public ucXemChiTietBanHang(int hoaDonID)
        {
            InitializeComponent();

            this.hoaDonID = hoaDonID;

            LoadChiTiet();
        }

        // 🔥 LOAD TOÀN BỘ THÔNG TIN VÀO GRID
        private void LoadChiTiet()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT 
                    hd.MaHoaDon,
                    kh.TenKhachHang,
                    hd.NgayLap,
                    s.TenSach,
                    ct.SoLuong,
                    ct.DonGia,
                    ct.SoLuong * ct.DonGia AS ThanhTien
                FROM HoaDon hd
                JOIN KhachHang kh ON hd.KhachHangID = kh.ID
                JOIN ChiTietHoaDon ct ON hd.ID = ct.HoaDonID
                JOIN Sach s ON ct.SachID = s.ID
                WHERE hd.ID = @ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", hoaDonID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // 🔥 reset grid
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = true;

                dataGridView1.DataSource = dt;

                // 🔥 format tiền
                if (dataGridView1.Columns.Contains("DonGia"))
                    dataGridView1.Columns["DonGia"].DefaultCellStyle.Format = "N0";

                if (dataGridView1.Columns.Contains("ThanhTien"))
                    dataGridView1.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
        }

        // 🔥 QUAY LẠI
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            var frm = (frmBaoCaoThang_BaoCaoTon)this.FindForm();
            frm.HienThiUserControl(new ucLichSuBanHang());
        }
    }
}
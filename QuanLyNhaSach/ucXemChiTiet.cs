using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class ucXemChiTiet : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
        string maPhieuNhap;

        // 👉 Constructor nhận mã
        public ucXemChiTiet(string maPhieuNhap)
        {
            InitializeComponent();
            this.maPhieuNhap = maPhieuNhap;

            LoadChiTiet(this.maPhieuNhap);
        }

        public ucXemChiTiet()
        {
            InitializeComponent();
        }

        void LoadChiTiet(string maPhieuNhap)
        {
            if (string.IsNullOrEmpty(maPhieuNhap))
            {
                MessageBox.Show("Mã phiếu nhập bị null!");
                return;
            }

            string query = @"
SELECT 
    pn.MaPhieuNhap,
    s.TenSach,
    s.TheLoai,
    s.TacGia,
    ct.DonGiaNhap AS DonGia,
    ct.SoLuongNhap,
    ct.ThanhTien,
    pn.NgayNhap
FROM ChiTietPhieuNhap ct
JOIN Sach s ON ct.SachID = s.ID
JOIN PhieuNhapSach pn ON ct.PhieuNhapID = pn.ID
WHERE pn.MaPhieuNhap = @MaPhieuNhap";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap.Trim());

                DataTable dt = new DataTable();
                da.Fill(dt);

                MessageBox.Show("[" + maPhieuNhap + "]");

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var frm = (frmBaoCaoThang_BaoCaoTon)this.FindForm();
            frm.HienThiUserControl(new ucLichSuNhap());
        }
    }
}
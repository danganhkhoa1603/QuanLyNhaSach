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
using static QuanLyNhaSach.frmBaoCaoThang_BaoCaoTon;

namespace QuanLyNhaSach
{
    public partial class ucThongTinChiTietHoaDon : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";
        int currentSachID; // biến toàn cục
        public event Action<int, string, string, int, decimal> OnThemSach;
        public ucThongTinChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void ucThongTinChiTietHoaDon_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (currentSachID == 0)
            {
                MessageBox.Show("Vui lòng nhập đúng tên sách!");
                return;
            }

            int soLuong;
            if (!int.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Số lượng phải là số!");
                return;
            }

            decimal donGia;
            if (!decimal.TryParse(txtDonGia.Text, out donGia))
            {
                MessageBox.Show("Giá không hợp lệ!");
                return;
            }

            // ===== 🔥 LẤY DỮ LIỆU =====
            int tonHienTai = QuyDinhBUS.LaySoLuongTon(txtTenSach.Text);
            int tonToiThieu = QuyDinhBUS.LaySoLuongTonToiThieuSauBan();
            int maxBan = tonHienTai - tonToiThieu;

            // ===== 🔥 KIỂM TRA QUY ĐỊNH =====
            if (tonHienTai - soLuong < tonToiThieu)
            {
                MessageBox.Show($"Không được bán! Tồn sau bán phải >= {tonToiThieu} " +
                    $"Chỉ được bán tối đa {maxBan} quyển!");
                return;
            }

            // ===== OK thì cho bán =====
            OnThemSach?.Invoke(
                currentSachID,
                txtTenSach.Text,
                txtTheLoai.Text,
                soLuong,
                donGia
            );

            this.Visible = false;
        }
        private void txtTenSach_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSach.Text))
            {
                txtTheLoai.Text = "";
                txtDonGia.Text = "";
                currentSachID = 0;
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT TOP 1 ID, TenSach, TheLoai, DonGia
                         FROM Sach
                         WHERE TenSach LIKE @Ten";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ten", "%" + txtTenSach.Text + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtTheLoai.Text = reader["TheLoai"].ToString();
                    txtDonGia.Text = reader["DonGia"].ToString();
                    currentSachID = (int)reader["ID"];
                }
                else
                {
                    txtTheLoai.Text = "";
                    txtDonGia.Text = "";
                    currentSachID = 0;
                }
            }
        }
    }
}

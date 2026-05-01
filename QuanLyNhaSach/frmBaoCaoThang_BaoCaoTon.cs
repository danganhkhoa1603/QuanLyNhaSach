using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class frmBaoCaoThang_BaoCaoTon : Form
    {
        // =========================
        // 1. QUYỀN TRUY CẬP (KHÔNG DEFAULT ADMIN NỮA)
        // =========================
        public string QuyenTruyCap { get; set; }

        private Button currentButton;
        private Color activeColor = Color.DeepSkyBlue;
        private Color defaultColor = Color.White;

        public frmBaoCaoThang_BaoCaoTon()
        {
            InitializeComponent();
        }

        // =========================
        // 2. LOAD FORM
        // =========================
        private void frmBaoCaoThang_BaoCaoTon_Load(object sender, EventArgs e)
        {
            // Nếu không truyền quyền → mặc định chặn
            if (string.IsNullOrEmpty(QuyenTruyCap))
            {
                MessageBox.Show("Không xác định quyền đăng nhập!");
                this.Close();
                return;
            }

            // Ẩn chức năng nếu là nhân viên
            if (QuyenTruyCap == "NhanVien")
            {
                btnBaoCaoThang.Enabled = false;
            }

            ActivateButton(btnNhapSach);
            HienThiUserControl(new ucNhapSach());
        }

        // =========================
        // 3. ACTIVE BUTTON UI
        // =========================
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null && btnSender is Button)
            {
                if (currentButton != null)
                {
                    currentButton.BackColor = defaultColor;
                    currentButton.ForeColor = Color.Black;
                }

                currentButton = (Button)btnSender;
                currentButton.BackColor = activeColor;
                currentButton.ForeColor = Color.White;
            }
        }

        public void HienThiUserControl(UserControl uc)
        {
            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }

        // =========================
        // 4. MENU BUTTONS + CHẶN QUYỀN
        // =========================

        private void btnNhapSach_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            HienThiUserControl(new ucNhapSach());
        }

        private void btnBanHang_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender);
            HienThiUserControl(new ucBanHang());
        }

        private void btnTraCuuSach_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            HienThiUserControl(new ucTraCuuSach());
        }

        private void btnPhieuThuTien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            HienThiUserControl(new ucPhieuThuTien());
        }

        // 🔥 CHẶN CỨNG BÁO CÁO THÁNG
        private void btnBaoCaoThang_Click(object sender, EventArgs e)
        {
            if (QuyenTruyCap != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập báo cáo!");
                return;
            }

            ActivateButton(sender);
            HienThiUserControl(new ucBaoCaoTon());
        }

        private void btnBaoCaoTon_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            HienThiUserControl(new ucBaoCaoTon());
        }

        private void btnBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            if (QuyenTruyCap != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập!");
                return;
            }
        }

        private void btnThayDoiQuyDinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            ucThayDoiQuyDinh ucQuyDinh = new ucThayDoiQuyDinh();
            ucQuyDinh.QuyenTruyCap = this.QuyenTruyCap;

            HienThiUserControl(ucQuyDinh);
        }

        // =========================
        // 5. BUS QUY ĐỊNH
        // =========================
        public static class QuyDinhBUS
        {
            private static string connStr =
                "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

            public static decimal LaySoTienNoToiDa()
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT TOP 1 NoToiDa FROM QuyDinh";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return 0;

                    return Convert.ToDecimal(result);
                }
            }

            public static int LaySoLuongTonTheoID(int sachID)
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT SoLuong FROM Sach WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", sachID);

                    object result = cmd.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            public static int LaySoLuongNhapToiThieu()
            {
                string connStr = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT TOP 1 SoLuongNhapToiThieu FROM QuyDinh";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    object result = cmd.ExecuteScalar();

                    return result != null && result != DBNull.Value
                        ? Convert.ToInt32(result)
                        : 0;
                }
            }
            public static int LaySoLuongTon(string tenSach)
            {
                string connStr = "Data Source=.;Initial Catalog=QuanLyNhaSach;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT SoLuong FROM Sach WHERE TenSach = @TenSach";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenSach", tenSach);

                    object result = cmd.ExecuteScalar();

                    return result != null && result != DBNull.Value
                        ? Convert.ToInt32(result)
                        : 0;
                }
            }
            public static int LaySoLuongTonToiThieuSauBan()
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT TOP 1 TonToiThieuSauBan FROM QuyDinh";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    object result = cmd.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }
    }
}
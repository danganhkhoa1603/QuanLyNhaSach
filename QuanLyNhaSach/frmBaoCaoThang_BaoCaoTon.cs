using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class frmBaoCaoThang_BaoCaoTon : Form
    {
        public frmBaoCaoThang_BaoCaoTon()
        {
            InitializeComponent();
        }

        private Button currentButton;
        private Color activeColor = Color.DeepSkyBlue;
        private Color defaultColor = Color.White;

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

        // --- CHỈNH SỬA VÀ THÊM VÀO CÁC SỰ KIỆN ---

        private void frmBaoCaoThang_BaoCaoTon_Load(object sender, EventArgs e)
        {
            // Mặc định khi vào là trang nhập sách và tô màu nút Nhập Sách
            // Lưu ý: Đảm bảo tên nút trên giao diện của bạn là btnNhapSach
            ActivateButton(btnNhapSach);
            HienThiUserControl(new ucNhapSach());
        }

        private void btnNhapSach_Click(object sender, EventArgs e)
        {
            ActivateButton(sender); // Thêm dòng này để đổi màu
            HienThiUserControl(new ucNhapSach());
        }

        private void btnBanHang_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender); // Thêm dòng này để đổi màu
            HienThiUserControl(new ucBanHang());
        }

        private void btnTraCuuSach_Click(object sender, EventArgs e)
        {
            ActivateButton(sender); // Thêm dòng này để đổi màu
            HienThiUserControl(new ucTraCuuSach());
        }

        private void btnPhieuThuTien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender); // Thêm dòng này để đổi màu
            HienThiUserControl(new ucPhieuThuTien());
        }

        private void btnBaoCaoThang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender); // Thêm dòng này để đổi màu
            HienThiUserControl(new ucBaoCaoTon());
        }

        private void btnThayDoiQuyDinh_Click(object sender, EventArgs e)
        {
            ActivateButton(sender); // Thêm dòng này để đổi màu
            HienThiUserControl(new ucThayDoiQuyDinh());
        }

        // Các phương thức khác bạn đã viết tôi giữ nguyên hoàn toàn phía dưới
        private void btnBaoCaoTon_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            HienThiUserControl(new ucBaoCaoTon());
        }

        private void btnBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            // HienThiUserControl(new ucBaoCaoCongNo());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ActivateButton(btnNhapSach);
            HienThiUserControl(new ucNhapSach());
        }
    }
}
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
            btnNhapSach_Click(null, null);
        }

        // Hàm dùng chung để hiển thị bất kỳ UserControl nào
        public void HienThiUserControl(UserControl uc)
        {
            // Xóa các UC cũ đang hiển thị
            pnlMain.Controls.Clear();

            // Thiết lập UC mới
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }

        private void frmBaoCaoThang_BaoCaoTon_Load(object sender, EventArgs e)
        {
            // Hiển thị trang mặc định khi vừa mở Form
            HienThiUserControl(new ucNhapSach());
        }

        private void btnBaoCaoTon_Click(object sender, EventArgs e)
        {
            HienThiUserControl(new ucBaoCaoTon());
        }

        private void btnBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có ucBaoCaoCongNo
            // HienThiUserControl(new ucBaoCaoCongNo());
        }

        private void btnBaoCaoThang_Click(object sender, EventArgs e)
        {
            // Gọi hàm dùng chung thay vì viết code khởi tạo Panel thủ công
            HienThiUserControl(new ucBaoCaoTon());
        }

        private void btnThayDoiQuyDinh_Click(object sender, EventArgs e)
        {
            HienThiUserControl(new ucThayDoiQuyDinh());
        }

        // Bạn có thể bổ sung thêm các nút khác tương tự
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            // HienThiUserControl(new ucBanHang());
        }

        private void btnNhapSach_Click(object sender, EventArgs e)
        {
            HienThiUserControl(new ucNhapSach());
        }

        private void btnBanHang_Click_1(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

          
            ucBanHang trangNhap = new ucBanHang();
            trangNhap.Dock = DockStyle.Fill;

            
            pnlMain.Controls.Add(trangNhap);
        }

        private void btnTraCuuSach_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();


            ucTraCuuSach trangNhap = new ucTraCuuSach();
            trangNhap.Dock = DockStyle.Fill;


            pnlMain.Controls.Add(trangNhap);
        }

        private void btnPhieuThuTien_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();


            ucPhieuThuTien trangNhap = new ucPhieuThuTien();
            trangNhap.Dock = DockStyle.Fill;


            pnlMain.Controls.Add(trangNhap);
        }
    }
}

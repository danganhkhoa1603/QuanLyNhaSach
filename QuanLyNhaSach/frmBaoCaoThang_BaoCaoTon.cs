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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCaoTon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã ở trang này rồi!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBaoCaoCongNo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBaoCaoThang_Click(object sender, EventArgs e)
        {
            Panel pnl = this.Controls["pnlMain"] as Panel;
            if (pnl == null)
            {
                // 2. Nếu chưa có thì tạo mới nó
                pnl = new Panel();
                pnl.Name = "pnlMain";
                pnl.Dock = DockStyle.Fill;
                this.Controls.Add(pnl);
                pnl.BringToFront(); // Đưa lên trên để thấy
            }
            // 3. Bây giờ mới bỏ UserControl vào cái Panel vừa tìm/tạo được
            pnl.Controls.Clear();
            ucBaoCaoTon uc = new ucBaoCaoTon();
            uc.Dock = DockStyle.Fill;
            pnl.Controls.Add(uc);
        }

        private void frmBaoCaoThang_BaoCaoTon_Load(object sender, EventArgs e)
        {
            HienThiUserControl(new ucNhapSach());
        }
        public void HienThiUserControl(UserControl uc)
        {
            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
        }
    }
}

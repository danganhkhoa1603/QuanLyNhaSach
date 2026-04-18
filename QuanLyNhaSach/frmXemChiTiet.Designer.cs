namespace QuanLyNhaSach
{
    partial class frmXemChiTiet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colPhieuNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPhieuNhap,
            this.colTenSach,
            this.colTheLoai,
            this.colTacGia,
            this.colDonGia,
            this.colSoLuong,
            this.colThanhTien,
            this.colNgayNhap});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(896, 485);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colPhieuNhap
            // 
            this.colPhieuNhap.HeaderText = "Phiếu Nhập";
            this.colPhieuNhap.MinimumWidth = 6;
            this.colPhieuNhap.Name = "colPhieuNhap";
            this.colPhieuNhap.Width = 125;
            // 
            // colTenSach
            // 
            this.colTenSach.HeaderText = "Tên Sách";
            this.colTenSach.MinimumWidth = 6;
            this.colTenSach.Name = "colTenSach";
            this.colTenSach.Width = 125;
            // 
            // colTheLoai
            // 
            this.colTheLoai.HeaderText = "Thể Loại";
            this.colTheLoai.MinimumWidth = 6;
            this.colTheLoai.Name = "colTheLoai";
            this.colTheLoai.Width = 125;
            // 
            // colTacGia
            // 
            this.colTacGia.HeaderText = "Tác giả";
            this.colTacGia.MinimumWidth = 6;
            this.colTacGia.Name = "colTacGia";
            this.colTacGia.Width = 125;
            // 
            // colDonGia
            // 
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.MinimumWidth = 6;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.Width = 125;
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "Số Lượng";
            this.colSoLuong.MinimumWidth = 6;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Width = 125;
            // 
            // colThanhTien
            // 
            this.colThanhTien.HeaderText = "Thành Tiền";
            this.colThanhTien.MinimumWidth = 6;
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.Width = 125;
            // 
            // colNgayNhap
            // 
            this.colNgayNhap.HeaderText = "Ngày Nhập";
            this.colNgayNhap.MinimumWidth = 6;
            this.colNgayNhap.Name = "colNgayNhap";
            this.colNgayNhap.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmXemChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 485);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmXemChiTiet";
            this.Text = "frmXemChiTiet";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayNhap;
        private System.Windows.Forms.Button button1;
    }
}
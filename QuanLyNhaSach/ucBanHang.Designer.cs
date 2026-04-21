namespace QuanLyNhaSach
{
    partial class ucBanHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThemSachVaHoaDon = new System.Windows.Forms.Button();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTongHoaDon = new System.Windows.Forms.TextBox();
            this.txtTienDaNhan = new System.Windows.Forms.MaskedTextBox();
            this.ucThemThongTinKhachHang1 = new QuanLyNhaSach.ucThemThongTinKhachHang();
            this.ucThongTinChiTietHoaDon1 = new QuanLyNhaSach.ucThongTinChiTietHoaDon();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(660, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "LẬP HÓA ĐƠN BÁN SÁCH";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 727);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tổng hóa đơn:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(698, 730);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tiền đã nhận";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(624, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Họ Tên Khách Hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(996, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày Nhập Hóa Đơn:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1709, 728);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 75);
            this.button1.TabIndex = 5;
            this.button1.Text = "THANH TOÁN VÀ LƯU";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnThemSachVaHoaDon
            // 
            this.btnThemSachVaHoaDon.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSachVaHoaDon.Location = new System.Drawing.Point(1528, 729);
            this.btnThemSachVaHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemSachVaHoaDon.Name = "btnThemSachVaHoaDon";
            this.btnThemSachVaHoaDon.Size = new System.Drawing.Size(175, 73);
            this.btnThemSachVaHoaDon.TabIndex = 5;
            this.btnThemSachVaHoaDon.Text = "THÊM SÁCH VÀO HÓA ĐƠN";
            this.btnThemSachVaHoaDon.UseVisualStyleBackColor = true;
            this.btnThemSachVaHoaDon.Click += new System.EventHandler(this.btnThemSachVaHoaDon_click);
            // 
            // btnThemKH
            // 
            this.btnThemKH.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemKH.Location = new System.Drawing.Point(1328, 730);
            this.btnThemKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(194, 73);
            this.btnThemKH.TabIndex = 5;
            this.btnThemKH.Text = "THÊM THÔNG TIN KHÁCH ";
            this.btnThemKH.UseVisualStyleBackColor = true;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTenSach,
            this.colTheLoai,
            this.colSoLuong,
            this.colDonGia});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(50, 130);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1820, 580);
            this.dataGridView1.TabIndex = 6;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            // 
            // colTenSach
            // 
            this.colTenSach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenSach.HeaderText = "Tên Sách";
            this.colTenSach.MinimumWidth = 6;
            this.colTenSach.Name = "colTenSach";
            // 
            // colTheLoai
            // 
            this.colTheLoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTheLoai.HeaderText = "Thể Loại";
            this.colTheLoai.MinimumWidth = 6;
            this.colTheLoai.Name = "colTheLoai";
            // 
            // colSoLuong
            // 
            this.colSoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSoLuong.HeaderText = "Số Lượng";
            this.colSoLuong.MinimumWidth = 6;
            this.colSoLuong.Name = "colSoLuong";
            // 
            // colDonGia
            // 
            this.colDonGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDonGia.HeaderText = "Đơn Gía";
            this.colDonGia.MinimumWidth = 6;
            this.colDonGia.Name = "colDonGia";
            // 
            // txtTongHoaDon
            // 
            this.txtTongHoaDon.Location = new System.Drawing.Point(206, 728);
            this.txtTongHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongHoaDon.Name = "txtTongHoaDon";
            this.txtTongHoaDon.Size = new System.Drawing.Size(300, 22);
            this.txtTongHoaDon.TabIndex = 10;
            // 
            // txtTienDaNhan
            // 
            this.txtTienDaNhan.Location = new System.Drawing.Point(843, 728);
            this.txtTienDaNhan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTienDaNhan.Name = "txtTienDaNhan";
            this.txtTienDaNhan.Size = new System.Drawing.Size(300, 22);
            this.txtTienDaNhan.TabIndex = 11;
            // 
            // ucThemThongTinKhachHang1
            // 
            this.ucThemThongTinKhachHang1.Location = new System.Drawing.Point(521, 217);
            this.ucThemThongTinKhachHang1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucThemThongTinKhachHang1.Name = "ucThemThongTinKhachHang1";
            this.ucThemThongTinKhachHang1.Size = new System.Drawing.Size(329, 382);
            this.ucThemThongTinKhachHang1.TabIndex = 9;
            this.ucThemThongTinKhachHang1.Visible = false;
            // 
            // ucThongTinChiTietHoaDon1
            // 
            this.ucThongTinChiTietHoaDon1.Location = new System.Drawing.Point(1001, 217);
            this.ucThongTinChiTietHoaDon1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucThongTinChiTietHoaDon1.Name = "ucThongTinChiTietHoaDon1";
            this.ucThongTinChiTietHoaDon1.Size = new System.Drawing.Size(365, 346);
            this.ucThongTinChiTietHoaDon1.TabIndex = 8;
            this.ucThongTinChiTietHoaDon1.Visible = false;
            this.ucThongTinChiTietHoaDon1.Load += new System.EventHandler(this.ucThongTinChiTietHoaDon1_Load);
            // 
            // ucBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucThemThongTinKhachHang1);
            this.Controls.Add(this.ucThongTinChiTietHoaDon1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnThemKH);
            this.Controls.Add(this.btnThemSachVaHoaDon);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTienDaNhan);
            this.Controls.Add(this.txtTongHoaDon);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ucBanHang";
            this.Size = new System.Drawing.Size(1920, 860);
            this.Load += new System.EventHandler(this.ucBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnThemSachVaHoaDon;
        private System.Windows.Forms.Button btnThemKH;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
       
        private ucThongTinChiTietHoaDon ucThongTinChiTietHoaDon1;
        private ucThemThongTinKhachHang ucThemThongTinKhachHang1;
        private System.Windows.Forms.TextBox txtTongHoaDon;
        private System.Windows.Forms.MaskedTextBox txtTienDaNhan;
    }
}

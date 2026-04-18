namespace QuanLyNhaSach
{
    partial class NhapSach
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNhapSach = new System.Windows.Forms.Button();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.btnTraCuuSach = new System.Windows.Forms.Button();
            this.btnPhieuThuTien = new System.Windows.Forms.Button();
            this.btnThayDoiQuyDinh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTheLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNhapSachMoi = new System.Windows.Forms.Button();
            this.btnLichSu = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.panel1.Controls.Add(this.btnThayDoiQuyDinh);
            this.panel1.Controls.Add(this.btnPhieuThuTien);
            this.panel1.Controls.Add(this.btnTraCuuSach);
            this.panel1.Controls.Add(this.btnBanHang);
            this.panel1.Controls.Add(this.btnNhapSach);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 1;
            // 
            // btnNhapSach
            // 
            this.btnNhapSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.btnNhapSach.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapSach.Location = new System.Drawing.Point(146, 27);
            this.btnNhapSach.Name = "btnNhapSach";
            this.btnNhapSach.Size = new System.Drawing.Size(117, 46);
            this.btnNhapSach.TabIndex = 1;
            this.btnNhapSach.Text = "Nhập Sách";
            this.btnNhapSach.UseVisualStyleBackColor = false;
            // 
            // btnBanHang
            // 
            this.btnBanHang.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanHang.Location = new System.Drawing.Point(282, 27);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(110, 46);
            this.btnBanHang.TabIndex = 2;
            this.btnBanHang.Text = "Bán Hàng";
            this.btnBanHang.UseVisualStyleBackColor = true;
            // 
            // btnTraCuuSach
            // 
            this.btnTraCuuSach.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraCuuSach.Location = new System.Drawing.Point(418, 27);
            this.btnTraCuuSach.Name = "btnTraCuuSach";
            this.btnTraCuuSach.Size = new System.Drawing.Size(97, 46);
            this.btnTraCuuSach.TabIndex = 2;
            this.btnTraCuuSach.Text = "Tra cứu sách";
            this.btnTraCuuSach.UseVisualStyleBackColor = true;
            // 
            // btnPhieuThuTien
            // 
            this.btnPhieuThuTien.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhieuThuTien.Location = new System.Drawing.Point(534, 27);
            this.btnPhieuThuTien.Name = "btnPhieuThuTien";
            this.btnPhieuThuTien.Size = new System.Drawing.Size(95, 46);
            this.btnPhieuThuTien.TabIndex = 2;
            this.btnPhieuThuTien.Text = "Phiếu thu tiền";
            this.btnPhieuThuTien.UseVisualStyleBackColor = true;
            // 
            // btnThayDoiQuyDinh
            // 
            this.btnThayDoiQuyDinh.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThayDoiQuyDinh.Location = new System.Drawing.Point(650, 27);
            this.btnThayDoiQuyDinh.Name = "btnThayDoiQuyDinh";
            this.btnThayDoiQuyDinh.Size = new System.Drawing.Size(123, 46);
            this.btnThayDoiQuyDinh.TabIndex = 2;
            this.btnThayDoiQuyDinh.Text = "Thay đổi quy định";
            this.btnThayDoiQuyDinh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(276, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "LẬP PHIẾU NHẬP SÁCH";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTenSach,
            this.colTheLoai,
            this.colTacGia,
            this.colSoLuong});
            this.dataGridView1.Location = new System.Drawing.Point(70, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(673, 195);
            this.dataGridView1.TabIndex = 3;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            // 
            // colTenSach
            // 
            this.colTenSach.HeaderText = "Tên Sách";
            this.colTenSach.MinimumWidth = 6;
            this.colTenSach.Name = "colTenSach";
            // 
            // colTheLoai
            // 
            this.colTheLoai.HeaderText = "Thể Loại";
            this.colTheLoai.MinimumWidth = 6;
            this.colTheLoai.Name = "colTheLoai";
            // 
            // colTacGia
            // 
            this.colTacGia.HeaderText = "Tác Giả";
            this.colTacGia.MinimumWidth = 6;
            this.colTacGia.Name = "colTacGia";
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "Số Lượng";
            this.colSoLuong.MinimumWidth = 6;
            this.colSoLuong.Name = "colSoLuong";
            // 
            // btnNhapSachMoi
            // 
            this.btnNhapSachMoi.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnNhapSachMoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapSachMoi.ForeColor = System.Drawing.Color.Blue;
            this.btnNhapSachMoi.Location = new System.Drawing.Point(592, 372);
            this.btnNhapSachMoi.Name = "btnNhapSachMoi";
            this.btnNhapSachMoi.Size = new System.Drawing.Size(172, 66);
            this.btnNhapSachMoi.TabIndex = 4;
            this.btnNhapSachMoi.Text = "+Nhập Sách Mới";
            this.btnNhapSachMoi.UseVisualStyleBackColor = false;
            this.btnNhapSachMoi.Click += new System.EventHandler(this.btnNhapSachMoi_Click);
            // 
            // btnLichSu
            // 
            this.btnLichSu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichSu.Location = new System.Drawing.Point(447, 389);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(139, 49);
            this.btnLichSu.TabIndex = 5;
            this.btnLichSu.Text = "Lịch Sử";
            this.btnLichSu.UseVisualStyleBackColor = true;
            this.btnLichSu.Click += new System.EventHandler(this.btnLichSu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyNhaSach.Properties.Resources.LHK;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // NhapSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLichSu);
            this.Controls.Add(this.btnNhapSachMoi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "NhapSach";
            this.Text = "NhapSach";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThayDoiQuyDinh;
        private System.Windows.Forms.Button btnPhieuThuTien;
        private System.Windows.Forms.Button btnTraCuuSach;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Button btnNhapSach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTheLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.Button btnNhapSachMoi;
        private System.Windows.Forms.Button btnLichSu;
    }
}
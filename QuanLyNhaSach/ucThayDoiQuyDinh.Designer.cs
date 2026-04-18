namespace QuanLyNhaSach
{
    partial class ucThayDoiQuyDinh
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnKhoiPhucMacDinh = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "THIẾT LẬP QUY ĐỊNH HỆ THỐNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nhập quy định sách";
            // 
            // txt
            // 
            this.txt.AutoCompleteCustomSource.AddRange(new string[] {
            "Lượng nhập ít nhất (Mặc định: 150)"});
            this.txt.Location = new System.Drawing.Point(6, 55);
            this.txt.Margin = new System.Windows.Forms.Padding(2);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(278, 25);
            this.txt.TabIndex = 15;
            this.txt.Text = "Lượng nhập ít nhất (Mặc định: 150)";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(410, 55);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(304, 25);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "Lượng tồn ít nhất sau khi bán (Mặc định: 20)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(407, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Quy định bán sách";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(212, 151);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(273, 25);
            this.textBox3.TabIndex = 19;
            this.textBox3.Text = "Cho phép thu vượt quá số tiền nợ? (Bật/Tắt)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(209, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Quy định thu tiền";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(410, 84);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(304, 25);
            this.textBox4.TabIndex = 20;
            this.textBox4.Text = "Số tiền nợ tối đa (Mặc định: 20.000)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 84);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(278, 25);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "Lượng tồn ít nhất trước khi nhập (Mặc định: < 300)";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(454, 218);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(106, 33);
            this.btnCapNhat.TabIndex = 22;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // btnKhoiPhucMacDinh
            // 
            this.btnKhoiPhucMacDinh.Location = new System.Drawing.Point(298, 218);
            this.btnKhoiPhucMacDinh.Name = "btnKhoiPhucMacDinh";
            this.btnKhoiPhucMacDinh.Size = new System.Drawing.Size(123, 33);
            this.btnKhoiPhucMacDinh.TabIndex = 23;
            this.btnKhoiPhucMacDinh.Text = "Khôi Phục Mặc Định";
            this.btnKhoiPhucMacDinh.UseVisualStyleBackColor = true;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(156, 218);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(106, 33);
            this.btnDangXuat.TabIndex = 24;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            // 
            // ucThayDoiQuyDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnKhoiPhucMacDinh);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucThayDoiQuyDinh";
            this.Size = new System.Drawing.Size(718, 284);
            this.Load += new System.EventHandler(this.ucThayDoiQuyDinh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnKhoiPhucMacDinh;
        private System.Windows.Forms.Button btnDangXuat;
    }
}

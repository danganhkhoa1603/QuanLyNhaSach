namespace QuanLyNhaSach
{
    partial class ucBaoCaoTon
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
            this.btnBaoCaoTon = new System.Windows.Forms.Button();
            this.btnBaoCaoCongNo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhatSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonCuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBaoCaoTon
            // 
            this.btnBaoCaoTon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCaoTon.Location = new System.Drawing.Point(428, 229);
            this.btnBaoCaoTon.Name = "btnBaoCaoTon";
            this.btnBaoCaoTon.Size = new System.Drawing.Size(105, 33);
            this.btnBaoCaoTon.TabIndex = 11;
            this.btnBaoCaoTon.Text = "Báo Cáo Tồn";
            this.btnBaoCaoTon.UseVisualStyleBackColor = true;
            // 
            // btnBaoCaoCongNo
            // 
            this.btnBaoCaoCongNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCaoCongNo.Location = new System.Drawing.Point(556, 229);
            this.btnBaoCaoCongNo.Name = "btnBaoCaoCongNo";
            this.btnBaoCaoCongNo.Size = new System.Drawing.Size(115, 33);
            this.btnBaoCaoCongNo.TabIndex = 12;
            this.btnBaoCaoCongNo.Text = "Báo Cáo Công Nợ";
            this.btnBaoCaoCongNo.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colTenSach,
            this.colTonDau,
            this.colPhatSinh,
            this.colTonCuoi});
            this.dataGridView1.Location = new System.Drawing.Point(30, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(641, 163);
            this.dataGridView1.TabIndex = 10;
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
            // colTonDau
            // 
            this.colTonDau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTonDau.HeaderText = "Tồn Đầu";
            this.colTonDau.MinimumWidth = 6;
            this.colTonDau.Name = "colTonDau";
            // 
            // colPhatSinh
            // 
            this.colPhatSinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPhatSinh.HeaderText = "Phát Sinh";
            this.colPhatSinh.MinimumWidth = 6;
            this.colPhatSinh.Name = "colPhatSinh";
            // 
            // colTonCuoi
            // 
            this.colTonCuoi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTonCuoi.HeaderText = "Tồn Cuối";
            this.colTonCuoi.MinimumWidth = 6;
            this.colTonCuoi.Name = "colTonCuoi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Báo cáo tồn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "BÁO CÁO ĐỊNH KỲ THÁNG";
            // 
            // ucBaoCaoTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBaoCaoTon);
            this.Controls.Add(this.btnBaoCaoCongNo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucBaoCaoTon";
            this.Size = new System.Drawing.Size(718, 284);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBaoCaoTon;
        private System.Windows.Forms.Button btnBaoCaoCongNo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTonDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhatSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTonCuoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

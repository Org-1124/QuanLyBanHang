namespace QuanLyBanHang
{
    partial class frmHangHoa
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenHangHoa = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtSoLuongCon = new System.Windows.Forms.TextBox();
            this.grThongTin = new System.Windows.Forms.GroupBox();
            this.txtIDHangHoa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grdata = new System.Windows.Forms.GroupBox();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.grThongTin.SuspendLayout();
            this.grdata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên hàng hóa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(589, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng còn";
            // 
            // txtTenHangHoa
            // 
            this.txtTenHangHoa.Location = new System.Drawing.Point(314, 44);
            this.txtTenHangHoa.Name = "txtTenHangHoa";
            this.txtTenHangHoa.Size = new System.Drawing.Size(89, 20);
            this.txtTenHangHoa.TabIndex = 3;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(489, 44);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(94, 20);
            this.txtDonGia.TabIndex = 4;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // txtSoLuongCon
            // 
            this.txtSoLuongCon.Location = new System.Drawing.Point(664, 44);
            this.txtSoLuongCon.Name = "txtSoLuongCon";
            this.txtSoLuongCon.Size = new System.Drawing.Size(88, 20);
            this.txtSoLuongCon.TabIndex = 5;
            // 
            // grThongTin
            // 
            this.grThongTin.Controls.Add(this.txtIDHangHoa);
            this.grThongTin.Controls.Add(this.label4);
            this.grThongTin.Controls.Add(this.txtTimKiem);
            this.grThongTin.Controls.Add(this.btnTimKiem);
            this.grThongTin.Controls.Add(this.btnLuu);
            this.grThongTin.Controls.Add(this.btnXoa);
            this.grThongTin.Controls.Add(this.btnSua);
            this.grThongTin.Controls.Add(this.btnThem);
            this.grThongTin.Controls.Add(this.label1);
            this.grThongTin.Controls.Add(this.txtSoLuongCon);
            this.grThongTin.Controls.Add(this.txtTenHangHoa);
            this.grThongTin.Controls.Add(this.label3);
            this.grThongTin.Controls.Add(this.txtDonGia);
            this.grThongTin.Controls.Add(this.label2);
            this.grThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grThongTin.Location = new System.Drawing.Point(0, 0);
            this.grThongTin.Name = "grThongTin";
            this.grThongTin.Size = new System.Drawing.Size(776, 147);
            this.grThongTin.TabIndex = 6;
            this.grThongTin.TabStop = false;
            this.grThongTin.Text = "Thông tin hàng hóa";
            // 
            // txtIDHangHoa
            // 
            this.txtIDHangHoa.Location = new System.Drawing.Point(83, 44);
            this.txtIDHangHoa.Name = "txtIDHangHoa";
            this.txtIDHangHoa.Size = new System.Drawing.Size(100, 20);
            this.txtIDHangHoa.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "ID Hàng";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(15, 104);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(168, 20);
            this.txtTimKiem.TabIndex = 11;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(202, 102);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.Text = "Tìm Kiếm ";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(355, 104);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(695, 104);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(584, 104);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(471, 104);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // grdata
            // 
            this.grdata.Controls.Add(this.dgvHangHoa);
            this.grdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdata.Location = new System.Drawing.Point(0, 147);
            this.grdata.Name = "grdata";
            this.grdata.Size = new System.Drawing.Size(776, 213);
            this.grdata.TabIndex = 7;
            this.grdata.TabStop = false;
            this.grdata.Text = "Data";
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHangHoa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHangHoa.Location = new System.Drawing.Point(3, 16);
            this.dgvHangHoa.MultiSelect = false;
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.ReadOnly = true;
            this.dgvHangHoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHangHoa.Size = new System.Drawing.Size(770, 194);
            this.dgvHangHoa.TabIndex = 0;
            this.dgvHangHoa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellContentClick);
            // 
            // frmHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 360);
            this.Controls.Add(this.grdata);
            this.Controls.Add(this.grThongTin);
            this.Name = "frmHangHoa";
            this.Text = "Quản Lý Hàng Hóa";
            this.Load += new System.EventHandler(this.frmHangHoa_Load);
            this.grThongTin.ResumeLayout(false);
            this.grThongTin.PerformLayout();
            this.grdata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenHangHoa;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtSoLuongCon;
        private System.Windows.Forms.GroupBox grThongTin;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox grdata;
        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.TextBox txtIDHangHoa;
        private System.Windows.Forms.Label label4;
    }
}
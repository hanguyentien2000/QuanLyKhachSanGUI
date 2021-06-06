
namespace BTL.GUI
{
    partial class formThongKeHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHoaDon = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDatPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienDatCoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThaiDatPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2DateTimePicker2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbxTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.btnXemCTDV = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSoHD = new System.Windows.Forms.Label();
            this.lblTien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvHoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvHoaDon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoaDon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.ColumnHeadersHeight = 30;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHoaDon,
            this.MaDatPhong,
            this.TenNhanVien,
            this.TenKhachHang,
            this.MaPhong,
            this.NgayDat,
            this.NgayDen,
            this.NgayDi,
            this.TienDatCoc,
            this.TrangThaiDatPhong,
            this.NgayLap,
            this.TongTien});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoaDon.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHoaDon.EnableHeadersVisualStyles = false;
            this.dgvHoaDon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHoaDon.Location = new System.Drawing.Point(15, 115);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(894, 299);
            this.dgvHoaDon.TabIndex = 23;
            this.dgvHoaDon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoaDon.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHoaDon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHoaDon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHoaDon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHoaDon.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoaDon.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHoaDon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvHoaDon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHoaDon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvHoaDon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHoaDon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvHoaDon.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvHoaDon.ThemeStyle.ReadOnly = true;
            this.dgvHoaDon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHoaDon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoaDon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvHoaDon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHoaDon.ThemeStyle.RowsStyle.Height = 22;
            this.dgvHoaDon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHoaDon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHoaDon.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_RowEnter);
            // 
            // MaHoaDon
            // 
            this.MaHoaDon.DataPropertyName = "MaHoaDon";
            this.MaHoaDon.HeaderText = "Mã HD";
            this.MaHoaDon.Name = "MaHoaDon";
            this.MaHoaDon.ReadOnly = true;
            // 
            // MaDatPhong
            // 
            this.MaDatPhong.DataPropertyName = "MaDatPhong";
            this.MaDatPhong.HeaderText = "Mã đặt";
            this.MaDatPhong.Name = "MaDatPhong";
            this.MaDatPhong.ReadOnly = true;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Tên NV";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.ReadOnly = true;
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.DataPropertyName = "TenKhachHang";
            this.TenKhachHang.HeaderText = "Tên KH";
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.ReadOnly = true;
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã phòng";
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.ReadOnly = true;
            // 
            // NgayDat
            // 
            this.NgayDat.DataPropertyName = "NgayDat";
            this.NgayDat.HeaderText = "Ngày đặt";
            this.NgayDat.Name = "NgayDat";
            this.NgayDat.ReadOnly = true;
            // 
            // NgayDen
            // 
            this.NgayDen.DataPropertyName = "NgayDen";
            this.NgayDen.HeaderText = "Ngày đến";
            this.NgayDen.Name = "NgayDen";
            this.NgayDen.ReadOnly = true;
            // 
            // NgayDi
            // 
            this.NgayDi.DataPropertyName = "NgayDi";
            this.NgayDi.HeaderText = "Ngày đi";
            this.NgayDi.Name = "NgayDi";
            this.NgayDi.ReadOnly = true;
            // 
            // TienDatCoc
            // 
            this.TienDatCoc.DataPropertyName = "TienDatCoc";
            this.TienDatCoc.HeaderText = "Tiền cọc";
            this.TienDatCoc.Name = "TienDatCoc";
            this.TienDatCoc.ReadOnly = true;
            // 
            // TrangThaiDatPhong
            // 
            this.TrangThaiDatPhong.DataPropertyName = "TrangThaiDatPhong";
            this.TrangThaiDatPhong.HeaderText = "Trạng thái";
            this.TrangThaiDatPhong.Name = "TrangThaiDatPhong";
            this.TrangThaiDatPhong.ReadOnly = true;
            // 
            // NgayLap
            // 
            this.NgayLap.DataPropertyName = "NgayLap";
            this.NgayLap.HeaderText = "Ngày lập";
            this.NgayLap.Name = "NgayLap";
            this.NgayLap.ReadOnly = true;
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng";
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Đến ngày";
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.CheckedState.Parent = this.guna2DateTimePicker1;
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker1.HoverState.Parent = this.guna2DateTimePicker1;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(18, 50);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.ShadowDecoration.Parent = this.guna2DateTimePicker1;
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(173, 26);
            this.guna2DateTimePicker1.TabIndex = 37;
            this.guna2DateTimePicker1.Value = new System.DateTime(2021, 5, 23, 1, 2, 33, 791);
            // 
            // guna2DateTimePicker2
            // 
            this.guna2DateTimePicker2.CheckedState.Parent = this.guna2DateTimePicker2;
            this.guna2DateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker2.HoverState.Parent = this.guna2DateTimePicker2;
            this.guna2DateTimePicker2.Location = new System.Drawing.Point(213, 50);
            this.guna2DateTimePicker2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker2.Name = "guna2DateTimePicker2";
            this.guna2DateTimePicker2.ShadowDecoration.Parent = this.guna2DateTimePicker2;
            this.guna2DateTimePicker2.Size = new System.Drawing.Size(176, 26);
            this.guna2DateTimePicker2.TabIndex = 38;
            this.guna2DateTimePicker2.Value = new System.DateTime(2021, 5, 23, 1, 2, 33, 791);
            // 
            // cbxTrangThai
            // 
            this.cbxTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cbxTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTrangThai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxTrangThai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxTrangThai.FocusedState.Parent = this.cbxTrangThai;
            this.cbxTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbxTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbxTrangThai.HoverState.Parent = this.cbxTrangThai;
            this.cbxTrangThai.ItemHeight = 30;
            this.cbxTrangThai.ItemsAppearance.Parent = this.cbxTrangThai;
            this.cbxTrangThai.Location = new System.Drawing.Point(464, 50);
            this.cbxTrangThai.Name = "cbxTrangThai";
            this.cbxTrangThai.ShadowDecoration.Parent = this.cbxTrangThai;
            this.cbxTrangThai.Size = new System.Drawing.Size(174, 36);
            this.cbxTrangThai.TabIndex = 39;
            this.cbxTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbxTrangThai_SelectedIndexChanged);
            // 
            // btnThongKe
            // 
            this.btnThongKe.CheckedState.Parent = this.btnThongKe;
            this.btnThongKe.CustomImages.Parent = this.btnThongKe;
            this.btnThongKe.DisabledState.Parent = this.btnThongKe;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.HoverState.Parent = this.btnThongKe;
            this.btnThongKe.Location = new System.Drawing.Point(825, 50);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.ShadowDecoration.Parent = this.btnThongKe;
            this.btnThongKe.Size = new System.Drawing.Size(84, 36);
            this.btnThongKe.TabIndex = 40;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnXemCTDV
            // 
            this.btnXemCTDV.CheckedState.Parent = this.btnXemCTDV;
            this.btnXemCTDV.CustomImages.Parent = this.btnXemCTDV;
            this.btnXemCTDV.DisabledState.Parent = this.btnXemCTDV;
            this.btnXemCTDV.FillColor = System.Drawing.Color.Green;
            this.btnXemCTDV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXemCTDV.ForeColor = System.Drawing.Color.White;
            this.btnXemCTDV.HoverState.Parent = this.btnXemCTDV;
            this.btnXemCTDV.Location = new System.Drawing.Point(716, 50);
            this.btnXemCTDV.Name = "btnXemCTDV";
            this.btnXemCTDV.ShadowDecoration.Parent = this.btnXemCTDV;
            this.btnXemCTDV.Size = new System.Drawing.Size(93, 36);
            this.btnXemCTDV.TabIndex = 41;
            this.btnXemCTDV.Text = "Xem chi tiết dịch vụ";
            this.btnXemCTDV.Click += new System.EventHandler(this.btnXemCTDV_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(461, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Trạng thái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 435);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "Tổng số hoá đơn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 471);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 47;
            this.label5.Text = "Tổng tiền thu về:";
            // 
            // lblSoHD
            // 
            this.lblSoHD.AutoSize = true;
            this.lblSoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoHD.Location = new System.Drawing.Point(141, 435);
            this.lblSoHD.Name = "lblSoHD";
            this.lblSoHD.Size = new System.Drawing.Size(26, 16);
            this.lblSoHD.TabIndex = 48;
            this.lblSoHD.Text = "......";
            // 
            // lblTien
            // 
            this.lblTien.AutoSize = true;
            this.lblTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTien.Location = new System.Drawing.Point(141, 471);
            this.lblTien.Name = "lblTien";
            this.lblTien.Size = new System.Drawing.Size(26, 16);
            this.lblTien.TabIndex = 49;
            this.lblTien.Text = "......";
            // 
            // formThongKeHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 580);
            this.Controls.Add(this.lblTien);
            this.Controls.Add(this.lblSoHD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXemCTDV);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.cbxTrangThai);
            this.Controls.Add(this.guna2DateTimePicker2);
            this.Controls.Add(this.guna2DateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHoaDon);
            this.Name = "formThongKeHoaDon";
            this.Text = "formThongKeHoaDon";
            this.Load += new System.EventHandler(this.formThongKeHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker2;
        private Guna.UI2.WinForms.Guna2ComboBox cbxTrangThai;
        private Guna.UI2.WinForms.Guna2Button btnThongKe;
        private Guna.UI2.WinForms.Guna2Button btnXemCTDV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSoHD;
        private System.Windows.Forms.Label lblTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDatPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienDatCoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThaiDatPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
    }
}

namespace BTL.GUI
{
    partial class formCheckOut
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
            this.txtMaPhong = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaKhach = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnConfirmOOD = new Guna.UI2.WinForms.Guna2Button();
            this.btnCheckIn = new Guna.UI2.WinForms.Guna2Button();
            this.btnListToday = new Guna.UI2.WinForms.Guna2Button();
            this.btnOutOfDate = new Guna.UI2.WinForms.Guna2Button();
            this.dgvCheckIn = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaDatPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienDatCoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTatCa = new Guna.UI2.WinForms.Guna2Button();
            this.txtKeyWords = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckIn)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaPhong.DefaultText = "";
            this.txtMaPhong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaPhong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaPhong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaPhong.DisabledState.Parent = this.txtMaPhong;
            this.txtMaPhong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaPhong.Enabled = false;
            this.txtMaPhong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaPhong.FocusedState.Parent = this.txtMaPhong;
            this.txtMaPhong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaPhong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaPhong.HoverState.Parent = this.txtMaPhong;
            this.txtMaPhong.Location = new System.Drawing.Point(354, 473);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.PasswordChar = '\0';
            this.txtMaPhong.PlaceholderText = "ID Phòng";
            this.txtMaPhong.SelectedText = "";
            this.txtMaPhong.ShadowDecoration.Parent = this.txtMaPhong;
            this.txtMaPhong.Size = new System.Drawing.Size(274, 36);
            this.txtMaPhong.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtMaPhong.TabIndex = 70;
            // 
            // txtMaKhach
            // 
            this.txtMaKhach.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaKhach.DefaultText = "";
            this.txtMaKhach.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaKhach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaKhach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKhach.DisabledState.Parent = this.txtMaKhach;
            this.txtMaKhach.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKhach.Enabled = false;
            this.txtMaKhach.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKhach.FocusedState.Parent = this.txtMaKhach;
            this.txtMaKhach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaKhach.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKhach.HoverState.Parent = this.txtMaKhach;
            this.txtMaKhach.Location = new System.Drawing.Point(28, 473);
            this.txtMaKhach.Name = "txtMaKhach";
            this.txtMaKhach.PasswordChar = '\0';
            this.txtMaKhach.PlaceholderText = "ID khách";
            this.txtMaKhach.SelectedText = "";
            this.txtMaKhach.ShadowDecoration.Parent = this.txtMaKhach;
            this.txtMaKhach.Size = new System.Drawing.Size(274, 36);
            this.txtMaKhach.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtMaKhach.TabIndex = 69;
            // 
            // btnConfirmOOD
            // 
            this.btnConfirmOOD.BorderRadius = 20;
            this.btnConfirmOOD.CheckedState.Parent = this.btnConfirmOOD;
            this.btnConfirmOOD.CustomImages.Parent = this.btnConfirmOOD;
            this.btnConfirmOOD.DisabledState.Parent = this.btnConfirmOOD;
            this.btnConfirmOOD.Enabled = false;
            this.btnConfirmOOD.FillColor = System.Drawing.Color.Red;
            this.btnConfirmOOD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmOOD.ForeColor = System.Drawing.Color.White;
            this.btnConfirmOOD.HoverState.Parent = this.btnConfirmOOD;
            this.btnConfirmOOD.Location = new System.Drawing.Point(666, 462);
            this.btnConfirmOOD.Name = "btnConfirmOOD";
            this.btnConfirmOOD.ShadowDecoration.Parent = this.btnConfirmOOD;
            this.btnConfirmOOD.Size = new System.Drawing.Size(150, 47);
            this.btnConfirmOOD.TabIndex = 68;
            this.btnConfirmOOD.Text = "Quá hạn";
            this.btnConfirmOOD.Click += new System.EventHandler(this.btnConfirmOOD_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BorderRadius = 20;
            this.btnCheckIn.CheckedState.Parent = this.btnCheckIn;
            this.btnCheckIn.CustomImages.Parent = this.btnCheckIn;
            this.btnCheckIn.DisabledState.Parent = this.btnCheckIn;
            this.btnCheckIn.Enabled = false;
            this.btnCheckIn.FillColor = System.Drawing.Color.Green;
            this.btnCheckIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.HoverState.Parent = this.btnCheckIn;
            this.btnCheckIn.Location = new System.Drawing.Point(822, 462);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.ShadowDecoration.Parent = this.btnCheckIn;
            this.btnCheckIn.Size = new System.Drawing.Size(150, 47);
            this.btnCheckIn.TabIndex = 67;
            this.btnCheckIn.Text = "Checkin";
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnListToday
            // 
            this.btnListToday.CheckedState.Parent = this.btnListToday;
            this.btnListToday.CustomImages.Parent = this.btnListToday;
            this.btnListToday.DisabledState.Parent = this.btnListToday;
            this.btnListToday.FillColor = System.Drawing.Color.Green;
            this.btnListToday.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListToday.ForeColor = System.Drawing.Color.White;
            this.btnListToday.HoverState.Parent = this.btnListToday;
            this.btnListToday.Location = new System.Drawing.Point(595, 82);
            this.btnListToday.Name = "btnListToday";
            this.btnListToday.ShadowDecoration.Parent = this.btnListToday;
            this.btnListToday.Size = new System.Drawing.Size(212, 36);
            this.btnListToday.TabIndex = 66;
            this.btnListToday.Tag = "";
            this.btnListToday.Text = "Checkin hôm nay";
            this.btnListToday.Click += new System.EventHandler(this.btnListToday_Click);
            // 
            // btnOutOfDate
            // 
            this.btnOutOfDate.CheckedState.Parent = this.btnOutOfDate;
            this.btnOutOfDate.CustomImages.Parent = this.btnOutOfDate;
            this.btnOutOfDate.DisabledState.Parent = this.btnOutOfDate;
            this.btnOutOfDate.FillColor = System.Drawing.Color.Red;
            this.btnOutOfDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutOfDate.ForeColor = System.Drawing.Color.White;
            this.btnOutOfDate.HoverState.Parent = this.btnOutOfDate;
            this.btnOutOfDate.Location = new System.Drawing.Point(392, 82);
            this.btnOutOfDate.Name = "btnOutOfDate";
            this.btnOutOfDate.ShadowDecoration.Parent = this.btnOutOfDate;
            this.btnOutOfDate.Size = new System.Drawing.Size(186, 36);
            this.btnOutOfDate.TabIndex = 61;
            this.btnOutOfDate.Text = "Quá hạn Checkin";
            this.btnOutOfDate.Click += new System.EventHandler(this.btnOutOfDate_Click);
            // 
            // dgvCheckIn
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCheckIn.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCheckIn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCheckIn.BackgroundColor = System.Drawing.Color.White;
            this.dgvCheckIn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCheckIn.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCheckIn.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCheckIn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCheckIn.ColumnHeadersHeight = 21;
            this.dgvCheckIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDatPhong,
            this.MaPhong,
            this.MaNhanVien,
            this.MaKhachHang,
            this.NgayDat,
            this.NgayDi,
            this.TienDatCoc});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCheckIn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCheckIn.EnableHeadersVisualStyles = false;
            this.dgvCheckIn.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCheckIn.Location = new System.Drawing.Point(28, 161);
            this.dgvCheckIn.Name = "dgvCheckIn";
            this.dgvCheckIn.RowHeadersVisible = false;
            this.dgvCheckIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckIn.Size = new System.Drawing.Size(935, 253);
            this.dgvCheckIn.TabIndex = 60;
            this.dgvCheckIn.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCheckIn.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCheckIn.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCheckIn.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCheckIn.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCheckIn.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCheckIn.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCheckIn.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCheckIn.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCheckIn.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCheckIn.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCheckIn.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCheckIn.ThemeStyle.HeaderStyle.Height = 21;
            this.dgvCheckIn.ThemeStyle.ReadOnly = false;
            this.dgvCheckIn.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCheckIn.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCheckIn.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCheckIn.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCheckIn.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCheckIn.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCheckIn.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCheckIn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheckIn_CellClick);
            // 
            // MaDatPhong
            // 
            this.MaDatPhong.DataPropertyName = "MaDatPhong";
            this.MaDatPhong.HeaderText = "Mã đặt phòng";
            this.MaDatPhong.Name = "MaDatPhong";
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Phòng";
            this.MaPhong.Name = "MaPhong";
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã Nhân Viên";
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // MaKhachHang
            // 
            this.MaKhachHang.DataPropertyName = "MaKhachHang";
            this.MaKhachHang.HeaderText = "Mã khách hàng";
            this.MaKhachHang.Name = "MaKhachHang";
            // 
            // NgayDat
            // 
            this.NgayDat.DataPropertyName = "NgayDat";
            this.NgayDat.HeaderText = "Ngày Đặt";
            this.NgayDat.Name = "NgayDat";
            // 
            // NgayDi
            // 
            this.NgayDi.DataPropertyName = "NgayDi";
            this.NgayDi.HeaderText = "Ngày đi";
            this.NgayDi.Name = "NgayDi";
            // 
            // TienDatCoc
            // 
            this.TienDatCoc.DataPropertyName = "TienDatCoc";
            this.TienDatCoc.HeaderText = "Tiền đặt cọc";
            this.TienDatCoc.Name = "TienDatCoc";
            // 
            // btnTatCa
            // 
            this.btnTatCa.CheckedState.Parent = this.btnTatCa;
            this.btnTatCa.CustomImages.Parent = this.btnTatCa;
            this.btnTatCa.DisabledState.Parent = this.btnTatCa;
            this.btnTatCa.FillColor = System.Drawing.SystemColors.Highlight;
            this.btnTatCa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTatCa.ForeColor = System.Drawing.Color.White;
            this.btnTatCa.HoverState.Parent = this.btnTatCa;
            this.btnTatCa.Location = new System.Drawing.Point(822, 82);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.ShadowDecoration.Parent = this.btnTatCa;
            this.btnTatCa.Size = new System.Drawing.Size(125, 36);
            this.btnTatCa.TabIndex = 71;
            this.btnTatCa.Tag = "";
            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKeyWords.DefaultText = "";
            this.txtKeyWords.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtKeyWords.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtKeyWords.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKeyWords.DisabledState.Parent = this.txtKeyWords;
            this.txtKeyWords.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKeyWords.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKeyWords.FocusedState.Parent = this.txtKeyWords;
            this.txtKeyWords.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKeyWords.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKeyWords.HoverState.Parent = this.txtKeyWords;
            this.txtKeyWords.Location = new System.Drawing.Point(392, 24);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.PasswordChar = '\0';
            this.txtKeyWords.PlaceholderText = "";
            this.txtKeyWords.SelectedText = "";
            this.txtKeyWords.ShadowDecoration.Parent = this.txtKeyWords;
            this.txtKeyWords.Size = new System.Drawing.Size(415, 36);
            this.txtKeyWords.TabIndex = 72;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.CheckedState.Parent = this.btnTimKiem;
            this.btnTimKiem.CustomImages.Parent = this.btnTimKiem;
            this.btnTimKiem.DisabledState.Parent = this.btnTimKiem;
            this.btnTimKiem.FillColor = System.Drawing.SystemColors.Highlight;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.HoverState.Parent = this.btnTimKiem;
            this.btnTimKiem.Location = new System.Drawing.Point(822, 24);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.ShadowDecoration.Parent = this.btnTimKiem;
            this.btnTimKiem.Size = new System.Drawing.Size(125, 36);
            this.btnTimKiem.TabIndex = 73;
            this.btnTimKiem.Tag = "";
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // formCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(994, 672);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtKeyWords);
            this.Controls.Add(this.btnTatCa);
            this.Controls.Add(this.txtMaPhong);
            this.Controls.Add(this.txtMaKhach);
            this.Controls.Add(this.btnConfirmOOD);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnListToday);
            this.Controls.Add(this.btnOutOfDate);
            this.Controls.Add(this.dgvCheckIn);
            this.Name = "formCheckOut";
            this.Text = "formCheckOut";
            this.Load += new System.EventHandler(this.formCheckOut_Load);
            this.Click += new System.EventHandler(this.formCheckOut_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtMaPhong;
        private Guna.UI2.WinForms.Guna2TextBox txtMaKhach;
        private Guna.UI2.WinForms.Guna2Button btnConfirmOOD;
        private Guna.UI2.WinForms.Guna2Button btnCheckIn;
        private Guna.UI2.WinForms.Guna2Button btnListToday;
        private Guna.UI2.WinForms.Guna2Button btnOutOfDate;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDatPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienDatCoc;
        private Guna.UI2.WinForms.Guna2Button btnTatCa;
        private Guna.UI2.WinForms.Guna2TextBox txtKeyWords;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
    }
}
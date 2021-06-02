
namespace BTL.GUI
{
    partial class formCheckIn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.txtKeyWords = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnTatCa = new Guna.UI2.WinForms.Guna2Button();
            this.txtMaPhong = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaKhach = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCheckOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnListToday = new Guna.UI2.WinForms.Guna2Button();
            this.dgvCheckOut = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaDatPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienDatCoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckOut)).BeginInit();
            this.SuspendLayout();
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
            this.btnTimKiem.Location = new System.Drawing.Point(815, 31);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.ShadowDecoration.Parent = this.btnTimKiem;
            this.btnTimKiem.Size = new System.Drawing.Size(125, 36);
            this.btnTimKiem.TabIndex = 83;
            this.btnTimKiem.Tag = "";
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
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
            this.txtKeyWords.Location = new System.Drawing.Point(385, 31);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.PasswordChar = '\0';
            this.txtKeyWords.PlaceholderText = "Mã đặt phòng,phòng,khách";
            this.txtKeyWords.SelectedText = "";
            this.txtKeyWords.ShadowDecoration.Parent = this.txtKeyWords;
            this.txtKeyWords.Size = new System.Drawing.Size(415, 36);
            this.txtKeyWords.TabIndex = 82;
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
            this.btnTatCa.Location = new System.Drawing.Point(815, 89);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.ShadowDecoration.Parent = this.btnTatCa;
            this.btnTatCa.Size = new System.Drawing.Size(125, 36);
            this.btnTatCa.TabIndex = 81;
            this.btnTatCa.Tag = "";
            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
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
            this.txtMaPhong.Location = new System.Drawing.Point(347, 480);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.PasswordChar = '\0';
            this.txtMaPhong.PlaceholderText = "ID Phòng";
            this.txtMaPhong.SelectedText = "";
            this.txtMaPhong.ShadowDecoration.Parent = this.txtMaPhong;
            this.txtMaPhong.Size = new System.Drawing.Size(274, 36);
            this.txtMaPhong.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtMaPhong.TabIndex = 80;
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
            this.txtMaKhach.Location = new System.Drawing.Point(21, 480);
            this.txtMaKhach.Name = "txtMaKhach";
            this.txtMaKhach.PasswordChar = '\0';
            this.txtMaKhach.PlaceholderText = "ID khách";
            this.txtMaKhach.SelectedText = "";
            this.txtMaKhach.ShadowDecoration.Parent = this.txtMaKhach;
            this.txtMaKhach.Size = new System.Drawing.Size(274, 36);
            this.txtMaKhach.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtMaKhach.TabIndex = 79;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BorderRadius = 20;
            this.btnCheckOut.CheckedState.Parent = this.btnCheckOut;
            this.btnCheckOut.CustomImages.Parent = this.btnCheckOut;
            this.btnCheckOut.DisabledState.Parent = this.btnCheckOut;
            this.btnCheckOut.Enabled = false;
            this.btnCheckOut.FillColor = System.Drawing.Color.Green;
            this.btnCheckOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.HoverState.Parent = this.btnCheckOut;
            this.btnCheckOut.Location = new System.Drawing.Point(815, 469);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.ShadowDecoration.Parent = this.btnCheckOut;
            this.btnCheckOut.Size = new System.Drawing.Size(150, 47);
            this.btnCheckOut.TabIndex = 77;
            this.btnCheckOut.Text = "Checkin";
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
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
            this.btnListToday.Location = new System.Drawing.Point(588, 89);
            this.btnListToday.Name = "btnListToday";
            this.btnListToday.ShadowDecoration.Parent = this.btnListToday;
            this.btnListToday.Size = new System.Drawing.Size(212, 36);
            this.btnListToday.TabIndex = 76;
            this.btnListToday.Tag = "";
            this.btnListToday.Text = "Checkout hôm nay";
            this.btnListToday.Click += new System.EventHandler(this.btnListToday_Click);
            // 
            // dgvCheckOut
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.dgvCheckOut.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvCheckOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCheckOut.BackgroundColor = System.Drawing.Color.White;
            this.dgvCheckOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCheckOut.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCheckOut.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCheckOut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvCheckOut.ColumnHeadersHeight = 21;
            this.dgvCheckOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDatPhong,
            this.MaPhong,
            this.MaNhanVien,
            this.MaKhachHang,
            this.NgayDat,
            this.NgayDen,
            this.NgayDi,
            this.TienDatCoc});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCheckOut.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvCheckOut.EnableHeadersVisualStyles = false;
            this.dgvCheckOut.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCheckOut.Location = new System.Drawing.Point(21, 168);
            this.dgvCheckOut.Name = "dgvCheckOut";
            this.dgvCheckOut.RowHeadersVisible = false;
            this.dgvCheckOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCheckOut.Size = new System.Drawing.Size(935, 253);
            this.dgvCheckOut.TabIndex = 74;
            this.dgvCheckOut.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCheckOut.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCheckOut.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCheckOut.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCheckOut.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCheckOut.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCheckOut.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCheckOut.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCheckOut.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCheckOut.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCheckOut.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCheckOut.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCheckOut.ThemeStyle.HeaderStyle.Height = 21;
            this.dgvCheckOut.ThemeStyle.ReadOnly = false;
            this.dgvCheckOut.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCheckOut.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCheckOut.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCheckOut.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCheckOut.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCheckOut.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCheckOut.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCheckOut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheckOut_CellClick);
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
            this.MaNhanVien.HeaderText = "Mã nhân viên";
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
            this.NgayDat.HeaderText = "Ngày đặt";
            this.NgayDat.Name = "NgayDat";
            // 
            // NgayDen
            // 
            this.NgayDen.DataPropertyName = "NgayDen";
            this.NgayDen.HeaderText = "Ngày đến";
            this.NgayDen.Name = "NgayDen";
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
            // formCheckIn
            // 
            this.ClientSize = new System.Drawing.Size(994, 672);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtKeyWords);
            this.Controls.Add(this.btnTatCa);
            this.Controls.Add(this.txtMaPhong);
            this.Controls.Add(this.txtMaKhach);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnListToday);
            this.Controls.Add(this.dgvCheckOut);
            this.Name = "formCheckIn";
            this.Load += new System.EventHandler(this.formCheckIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckOut)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private Guna.UI2.WinForms.Guna2TextBox txtKeyWords;
        private Guna.UI2.WinForms.Guna2Button btnTatCa;
        private Guna.UI2.WinForms.Guna2TextBox txtMaPhong;
        private Guna.UI2.WinForms.Guna2TextBox txtMaKhach;
        private Guna.UI2.WinForms.Guna2Button btnCheckOut;
        private Guna.UI2.WinForms.Guna2Button btnListToday;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCheckOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDatPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienDatCoc;
    }
}
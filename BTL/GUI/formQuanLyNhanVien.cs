using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.BLL;
using BTL.DTO;
using System.Data;
namespace BTL.InterfaceQuanly
{
    public partial class formQuanLyNhanVien : Form
    {
        NhanVienBLL dsNhanVien = new NhanVienBLL();
        
        public formQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void xoaTrang()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTimKiem.Text = "";
            cbbChucVu.SelectedIndex = 0;
            rdbNam.Checked = true;
            dtpNS.Value = DateTime.Now;
        }

        private void formQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            cbbChucVu.Items.Add("--Chọn chức vụ--");
            cbbChucVu.Items.Add("Admin");
            cbbChucVu.Items.Add("Quản lý");
            xoaTrang();
            dgvNhanVien.DataSource = dsNhanVien.layTTNhanVien();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = dsNhanVien.layTTNhanVien();
        }
    }
}

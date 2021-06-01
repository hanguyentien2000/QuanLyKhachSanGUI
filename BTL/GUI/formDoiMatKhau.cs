using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.BUS;

namespace BTL.InterfaceNhanVien
{
    public partial class formDoiMatKhau : Form
    {
        string TenDangNhap;
        TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();
        public formDoiMatKhau(String username)
        {
            TenDangNhap = username;
            InitializeComponent();
        }

        private void xoaTrang()
        {
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbHienThi.Checked = false;
        }

        private void formDoiMatKhau_Load(object sender, EventArgs e)
        {
            xoaTrang();
            txtOldPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
            labelUsername.Text = TenDangNhap;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtOldPassword.Text.Trim().Equals(""))
                {
                    throw new Exception("Mật khẩu cũ không được để trống");
                }
                if(!txtOldPassword.Text.Equals(taiKhoanBUS.kiemTraMatKhau(TenDangNhap)))
                {
                    throw new Exception("Mật khẩu cũ không chính xác");
                }
                if(txtNewPassword.Text.Trim().Equals(""))
                {
                    throw new Exception("Mật khẩu mới không được để trống");
                }
                if(txtNewPassword.Text.Equals(txtOldPassword.Text))
                {
                    throw new Exception("Mật khẩu mới không được trùng với mật khẩu cũ");
                }
                if(txtConfirmPassword.Text.Trim().Equals(""))
                {
                    throw new Exception("Xác nhận mật khẩu không được để trống");
                }
                if(!txtConfirmPassword.Text.Equals(txtNewPassword.Text))
                {
                    throw new Exception("Mật khẩu nhập lại không chính xác");
                }
                if (taiKhoanBUS.UpdateMatKhau(TenDangNhap, txtNewPassword.Text))
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xoaTrang();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if(!cbHienThi.Checked)
            {
                txtOldPassword.UseSystemPasswordChar = true;
                txtNewPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
            } else
            {
                txtOldPassword.UseSystemPasswordChar = false;
                txtNewPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
        }
    }
}

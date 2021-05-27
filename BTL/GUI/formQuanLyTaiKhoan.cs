using BTL.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.GUI
{
    public partial class formQuanLyTaiKhoan : Form
    {
        TaiKhoanBUS dsTaiKhoan = new TaiKhoanBUS();
        public formQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void formQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            //dgvTaiKhoan.DataSource = dsTaiKhoan.GetTaiKhoan();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenTK.Text.Equals(""))
                {
                    txtTenTK.Focus();
                    throw new Exception("Tên đăng nhập không được bỏ trống");
                }
                if (txtMatKhau.Text.Equals(""))
                {
                    txtMatKhau.Focus();
                    throw new Exception("Mật khẩu không được bỏ trống");
                }
                else
                {
                    
                }
            }
            catch (Exception)
            {

            }
        }
    }
}

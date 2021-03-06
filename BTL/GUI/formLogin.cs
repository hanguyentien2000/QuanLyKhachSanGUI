using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class formLogin : Form
    {
        public Taikhoan account;
        public formLogin()
        {
            InitializeComponent();
        }
    
        private void btnLogin_Click(object sender, EventArgs e)
        {
            using(dbDataContext db  = new dbDataContext())
            {
                account = (from ac in db.Taikhoans where String.Compare(ac.Username , txtUsername.Text, false) == 0
                                    && String.Compare(ac.Password, txtPassword.Text, false) == 0  select ac ).SingleOrDefault();
                if(account == null)
                {
                    MessageBox.Show("Password incorrect! Please Try Again!","Thông báo!");
                    return;
                }
                if(account.TrangThaiTk == false)
                {
                    MessageBox.Show("Tài khoản này đã bị vô hiệu hoá! Không thể đăng nhập","Cảnh báo!");
                    return;
                }
                else
                {
                    if(account.LoaiTaiKhoan == false && account.TrangThaiTk == true)
                    {
                        formMain form = new formMain(this);
                        form.Tag = account;
                        this.Hide();
                        form.ShowDialog();
                        txtUsername.ResetText();
                        txtPassword.ResetText();
                    }
                    else if(account.LoaiTaiKhoan == true && account.TrangThaiTk == true)
                    {
                        formMainNhanVien frm = new formMainNhanVien(this, account.Username, account.MaNhanVien);
                        frm.Tag = account;
                        this.Hide();
                        frm.ShowDialog();
                        txtUsername.ResetText();
                        txtPassword.ResetText();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có thật sự muốn thoát khỏi ứng dụng???", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
                Application.Exit();
            else
                return;
        }
    }
}

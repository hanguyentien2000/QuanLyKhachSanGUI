using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.InterfaceNhanVien
{
    public partial class formDoiMatKhau : Form
    {
        public formDoiMatKhau()
        {
            InitializeComponent();
        }

        private void formDoiMatKhau_Load(object sender, EventArgs e)
        {
            using(dbDataContext db = new dbDataContext())
            {
                Taikhoan taikhoan = this.Tag as Taikhoan;
                //lbUsername.Text = taikhoan.Username.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using(dbDataContext db = new dbDataContext())
            {
                Taikhoan acc = db.Taikhoans.Where(x => x.Username == lbUsername.Text).SingleOrDefault();
                if(db.Taikhoans.Where(x => x.Password.Equals(txtOldPassword.Text) && x.Username.Equals(lbUsername.Text)).SingleOrDefault() == null)
                {
                    MessageBox.Show("Sai mật khẩu cũ! ");
                    return;
                }
                if(txtNewPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu không được để trống! ");
                    return;
                }
                if(txtNewPassword.Text.ToUpper() != txtNewPassword.Text.ToUpper())
                {
                    MessageBox.Show("Mật khẩu cũ không trùng với mật khẩu mới!");
                    return;
                }
                acc.Password = txtNewPassword.Text;
                db.SubmitChanges();
                MessageBox.Show("Lưu thông tin thành công !");
                this.Close();
            }
        }
    }
}

using BTL.BUS;
using BTL.DTO;
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

        private void xoaTrang()
        {
            txtTenTK.Text = "";
            txtMatKhau.Text = "";
            txtTimKiem.Text = "";
            cbxMaNV.SelectedIndex = 0;
            rdAdmin.Checked = true;
            loadData(dsTaiKhoan.GetTableTaiKhoan());
        }

        private void loadCombo()
        {
            cbxMaNV.DataSource = dsTaiKhoan.GetTableTaiKhoan();

            cbxMaNV.ValueMember = "MaNhanVien";
            cbxMaNV.DisplayMember = "MaNhanVien";
        }

        public void loadData(DataTable dt)
        {
            dgvTaiKhoan.Rows.Clear();
            foreach (DataRow a in dt.Rows)
            {
                dgvTaiKhoan.Rows.Add((string)a.ItemArray[0],
                    (string)a.ItemArray[1],
                    (bool)a.ItemArray[2] ? "Nhân Viên" : "Admin",
                    Int32.Parse(a.ItemArray[3].ToString())
                    );
            }
        }

        private void formQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            loadData(new TaiKhoanBUS().GetTableTaiKhoan());
            loadCombo();
        }
        private void btnThem_Click(object sender, EventArgs e)
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
                if (!rdAdmin.Checked && !rdNhanVien.Checked)
                {
                    throw new Exception("Chưa chọn loại tài khoản");
                }
                else
                {
                    dsTaiKhoan.AddTaiKhoan(txtTenTK.Text, txtMatKhau.Text, rdNhanVien.Checked ? true : false, Convert.ToInt32(cbxMaNV.SelectedValue.ToString()));
                    //MessageBox.Show("Thêm mới Tài Khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadData(dsTaiKhoan.GetTableTaiKhoan());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }


        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            xoaTrang();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                dbDataContext db = new dbDataContext();
                if (txtTimKiem.Text.Equals(""))
                {
                    return;
                }
                else
                    loadData(dsTaiKhoan.SearchTenDangNhap(txtTimKiem.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtTenTK.Visible = true;
            try
            {
                if (dgvTaiKhoan.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm tài khoản trước khi xóa");
                }
                if (txtTenTK.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn tài khoản trước khi xóa");
                }
                else
                {
                    dsTaiKhoan.DeleteTaiKhoan(txtTenTK.Text);
                    MessageBox.Show("Xóa thông tin tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData(dsTaiKhoan.GetTableTaiKhoan());
                    loadCombo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            try
            {
                if (dgvTaiKhoan.Rows.Count == dong + 1)
                {
                    throw new Exception("Dữ liệu trống");
                }
                txtTenTK.Visible = true;

                txtTenTK.Enabled = false;
                txtTenTK.Text = dgvTaiKhoan.Rows[dong].Cells[0].Value.ToString();
                txtMatKhau.Text = dgvTaiKhoan.Rows[dong].Cells[1].Value.ToString();
                if (dgvTaiKhoan.Rows[dong].Cells[2].Value.ToString() == "Admin")
                    rdAdmin.Checked = true;
                else
                    rdNhanVien.Checked = true;
                cbxMaNV.Text = dgvTaiKhoan.Rows[dong].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTaiKhoan.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm tài khoản trước khi sửa");
                }
                if (txtTenTK.Text.Trim().Equals(""))
                {
                    throw new Exception("Vui lòng chọn nhân viên trước khi sửa");
                }
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
                if(!rdAdmin.Checked && !rdNhanVien.Checked)
                {
                    throw new Exception("Chưa chọn loại tài khoản");
                }
                else
                {
                    dsTaiKhoan.UpdateTaiKhoan(txtTenTK.Text, txtMatKhau.Text, rdNhanVien.Checked ? true : false);
                    //MessageBox.Show("Sửa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData(dsTaiKhoan.GetTableTaiKhoan());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
    }
}

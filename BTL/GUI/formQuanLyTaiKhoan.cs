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
        TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO();
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

        private void layThongTinTaiKhoan()
        {
            taiKhoanDTO.Username = txtTenTK.Text;
            taiKhoanDTO.Password = txtMatKhau.Text;
            taiKhoanDTO.LoaiTaiKhoan = rdAdmin.Checked ? 1 : rdNhanVien.Checked ? 0 : 1;
            taiKhoanDTO.MaNhanVien = Convert.ToInt32(cbxMaNV.SelectedValue.ToString());
        }

        private void loadCombo()
        {
            cbxMaNV.DataSource = dsTaiKhoan.GetTableTaiKhoan();

            cbxMaNV.ValueMember = "MaNhanVien";
            cbxMaNV.DisplayMember = "TenNhanVien";
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
                    layThongTinTaiKhoan();
                    dsTaiKhoan.AddTaiKhoan(taiKhoanDTO.Username, taiKhoanDTO.Password, taiKhoanDTO.LoaiTaiKhoan, taiKhoanDTO.MaNhanVien);
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
            loadData(dsTaiKhoan.GetTableTaiKhoan());
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                dbDataContext db = new dbDataContext();
                if (txtTimKiem.Text.Equals(""))
                {
                    throw new Exception("Vui lòng nhập từ khóa tìm kiếm");
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
                    layThongTinTaiKhoan();
                    dsTaiKhoan.UpdateTaiKhoan(taiKhoanDTO.Username, taiKhoanDTO.Password, taiKhoanDTO.LoaiTaiKhoan);
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

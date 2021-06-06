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
        string trangThai, tenDangNhap, loaiTK;
        TaiKhoanBUS dsTaiKhoan = new TaiKhoanBUS();
        TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO();
        NhanVienBUS nhanVienBUS = new NhanVienBUS();
        public formQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void xoaTrang()
        {
            txtTenTK.Text = "";
            txtMatKhau.Text = "";
            txtTimKiem.Text = "";
            rdAdmin.Checked = true;
            loadData(dsTaiKhoan.GetTableTaiKhoan());
        }

        private void layThongTinTaiKhoan()
        {
            taiKhoanDTO.Username = txtTenTK.Text;
            taiKhoanDTO.Password = txtMatKhau.Text;
            taiKhoanDTO.LoaiTaiKhoan = rdAdmin.Checked ? 1 : rdNhanVien.Checked ? 0 : 1;
            taiKhoanDTO.MaNhanVien = Convert.ToInt32(cbxMaNV.SelectedValue.ToString());
            taiKhoanDTO.TrangThai = 1;
        }

        private void loadCombo()
        {
            cbxMaNV.ValueMember = "MaNhanVien";
            cbxMaNV.DisplayMember = "MaNhanVien";
            cbxMaNV.DataSource = nhanVienBUS.layTTNhanVien();
        }

        public void loadData(DataTable dt)
        {
            dgvTaiKhoan.Rows.Clear();
            foreach (DataRow a in dt.Rows)
            {
                dgvTaiKhoan.Rows.Add((string)a.ItemArray[0],
                    (string)a.ItemArray[1],
                    (bool)a.ItemArray[2] ? "Nhân Viên" : "Admin",
                    (bool)a.ItemArray[3] ? "Hoạt động" : "Vô hiệu hóa",
                    (int)a.ItemArray[4]
                    );
            }
        }

        private void formQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            loadData(new TaiKhoanBUS().GetTableTaiKhoan());
            loadCombo();
            dgvTaiKhoan.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgvTaiKhoan.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            xoaTrang();
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

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTaiKhoan.ReadOnly = true;
            int dong = e.RowIndex;
            try
            {
                if (dong < 0)
                {
                    throw new Exception("Ô này không có dữ liệu");
                }
                txtTenTK.Visible = true;
                txtTenTK.Enabled = false;
                txtTenTK.Text = dgvTaiKhoan.Rows[dong].Cells[0].Value.ToString();
                tenDangNhap = dgvTaiKhoan.Rows[dong].Cells[0].Value.ToString();
                txtMatKhau.Text = dgvTaiKhoan.Rows[dong].Cells[1].Value.ToString();
                groupTypeAccount.Enabled = false;
                if (dgvTaiKhoan.Rows[dong].Cells[0].Value.ToString() == "admin")
                {
                    btnChangedStatus.Visible = false;
                    btnChangedTypeAccount.Visible = false;
                    
                }
                else
                {
                    btnChangedStatus.Visible = true;
                    btnChangedTypeAccount.Visible = true;
                }
                if (dgvTaiKhoan.Rows[dong].Cells[2].Value.ToString() == "Admin")
                {
                    rdAdmin.Checked = true;
                    loaiTK = "Admin";
              
                }
                else
                {
                    rdNhanVien.Checked = true;
                    loaiTK = "Nhân viên";
                }
                cbxMaNV.Text = dgvTaiKhoan.Rows[dong].Cells[4].Value.ToString();
                trangThai = dgvTaiKhoan.Rows[dong].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData(dsTaiKhoan.GetTableTaiKhoan());
            xoaTrang();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtTenTK.Enabled = true;
            try
            {
                if (dsTaiKhoan.kiemTraNhanVienCoTK(Int32.Parse(cbxMaNV.SelectedValue.ToString())) == 0)
                {
                    throw new Exception("Nhân viên này đã có tài khoản");
                }
                if (txtTenTK.Text.Equals(tenDangNhap))
                {
                    throw new Exception("Tên đăng nhập đã tồn tại");
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
                else
                {
                    layThongTinTaiKhoan();
                    if (dsTaiKhoan.AddTaiKhoan(taiKhoanDTO.Username, taiKhoanDTO.Password, taiKhoanDTO.LoaiTaiKhoan, taiKhoanDTO.TrangThai, taiKhoanDTO.MaNhanVien))
                    {
                        MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData(dsTaiKhoan.GetTableTaiKhoan());
                        xoaTrang();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangedStatus_Click(object sender, EventArgs e)
        {
            txtTenTK.Visible = true;
            try
            {
                if (dgvTaiKhoan.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm tài khoản trước khi đổi trạng thái");
                }
                if (txtTenTK.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn tài khoản trước khi đổi trạng thái");
                }
                DialogResult result = MessageBox.Show("Bạn có muốn đổi trạng thái " + txtTenTK.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    layThongTinTaiKhoan();
                    if (trangThai.Equals("Hoạt động"))
                    {
                        taiKhoanDTO.TrangThai = 0;
                    }
                    else if (trangThai.Equals("Vô hiệu hóa"))
                    {
                        taiKhoanDTO.TrangThai = 1;
                    }
                    if (dsTaiKhoan.UpdateTaiKhoan(taiKhoanDTO.Username, taiKhoanDTO.Password, taiKhoanDTO.LoaiTaiKhoan, taiKhoanDTO.TrangThai))
                    {
                        MessageBox.Show("Thay đổi trạng thái thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData(dsTaiKhoan.GetTableTaiKhoan());
                        xoaTrang();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetpassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTaiKhoan.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm tài khoản trước khi đặt lại mật khẩu");
                }
                if (txtTenTK.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn tài khoản trước khi đặt lại mật khẩu");
                }
                DialogResult result = MessageBox.Show("Bạn có muốn đặt lại mật khẩu của " + txtTenTK.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    layThongTinTaiKhoan();
                    taiKhoanDTO.Password = "1";
                    taiKhoanDTO.TrangThai = trangThai == "Vô hiệu hóa" ? 0 : 1;
                    if (dsTaiKhoan.UpdateTaiKhoan(taiKhoanDTO.Username, taiKhoanDTO.Password, taiKhoanDTO.LoaiTaiKhoan, taiKhoanDTO.TrangThai))
                    {
                        MessageBox.Show("Reset password thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData(dsTaiKhoan.GetTableTaiKhoan());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnChangedTypeAccount_Click(object sender, EventArgs e)
        {
            txtTenTK.Visible = true;
            try
            {
                if (dgvTaiKhoan.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm tài khoản trước khi đổi loại tài khoản");
                }
                if (txtTenTK.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn tài khoản trước khi đổi loại tài khoản");
                }
                
                DialogResult result = MessageBox.Show("Bạn có muốn đổi loại tài khoản của " + txtTenTK.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    layThongTinTaiKhoan();
                    if (loaiTK.Equals("Admin"))
                    {
                        taiKhoanDTO.LoaiTaiKhoan = 1;
                    }
                    else if (loaiTK.Equals("Nhân viên"))
                    {
                        taiKhoanDTO.LoaiTaiKhoan = 0;
                    }
                    if (dsTaiKhoan.UpdateTaiKhoan(taiKhoanDTO.Username, taiKhoanDTO.Password, taiKhoanDTO.LoaiTaiKhoan, taiKhoanDTO.TrangThai))
                    {
                        MessageBox.Show("Thay đổi loại tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData(dsTaiKhoan.GetTableTaiKhoan());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}

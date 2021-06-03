using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.DTO;
using BTL.BUS;
using System.Text.RegularExpressions;

namespace BTL.GUI
{
    public partial class formQuanLyKhachHang : Form
    {
        KhachHangBUS khachHangBUS = new KhachHangBUS();
        KhachHangDTO khachHangDTO = new KhachHangDTO();
        public formQuanLyKhachHang()
        {
            InitializeComponent();
        }
        private void xoaTrang()
        {
            txtMaKH.Visible = false;
            lblMaKH.Visible = false;
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSdt.Text = "";
            txtEmail.Text = "";
            txtDiachi.Text = "";
            txtTimKiem.Text = "";
            txtCMND.Text = "";
            rdbNam.Checked = true;
            dtpNS.Value = DateTime.Now;
            cbxTrangThai.Visible = false;
            lblTrangThai.Visible = false;
        }

        private void layThongTinKhachHang()
        {
            khachHangDTO.HoTen = txtTenKH.Text;
            khachHangDTO.SoDT = txtSdt.Text;
            DateTime date = dtpNS.Value;
            string[] ngaySinh = date.ToShortDateString().Split('/');
            string nam = ngaySinh[2].Substring(0, 4);
            khachHangDTO.NgaySinh = ngaySinh[1] + "/" + ngaySinh[0] + "/" + nam;
            khachHangDTO.Email = txtEmail.Text;
            khachHangDTO.GioiTinh = rdbNam.Checked ? 0 : rdbNu.Checked ? 1 : 0;
            khachHangDTO.DiaChi = txtDiachi.Text;
            khachHangDTO.Cmnd = txtCMND.Text;
            khachHangDTO.TrangThai = 1;
        }
        private void formQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            cbxTrangThai.Items.Add("Khách hàng xấu");
            cbxTrangThai.Items.Add("Khách hàng tốt");
            xoaTrang();
            dgvKhachHang.DataSource = khachHangBUS.layTTKhachHang();
            dgvKhachHang.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgvKhachHang.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = khachHangBUS.layTTKhachHang();
            xoaTrang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKH.Visible = false;
            lblMaKH.Visible = false;
            try
            {
                string regEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                string regPhone = "(84|0[3|5|7|8|9])+([0-9]{8})";
                string regCMND = "^\\d{12}$";
                if (txtTenKH.TextLength == 0)
                {
                    throw new Exception("Tên khách hàng không được để trống");
                }
                if (txtSdt.Text.Trim().Equals(""))
                {
                    throw new Exception("Số điện thoại không được để trống");
                } else if (!Regex.IsMatch(txtSdt.Text, regPhone))
                {
                    throw new Exception("Số điện thoại không đúng định dạng");
                }
                if (dtpNS.Value > DateTime.Now.AddYears(-18))
                {
                    throw new Exception("Khách hàng phải trên 18 tuổi");
                }
                if (txtEmail.TextLength == 0)
                {
                    throw new Exception("Email không được để trống");
                } else if (!Regex.IsMatch(txtEmail.Text, regEmail))
                {
                    throw new Exception("Email không đúng định dạng");
                }
                if (txtDiachi.TextLength == 0)
                {
                    throw new Exception("Địa chỉ không được để trống");
                }
                if (txtCMND.TextLength == 0)
                {
                    throw new Exception("Chứng minh nhân dân không được để trống");
                } else if (!Regex.IsMatch(txtCMND.Text, regCMND))
                {
                    throw new Exception("Chứng minh nhân dân không đúng định dạng");
                } else if (khachHangBUS.kiemTraCMND(txtCMND.Text) == 0)
                {
                    throw new Exception("Đã có thông tin của khách hàng này");
                }
                layThongTinKhachHang();
                if (khachHangBUS.themTTKhachHang(khachHangDTO.HoTen, khachHangDTO.SoDT, khachHangDTO.NgaySinh, khachHangDTO.Email, khachHangDTO.GioiTinh, khachHangDTO.DiaChi, khachHangDTO.Cmnd, khachHangDTO.TrangThai))
                {
                    MessageBox.Show("Thêm mới khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvKhachHang.DataSource = khachHangBUS.layTTKhachHang();
                    xoaTrang();
                }
                else
                {
                    MessageBox.Show("Thêm mới khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaKH.Visible = true;
            lblMaKH.Visible = true;
            string regEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            string regPhone = "(84|0[3|5|7|8|9])+([0-9]{8})";
            string regCMND = "^\\d{12}$";
            try
            {
                if (dgvKhachHang.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm nhân viên trước khi sửa");
                }
                if (txtMaKH.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn mã khách hàng trước khi sửa");
                }
                if (txtTenKH.TextLength == 0)
                {
                    throw new Exception("Tên khách hàng không được để trống");
                }
                if (txtSdt.Text.Trim().Equals(""))
                {
                    throw new Exception("Số điện thoại không được để trống");
                }
                else if (!Regex.IsMatch(txtSdt.Text, regPhone))
                {
                    throw new Exception("Số điện thoại không đúng định dạng");
                }
                if (dtpNS.Value > DateTime.Now.AddYears(-18))
                {
                    throw new Exception("Nhân viên phải trên 18 tuổi");
                }
                if (txtEmail.TextLength == 0)
                {
                    throw new Exception("Email không được để trống");
                }
                else if (!Regex.IsMatch(txtEmail.Text, regEmail))
                {
                    throw new Exception("Email không đúng định dạng");
                }
                if (txtDiachi.TextLength == 0)
                {
                    throw new Exception("Địa chỉ không được để trống");
                }
                if (txtCMND.TextLength == 0)
                {
                    throw new Exception("Chứng minh nhân dân không được để trống");
                }
                else if (!Regex.IsMatch(txtCMND.Text, regCMND))
                {
                    throw new Exception("Chứng minh nhân dân không đúng định dạng");
                }
                layThongTinKhachHang();
                khachHangDTO.TrangThai = cbxTrangThai.SelectedIndex == 1 ? 1 : 0;
                if (khachHangBUS.thayDoiTTKhachHang(Int32.Parse(txtMaKH.Text), khachHangDTO.HoTen, khachHangDTO.SoDT, khachHangDTO.NgaySinh, khachHangDTO.Email, khachHangDTO.GioiTinh, khachHangDTO.DiaChi, khachHangDTO.Cmnd, khachHangDTO.TrangThai))
                {
                    MessageBox.Show("Thay đổi thông tin khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvKhachHang.DataSource = khachHangBUS.layTTKhachHang();
                    xoaTrang();
                }
                else
                {
                    MessageBox.Show("Thay đổi thông tin khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaKH.Visible = true;
            txtMaKH.Visible = true;
            try
            {
                if (dgvKhachHang.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm nhân viên trước khi xóa");
                }
                if (txtMaKH.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn nhân viên trước khi xóa");
                }
                if (khachHangBUS.kiemTraKhachHangDatPhong(Int32.Parse(txtMaKH.Text)) == 0)
                {
                    throw new Exception("Nhân viên đang đặt phòng");
                }
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng " + txtTenKH.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (khachHangBUS.xoaTTKhachHang(Int32.Parse(txtMaKH.Text)))
                    {
                        MessageBox.Show("Xóa thông tin khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvKhachHang.DataSource = khachHangBUS.layTTKhachHang();
                        xoaTrang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thông tin khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTimKiem.TextLength == 0)
                {
                    throw new Exception("Vui lòng nhập từ khóa tìm kiếm");
                }
                DataTable dt = new DataTable();
                dt = khachHangBUS.timKiemTTKhachHang(txtTimKiem.Text);
                if (dt.Rows.Count < 1)
                {
                    throw new Exception("Không tìm thấy dữ liệu với từ khóa: " + txtTimKiem.Text);
                }
                dgvKhachHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvKhachHang.ReadOnly = true;
            cbxTrangThai.Visible = true;
            lblTrangThai.Visible = true;
            int dong = e.RowIndex;
            try
            {
                if (dong < 0)
                {
                    throw new Exception("Ô này không có dữ liệu");
                }
                txtMaKH.Visible = true;
                lblMaKH.Visible = true;
                txtMaKH.Enabled = false;
                txtMaKH.Text = dgvKhachHang.Rows[dong].Cells[0].Value.ToString();
                txtTenKH.Text = dgvKhachHang.Rows[dong].Cells[1].Value.ToString();
                txtSdt.Text = dgvKhachHang.Rows[dong].Cells[2].Value.ToString();
                string[] ngaySinh = dgvKhachHang.Rows[dong].Cells[3].Value.ToString().Split('/');
                string nam = ngaySinh[2].Substring(0, 4);
                dtpNS.Value = new DateTime(Int32.Parse(nam), Int32.Parse(ngaySinh[1]), Int32.Parse(ngaySinh[0]));
                txtEmail.Text = dgvKhachHang.Rows[dong].Cells[4].Value.ToString();
                if (dgvKhachHang.Rows[dong].Cells[5].Value.ToString() == "Nam")
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;
                txtDiachi.Text = dgvKhachHang.Rows[dong].Cells[6].Value.ToString();
                txtCMND.Text = dgvKhachHang.Rows[dong].Cells[7].Value.ToString();
                cbxTrangThai.Text = dgvKhachHang.Rows[dong].Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = khachHangBUS.layTTKhachHang();
            xoaTrang();
        }
    }
}

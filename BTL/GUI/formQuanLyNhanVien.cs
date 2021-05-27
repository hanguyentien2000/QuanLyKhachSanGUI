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
using BTL.DTO;
using System.Text.RegularExpressions;

namespace BTL.InterfaceQuanly
{
    public partial class formQuanLyNhanVien : Form
    {
        NhanVienBUS nhanVienBLL = new NhanVienBUS();
        NhanVienDTO nhanVienDTO = new NhanVienDTO();
        public formQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void xoaTrang()
        {
            txtMaNV.Visible = false;
            lblMaNV.Visible = false;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTimKiem.Text = "";
            cbbChucVu.SelectedIndex = 0;
            rdbNam.Checked = true;
            dtpNS.Value = DateTime.Now;
        }

        private void layThongTinNhanVien()
        {
            nhanVienDTO.MaNV = (nhanVienBLL.layMaxMaNhanVien() + 1);
            nhanVienDTO.HoTen = txtTenNV.Text;
            nhanVienDTO.SoDT = txtSDT.Text;
            nhanVienDTO.GioiTinh = rdbNam.Checked ? 0 : rdbNu.Checked ? 1 : 0;
            nhanVienDTO.DiaChi = txtDiaChi.Text;
            nhanVienDTO.ChucVu = cbbChucVu.Text;
            DateTime date = dtpNS.Value;
            string[] ngaySinh = date.ToShortDateString().Split('/');
            string nam = ngaySinh[2].Substring(0, 4);
            nhanVienDTO.NgaySinh = ngaySinh[1] + "/" + ngaySinh[0] + "/" + nam;
        }

        private void formQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            cbbChucVu.Items.Add("--Chọn chức vụ--");
            cbbChucVu.Items.Add("Admin");
            cbbChucVu.Items.Add("Quản lý");
            xoaTrang();
            dgvNhanVien.DataSource = nhanVienBLL.layTTNhanVien();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nhanVienBLL.layTTNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string reg = "/(84|0[3|5|7|8|9])+([0-9]{8})\b/";
                //if(txtMaNV.Text.Trim().Equals(""))
                //{
                //    throw new Exception("Mã nhân viên không được để trống");
                //}
                if (txtTenNV.Text.Trim().Equals(""))
                {
                    throw new Exception("Tên nhân viên không được để trống");
                }
                if (txtSDT.Text.Trim().Equals(""))
                {
                    throw new Exception("Số điện thoại không được để trống");
                } else if (!Regex.IsMatch(txtSDT.Text, reg))
                {
                    throw new Exception("Số điện thoại không đúng định dạng");
                }
                if (cbbChucVu.SelectedIndex < 1)
                {
                    throw new Exception("Vui lòng chọn chức vụ cho nhân viên");
                }
                if (dtpNS.Value > DateTime.Now.AddYears(-18))
                {
                    throw new Exception("Nhân viên phải trên 18 tuổi");
                }
                if (txtDiaChi.Text.Trim().Equals(""))
                {
                    throw new Exception("Địa chỉ không được để trống");
                }
                layThongTinNhanVien();
                if (nhanVienBLL.themTTNhanVien(nhanVienDTO.HoTen, nhanVienDTO.SoDT, nhanVienDTO.NgaySinh, nhanVienDTO.DiaChi, nhanVienDTO.GioiTinh, nhanVienDTO.ChucVu))
                {
                    MessageBox.Show("Thêm mới nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNhanVien.DataSource = nhanVienBLL.layTTNhanVien();
                    xoaTrang();
                } else
                {
                    MessageBox.Show("Thêm mới nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaNV.Visible = true;
            lblMaNV.Visible = true;
            try
            {
                string reg = "/(84|0[3|5|7|8|9])+([0-9]{8})\b/g";
                if (dgvNhanVien.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm nhân viên trước khi sửa");
                }
                if (txtMaNV.Text.Trim().Equals(""))
                {
                    throw new Exception("Vui lòng chọn nhân viên trước khi sửa");
                }
                if (txtTenNV.Text.Trim().Equals(""))
                {
                    throw new Exception("Tên nhân viên không được để trống");
                }
                if (txtSDT.Text.Trim().Equals(""))
                {
                    throw new Exception("Số điện thoại không được để trống");
                } else if (!Regex.IsMatch(txtSDT.Text, reg))
                {
                    throw new Exception("Số điện thoại không đúng định dạng");
                }
                if (cbbChucVu.SelectedIndex < 1)
                {
                    throw new Exception("Vui lòng chọn chức vụ cho nhân viên");
                }
                if (dtpNS.Value > DateTime.Now.AddYears(-18))
                {
                    throw new Exception("Nhân viên phải trên 18 tuổi");
                }
                if (txtDiaChi.Text.Trim().Equals(""))
                {
                    throw new Exception("Địa chỉ không được để trống");
                }
                layThongTinNhanVien();
                nhanVienDTO.MaNV = Int32.Parse(txtMaNV.Text);
                if (nhanVienBLL.thayDoiTTNhanVien(nhanVienDTO.MaNV, nhanVienDTO.HoTen, nhanVienDTO.SoDT, nhanVienDTO.NgaySinh, nhanVienDTO.DiaChi, nhanVienDTO.GioiTinh, nhanVienDTO.ChucVu))
                {
                    MessageBox.Show("Thay đổi thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNhanVien.DataSource = nhanVienBLL.layTTNhanVien();
                    xoaTrang();
                }
                else
                {
                    MessageBox.Show("Thay đổi thông tin nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            try
            {
                if (dgvNhanVien.Rows.Count == dong + 1)
                {
                    throw new Exception("Dữ liệu trống");
                }
                txtMaNV.Visible = true;
                lblMaNV.Visible = true;
                txtMaNV.Enabled = false;
                txtMaNV.Text = dgvNhanVien.Rows[dong].Cells[0].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[dong].Cells[1].Value.ToString();
                txtSDT.Text = dgvNhanVien.Rows[dong].Cells[2].Value.ToString();
                string[] ngaySinh = dgvNhanVien.Rows[dong].Cells[3].Value.ToString().Split('/');
                string nam = ngaySinh[2].Substring(0, 4);
                dtpNS.Value = new DateTime(Int32.Parse(nam), Int32.Parse(ngaySinh[1]), Int32.Parse(ngaySinh[0]));
                txtDiaChi.Text = dgvNhanVien.Rows[dong].Cells[4].Value.ToString();
                if (dgvNhanVien.Rows[dong].Cells[5].Value.ToString() == "Nam")
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;
                cbbChucVu.Text = dgvNhanVien.Rows[dong].Cells[6].Value.ToString();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtTimKiem.TextLength == 0)
                {
                    throw new Exception("Vui lòng nhập từ khóa tìm kiếm");
                }
                DataTable dt = new DataTable();
                dt = nhanVienBLL.timKiemTTNhanVien(txtTimKiem.Text);
                if (dt.Rows.Count < 1)
                {
                    throw new Exception("Không tìm thấy dữ liệu với từ khóa: " + txtTimKiem.Text);
                }
                dgvNhanVien.DataSource = dt;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaNV.Visible = true;
            lblMaNV.Visible = true;
            nhanVienDTO.MaNV = Int32.Parse(txtMaNV.Text);
            try
            {
                layThongTinNhanVien();
                if (dgvNhanVien.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm nhân viên trước khi xóa");
                }
                if (txtMaNV.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn nhân viên trước khi xóa");
                } else if (nhanVienBLL.kiemTraNhanVienDatPhong(nhanVienDTO.MaNV) != null)
                {
                    throw new Exception("Nhân viên đang đặt phòng");
                }
                if (nhanVienBLL.xoaTTNhanVien(nhanVienDTO.MaNV))
                {
                    MessageBox.Show("Xóa thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNhanVien.DataSource = nhanVienBLL.layTTNhanVien();
                    xoaTrang();
                }
                else
                {
                    MessageBox.Show("Xóa thông tin nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}

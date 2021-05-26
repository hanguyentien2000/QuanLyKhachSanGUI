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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Globalization;
namespace BTL.InterfaceQuanly
{
    public partial class formQuanLyNhanVien : Form
    {
        NhanVienBLL dsNhanVien = new NhanVienBLL();
        public formQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void loadDataTable()
        {
            DataTable dt = new DataTable();
            dt = dsNhanVien.layDSNhanVien();
            dgvNhanVien.DataSource = dt;
        }

        private void formQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            cbbChucVu.Items.Add("--Chọn chức vụ--");
            cbbChucVu.Items.Add("Admin");
            cbbChucVu.Items.Add("Quản lý");
            cbbChucVu.SelectedIndex = 0;
            txtMaNV.Visible = false;
            lblMaNV.Visible = false;
            rdbNam.Checked = true;
            loadDataTable();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string reg = "/(84|0[3|5|7|8|9])+([0-9]{8})\b/g";
                if (txtTenNV.Text.Trim().Equals(""))
                {
                    throw new Exception("Tên nhân viên không được để trống");
                }
                if (txtSDT.Text.Trim().Equals(""))
                {
                    throw new Exception("Số điện thoại không được để trống");
                } else if(Regex.IsMatch(txtSDT.Text.Trim(), reg))
                {
                    throw new Exception("Số điện thoại không đúng định dạng");
                }
                if (txtDiaChi.Text.Trim().Equals(""))
                {
                    throw new Exception("Địa chỉ không được để trống");
                }
                if (cbbChucVu.SelectedIndex < 1)
                {
                    throw new Exception("Vui lòng chọn chức vụ cho nhân viên");
                }
                if(dtpNV.Value > DateTime.Now.AddYears(-18))
                {
                    throw new Exception("Nhân viên phải trên 18 tuổi");
                }
                int gioiTinh = 0;
                if (rdbNam.Checked)
                    gioiTinh = 0;
                else if (rdbNu.Checked)
                    gioiTinh = 1;
                DateTime dateOfBirth = dtpNV.Value;
                string date = dateOfBirth.Date.ToString(new CultureInfo("en-GB")).Split(' ')[0];
                string ngay = date.Substring(0, 2);
                string thang = date.Substring(3, 2);
                string nam = date.Substring(6);
                string ngaySinh = thang + "/" + ngay + "/" + nam;
                if(dsNhanVien.themMoiTTNhanVien(txtTenNV.Text.Trim(), txtSDT.Text.Trim(), ngaySinh, txtDiaChi.Text.Trim(), gioiTinh, cbbChucVu.Text.Trim()))
                {
                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataTable();
                    xoaTrang();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDataTable();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaNV.Visible = true;
            lblMaNV.Visible = true;
            try
            {
                string reg = "/(84|0[3|5|7|8|9])+([0-9]{8})\b/g";
                if(txtMaNV.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn mã nhân viên trước khi sửa");
                }
                if (txtTenNV.Text.Trim().Equals(""))
                {
                    throw new Exception("Tên nhân viên không được để trống");
                }
                if (txtSDT.Text.Trim().Equals(""))
                {
                    throw new Exception("Số điện thoại không được để trống");
                }
                else if (Regex.IsMatch(txtSDT.Text.Trim(), reg))
                {
                    throw new Exception("Số điện thoại không đúng định dạng");
                }
                if (txtDiaChi.Text.Trim().Equals(""))
                {
                    throw new Exception("Địa chỉ không được để trống");
                }
                if (cbbChucVu.SelectedIndex < 1)
                {
                    throw new Exception("Vui lòng chọn chức vụ cho nhân viên");
                }
                if (dtpNV.Value > DateTime.Now.AddYears(-18))
                {
                    throw new Exception("Nhân viên phải trên 18 tuổi");
                }
                int gioiTinh = 0;
                if (rdbNam.Checked)
                    gioiTinh = 0;
                else if (rdbNu.Checked)
                    gioiTinh = 1;
                DateTime dateOfBirth = dtpNV.Value;
                string date = dateOfBirth.Date.ToString(new CultureInfo("en-GB")).Split(' ')[0];
                string ngay = date.Substring(0, 2);
                string thang = date.Substring(3, 2);
                string nam = date.Substring(6);
                string ngaySinh = thang + "/" + ngay + "/" + nam;
                if (dsNhanVien.thayDoiTTNhanVien(Int32.Parse(txtMaNV.Text), txtTenNV.Text.Trim(), txtSDT.Text.Trim(), ngaySinh, txtDiaChi.Text.Trim(), gioiTinh, cbbChucVu.Text.Trim()))
                {
                    MessageBox.Show("Thay đổi thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataTable();
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
                string[] date = dgvNhanVien.Rows[dong].Cells[3].Value.ToString().Split('/');
                string nam = date[2].Substring(0, 4);
                dtpNV.Value = new DateTime(Int32.Parse(nam), Int32.Parse(date[1]), Int32.Parse(date[0]));
                txtDiaChi.Text = dgvNhanVien.Rows[dong].Cells[4].Value.ToString();
                if (dgvNhanVien.Rows[dong].Cells[5].Value.ToString() == "Nam")
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;
                cbbChucVu.Text = dgvNhanVien.Rows[dong].Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtTimKiem.TextLength == 0)
                {
                    throw new Exception("Vui lòng nhập từ khóa cần tìm kiếm");
                } else
                {
                    DataTable dt = new DataTable();
                    dt = dsNhanVien.timKiemTTNhanVien(txtTimKiem.Text);
                    dgvNhanVien.DataSource = dt;
                }

                if (dgvNhanVien.Rows.Count <= 1)
                {
                    throw new Exception("Không tìm thấy kết quả với từ khóa " + txtTimKiem.Text);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaNV.Visible = true;
            lblMaNV.Visible = true;
            try
            {
                if (txtMaNV.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn mã nhân viên trước khi xóa");
                } else if(dsNhanVien.kiemTraMaNhanVien(Int32.Parse(txtMaNV.Text)) == 0)
                {
                    throw new Exception("Nhân viên đang đặt phòng cho khách");
                }
                DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa nhân viên " + txtTenNV.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    if(dsNhanVien.xoaTTNhanVien(Int32.Parse(txtMaNV.Text)))
                    {
                        MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataTable();
                        xoaTrang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoaTrang()
        {
            txtMaNV.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtTenNV.Text = "";
            cbbChucVu.SelectedIndex = 0;
            rdbNam.Checked = true;
            dtpNV.Value = DateTime.Now;
        }
    }
}

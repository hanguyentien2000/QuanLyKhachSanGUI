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
using System.IO;

namespace BTL.InterfaceQuanly
{
    public partial class formQuanLyNhanVien : Form
    {
        string cmnd;
        NhanVienBUS nhanVienBLL = new NhanVienBUS();
        NhanVienDTO nhanVienDTO = new NhanVienDTO();
        ImageConvert imageConvert = new ImageConvert();
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
            txtCMND.Text = "";
            rdbNam.Checked = true;
            datePickerNgaySinh.Value = DateTime.Now;
            imgNV.Image = null;
        }

        private void layThongTinNhanVien()
        {
            nhanVienDTO.HoTen = txtTenNV.Text;
            nhanVienDTO.SoDT = txtSDT.Text;
            nhanVienDTO.GioiTinh = rdbNam.Checked ? 0 : rdbNu.Checked ? 1 : 0;
            nhanVienDTO.DiaChi = txtDiaChi.Text;
            nhanVienDTO.ChucVu = cbbChucVu.Text;
            DateTime dt = datePickerNgaySinh.Value; 
            string s = dt.ToString("yyyy/MM/dd");
            nhanVienDTO.NgaySinh = s;
            nhanVienDTO.Cmnd = txtCMND.Text;
            nhanVienDTO.anhNV = imageConvert.ConvertImageToBytes(imgNV.Image);
        }

        private void loadCombobox()
        {
            cbbChucVu.ValueMember = "ChucVu";
            cbbChucVu.DisplayMember = "ChucVu";
            cbbChucVu.DataSource = nhanVienBLL.layChucVuNhanVien();
        }

        private void formQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            xoaTrang();
            loadCombobox();
            dgvNhanVien.DataSource = nhanVienBLL.layTTNhanVien();
            dgvNhanVien.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgvNhanVien.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvNhanVien.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvNhanVien.ReadOnly = true;
            int dong = e.RowIndex;
            try
            {
                if (dong < 0)
                {
                    throw new Exception("Ô này không có dữ liệu");
                }
                txtMaNV.Visible = true;
                lblMaNV.Visible = true;
                txtMaNV.Enabled = false;
                txtMaNV.Text = dgvNhanVien.Rows[dong].Cells[0].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[dong].Cells[1].Value.ToString();
                txtSDT.Text = dgvNhanVien.Rows[dong].Cells[2].Value.ToString();
               
                datePickerNgaySinh.Value = DateTime.Parse(dgvNhanVien.Rows[dong].Cells[3].Value.ToString());
                txtDiaChi.Text = dgvNhanVien.Rows[dong].Cells[4].Value.ToString();
                if (dgvNhanVien.Rows[dong].Cells[5].Value.ToString() == "Nam")
                    rdbNam.Checked = true;
                else
                    rdbNu.Checked = true;
                txtCMND.Text = dgvNhanVien.Rows[dong].Cells[6].Value.ToString();
                cmnd = dgvNhanVien.Rows[dong].Cells[6].Value.ToString();
                cbbChucVu.Text = dgvNhanVien.Rows[dong].Cells[7].Value.ToString();
                imgNV.Image = imageConvert.ConvertByteArrayToImage(nhanVienBLL.layAnhNV(Int32.Parse(dgvNhanVien.Rows[dong].Cells[0].Value.ToString())).anhNV);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_changeImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png", Multiselect = false })
            {
                ofd.Title = "Chọn ảnh";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        imgNV.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void imgNV_Paint(object sender, PaintEventArgs e)
        {
            if(imgNV.Image == null)
            {
                using (Font myFont = new Font("Segoe UI", 14))
                {
                    e.Graphics.DrawString("Chọn ảnh nhân viên...", myFont, Brushes.Black, new Point(3, 3));
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtMaNV.Visible = false;
            lblMaNV.Visible = false;
            try
            {
                string regPhone = "(84|0[3|5|7|8|9])+([0-9]{8})";
                string regCMND = "^\\d{12}$";
                if (txtTenNV.Text.Trim().Equals(""))
                {
                    throw new Exception("Tên nhân viên không được để trống");
                }
                if (txtSDT.Text.Trim().Equals(""))
                {
                    throw new Exception("Số điện thoại không được để trống");
                }
                else if (!Regex.IsMatch(txtSDT.Text, regPhone))
                {
                    throw new Exception("Số điện thoại không đúng định dạng");
                }
                if (txtCMND.TextLength == 0)
                {
                    throw new Exception("Chứng minh nhân dân không được để trống");
                }
                else if (!Regex.IsMatch(txtCMND.Text, regCMND))
                {
                    throw new Exception("Chứng minh nhân dân không đúng định dạng");
                }
                else if (nhanVienBLL.kiemTraCMND(txtCMND.Text) == 0)
                {
                    txtCMND.Text = "";
                    throw new Exception("Nhân viên đã tồn tại");
                }
                if (datePickerNgaySinh.Value > DateTime.Now.AddYears(-18))
                {
                    throw new Exception("Nhân viên phải trên 18 tuổi");
                }
                if (txtDiaChi.Text.Trim().Equals(""))
                {
                    throw new Exception("Địa chỉ không được để trống");
                }
                if (imgNV.Image == null)
                {
                    throw new Exception("Vui lòng thêm ảnh nhân viên");
                }
                layThongTinNhanVien();
                if (nhanVienBLL.themTTNhanVien(nhanVienDTO.HoTen, nhanVienDTO.SoDT, nhanVienDTO.NgaySinh, nhanVienDTO.DiaChi, nhanVienDTO.GioiTinh, nhanVienDTO.Cmnd, nhanVienDTO.ChucVu, nhanVienDTO.anhNV))
                {
                    MessageBox.Show("Thêm mới nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNhanVien.DataSource = nhanVienBLL.layTTNhanVien();
                    xoaTrang();
                }
                else
                {
                    MessageBox.Show("Thêm mới nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtMaNV.Visible = true;
            lblMaNV.Visible = true;
            try
            {
                string regPhone = "(84|0[3|5|7|8|9])+([0-9]{8})";
                string regCMND = "^\\d{12}$";
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
                }
                else if (!Regex.IsMatch(txtSDT.Text, regPhone))
                {
                    throw new Exception("Số điện thoại không đúng định dạng");
                }
                if (txtCMND.TextLength == 0)
                {
                    throw new Exception("Chứng minh nhân dân không được để trống");
                }
                else if (!Regex.IsMatch(txtCMND.Text, regCMND))
                {
                    throw new Exception("Chứng minh nhân dân không đúng định dạng");
                }
                else if (cmnd != txtCMND.Text && nhanVienBLL.kiemTraCMND(cmnd) == 0)
                {
                    throw new Exception("Chứng minh nhân dân đã tồn tại!");
                }
                if (datePickerNgaySinh.Value > DateTime.Now.AddYears(-18))
                {
                    throw new Exception("Nhân viên phải trên 18 tuổi");
                }
                if (txtDiaChi.Text.Trim().Equals(""))
                {
                    throw new Exception("Địa chỉ không được để trống");
                }
                layThongTinNhanVien();
                nhanVienDTO.MaNV = Int32.Parse(txtMaNV.Text);
                if (nhanVienBLL.thayDoiTTNhanVien(nhanVienDTO.MaNV, nhanVienDTO.HoTen, nhanVienDTO.SoDT, nhanVienDTO.NgaySinh, nhanVienDTO.DiaChi, nhanVienDTO.GioiTinh, nhanVienDTO.Cmnd, nhanVienDTO.ChucVu, nhanVienDTO.anhNV))
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtMaNV.Visible = true;
            lblMaNV.Visible = true;
            try
            {
                if (dgvNhanVien.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm nhân viên trước khi xóa");
                }
                if (txtMaNV.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn nhân viên trước khi xóa");
                }
                if (nhanVienBLL.kiemTraNhanVienDatPhong(Int32.Parse(txtMaNV.Text)) == 0)
                {
                    throw new Exception("Nhân viên đang đặt phòng");
                }
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên " + txtTenNV.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (nhanVienBLL.xoaTTNhanVien(Int32.Parse(txtMaNV.Text)))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nhanVienBLL.layTTNhanVien();
            xoaTrang();
        }

        private void btnFind_Click(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

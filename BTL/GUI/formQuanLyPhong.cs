using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL.BUS;
using BTL.DTO;

namespace BTL
{
    public partial class formQuanLyPhong : Form
    {
        PhongBUS phongBUS = new PhongBUS();
        PhongDTO phongDTO = new PhongDTO();
        LoaiPhongBUS loaiPhongBUS = new LoaiPhongBUS();
        ImageConvert imageConvert = new ImageConvert();

        public formQuanLyPhong()
        {
            InitializeComponent();
        }

        private void xoaTrang()
        {
            txtMaPhong.Visible = false;
            lblMaPhong.Visible = false;
            cbbLoaiPhong.SelectedIndex = 0;
            rbdTrong.Checked = true;
            imgPhong.Image = null;
        }

        private void layThongTinPhong()
        {
            phongDTO.MaLoaiPhong = Int32.Parse(cbbLoaiPhong.SelectedValue.ToString());
            phongDTO.TrangThai = rbdDangSuDung.Checked ? 0 : rbdTrong.Checked ? 1 : 0;
            phongDTO.AnhPhong = imageConvert.ConvertImageToBytes(imgPhong.Image);
        }

        private void formQuanLyPhong_Load(object sender, EventArgs e)
        {
            dgvQuanLyPhong.DataSource = phongBUS.layTTPhong();
            cbbLoaiPhong.ValueMember = "MaLoaiPhong";
            cbbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbbLoaiPhong.DataSource = loaiPhongBUS.GetTableLoaiPhong();
            xoaTrang();
            dgvQuanLyPhong.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgvQuanLyPhong.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
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
                dt = phongBUS.timKiemTTPhong(txtTimKiem.Text);
                if (dt.Rows.Count < 1)
                {
                    throw new Exception("Không tìm thấy dữ liệu với từ khóa: " + txtTimKiem.Text);
                }
                dgvQuanLyPhong.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvQuanLyPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvQuanLyPhong.ReadOnly = true;
            int dong = e.RowIndex;
            try
            {
                if(dong < 0)
                {
                    throw new Exception("Ô này không có dữ liệu");
                }
                txtMaPhong.Visible = true;
                lblMaPhong.Visible = true;
                txtMaPhong.Enabled = false;
                txtMaPhong.Text = dgvQuanLyPhong.Rows[dong].Cells[0].Value.ToString();
                cbbLoaiPhong.Text = dgvQuanLyPhong.Rows[dong].Cells[1].Value.ToString();
                if (dgvQuanLyPhong.Rows[dong].Cells[2].Value.ToString() == "Trống")
                    rbdTrong.Checked = true;
                else
                    rbdDangSuDung.Checked = true;
                imgPhong.Image = imageConvert.ConvertByteArrayToImage(phongBUS.layAnhPhong(Int32.Parse(dgvQuanLyPhong.Rows[dong].Cells[0].Value.ToString())).AnhPhong);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_changeImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png", Multiselect = false })
            {
                ofd.Title = "Chọn ảnh";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        imgPhong.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void imgPhong_Paint(object sender, PaintEventArgs e)
        {
            if (imgPhong.Image == null)
            {
                using (Font myFont = new Font("Segoe UI", 16))
                {
                    e.Graphics.DrawString("Chọn ảnh phòng...", myFont, Brushes.Black, new Point(3, 3));
                }
            }
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
                dt = phongBUS.timKiemTTPhong(txtTimKiem.Text);
                if (dt.Rows.Count < 1)
                {
                    throw new Exception("Không tìm thấy dữ liệu với từ khóa: " + txtTimKiem.Text);
                }
                dgvQuanLyPhong.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            xoaTrang();
            dgvQuanLyPhong.DataSource = phongBUS.layTTPhong();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgPhong.Image == null)
                {
                    throw new Exception("Vui lòng thêm ảnh phòng");
                }
                layThongTinPhong();
                if (phongBUS.themTTPhong(phongDTO.MaLoaiPhong, phongDTO.TrangThai, phongDTO.AnhPhong))
                {
                    MessageBox.Show("Thêm phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvQuanLyPhong.DataSource = phongBUS.layTTPhong();
                    xoaTrang();
                }
                else
                {
                    MessageBox.Show("Thêm phòng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtMaPhong.Visible = true;
            lblMaPhong.Visible = true;
            try
            {
                if (dgvQuanLyPhong.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm dữ liệu phòng trước khi sửa");
                }
                if (txtMaPhong.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn mã phòng trước khi sửa");
                }
                layThongTinPhong();
                if (phongBUS.thayDoiTTPhong(Int32.Parse(txtMaPhong.Text), phongDTO.MaLoaiPhong, phongDTO.TrangThai, phongDTO.AnhPhong))
                {
                    MessageBox.Show("Thay đổi thông tin phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvQuanLyPhong.DataSource = phongBUS.layTTPhong();
                    xoaTrang();
                }
                else
                {
                    MessageBox.Show("Thay đổi thông tin phòng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtMaPhong.Visible = true;
            lblMaPhong.Visible = true;
            try
            {
                if (dgvQuanLyPhong.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm dữ liệu phòng trước khi xóa");
                }
                if (txtMaPhong.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn mã phòng trước khi xóa");
                }
                if (phongBUS.xoaTTPhong(Int32.Parse(txtMaPhong.Text)))
                {
                    MessageBox.Show("Xóa thông tin phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvQuanLyPhong.DataSource = phongBUS.layTTPhong();
                    xoaTrang();
                }
                else
                {
                    MessageBox.Show("Xóa thông tin phòng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

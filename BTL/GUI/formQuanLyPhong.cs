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

namespace BTL
{
    public partial class formQuanLyPhong : Form
    {
        PhongBUS phongBUS = new PhongBUS();
        PhongDTO phongDTO = new PhongDTO();
        LoaiPhongBUS loaiPhongBUS = new LoaiPhongBUS();
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
        }

        private void layThongTinPhong()
        {
            phongDTO.MaPhong = phongBUS.layMaxMaPhong();
            phongDTO.MaLoaiPhong = Int32.Parse(cbbLoaiPhong.SelectedValue.ToString());
            phongDTO.TrangThai = rbdDangSuDung.Checked ? 0 : rbdTrong.Checked ? 1 : 0;
        }

        private void formQuanLyPhong_Load(object sender, EventArgs e)
        {
            dgvQuanLyPhong.DataSource = phongBUS.layTTPhong();
            cbbLoaiPhong.ValueMember = "MaLoaiPhong";
            cbbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbbLoaiPhong.DataSource = loaiPhongBUS.layTTLoaiPhong();
            xoaTrang();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            layThongTinPhong();
            if (phongBUS.themTTPhong(phongDTO.MaLoaiPhong, phongDTO.TrangThai))
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaPhong.Visible = true;
            lblMaPhong.Visible = true;
            try
            {
                if(dgvQuanLyPhong.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm dữ liệu phòng trước khi sửa");
                }
                if (txtMaPhong.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn mã phòng trước khi sửa");
                }
                layThongTinPhong();
                if (phongBUS.thayDoiTTPhong(Int32.Parse(txtMaPhong.Text),phongDTO.MaLoaiPhong, phongDTO.TrangThai))
                {
                    MessageBox.Show("Thay đổi thông tin phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvQuanLyPhong.DataSource = phongBUS.layTTPhong();
                    xoaTrang();
                }
                else
                {
                    MessageBox.Show("Thay đổi thông tin phòng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaPhong.Visible = true;
            lblMaPhong.Visible = true;
            try { 
                if (dgvQuanLyPhong.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm dữ liệu phòng trước khi sửa");
                }
                if (txtMaPhong.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn mã phòng trước khi sửa");
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
            txtMaPhong.Visible = true;
            lblMaPhong.Visible = true;
            txtMaPhong.Enabled = false;
            int dong = e.RowIndex;
            try
            {
                if (dgvQuanLyPhong.Rows.Count == dong + 1)
                {
                    throw new Exception("Dữ liệu trống");
                }
                txtMaPhong.Text = dgvQuanLyPhong.Rows[dong].Cells[0].Value.ToString();
                cbbLoaiPhong.Text = dgvQuanLyPhong.Rows[dong].Cells[1].Value.ToString();
                if (dgvQuanLyPhong.Rows[dong].Cells[2].Value.ToString() == "Trống")
                    rbdTrong.Checked = true;
                else
                    rbdDangSuDung.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

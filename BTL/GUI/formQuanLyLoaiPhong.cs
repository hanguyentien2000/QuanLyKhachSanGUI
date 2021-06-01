using BTL.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.InterfaceQuanly
{
    public partial class formQuanLyLoaiPhong : Form
    {
        LoaiPhongBUS dsLoaiPhong = new LoaiPhongBUS();
        public formQuanLyLoaiPhong()
        {
            InitializeComponent();
        }

        private void formQuanLyLoaiPhong_Load(object sender, EventArgs e)
        {
            lbLoaiPhong.Visible = false;
            txtMaLoaiPhong.Visible = false;
            loadData(dsLoaiPhong.GetTableLoaiPhong());
        }

        public void loadData(DataTable dt)
        {
            dgvQLLP.Rows.Clear();
            foreach (DataRow a in dt.Rows)
            {
                dgvQLLP.Rows.Add((int)a.ItemArray[0],
                    (string)a.ItemArray[1],
                    (int)a.ItemArray[2],
                    (int)a.ItemArray[3]);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
          
            try
            {
              
                if (txtTenLoaiPhong.Text.Equals(""))
                {
                    txtTenLoaiPhong.Focus();
                    throw new Exception("Tên loại phòng không được bỏ trống");
                }
                if (txtSoLuong.Text.Equals(""))
                {
                    txtSoLuong.Focus();
                    throw new Exception("Số lượng không được bỏ trống");
                }
                if (txtDonGia.Text.Equals(""))
                {
                    txtDonGia.Focus();
                    throw new Exception("Đơn giá không được bỏ trống");
                }
                else
                {
                    dsLoaiPhong.AddLoaiPhong(txtTenLoaiPhong.Text, Convert.ToInt32(txtSoLuong.Text), Convert.ToInt32(txtDonGia.Text));
                    MessageBox.Show("Thêm mới loại phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData(dsLoaiPhong.GetTableLoaiPhong());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMaLoaiPhong.Visible = true;
            try
            {
                if (dgvQLLP.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm loại phòng trước khi xóa");
                }
                if (txtMaLoaiPhong.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn loại phòng trước khi xóa");
                }
                else
                {
                    dsLoaiPhong.DeleteLoaiPhong(Convert.ToInt32(txtMaLoaiPhong.Text));
                    //MessageBox.Show("Xóa thông tin loại phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData(dsLoaiPhong.GetTableLoaiPhong());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
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
                    loadData(dsLoaiPhong.SearchLoaiPhong(txtTimKiem.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaLoaiPhong.Text = "";
            txtTenLoaiPhong.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtTimKiem.Text = "";
            loadData(dsLoaiPhong.GetTableLoaiPhong());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLoaiPhong.Text.Equals(""))
                {
                    txtMaLoaiPhong.Focus();
                    throw new Exception("Mã loại phòng không được bỏ trống");
                }
                if (txtTenLoaiPhong.Text.Equals(""))
                {
                    txtTenLoaiPhong.Focus();
                    throw new Exception("Tên loại phòng không được bỏ trống");
                }
                if (txtSoLuong.Text.Equals(""))
                {
                    txtSoLuong.Focus();
                    throw new Exception("Số lượng không được bỏ trống");
                }
                if (txtDonGia.Text.Equals(""))
                {
                    txtDonGia.Focus();
                    throw new Exception("Đơn giá không được bỏ trống");
                }
                else
                {
                    dsLoaiPhong.UpdateLoaiPhong(Convert.ToInt32(txtMaLoaiPhong.Text), txtTenLoaiPhong.Text, Convert.ToInt32(txtSoLuong.Text), Convert.ToInt32(txtDonGia.Text));
                    //MessageBox.Show("Cập nhật loại phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData(dsLoaiPhong.GetTableLoaiPhong());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void dgvQLLP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            try
            {
                if (dgvQLLP.Rows.Count == dong + 1)
                {
                    throw new Exception("Dữ liệu trống");
                }
                lbLoaiPhong.Visible = true;
                txtMaLoaiPhong.Visible = true;
                txtMaLoaiPhong.Enabled = false;
                txtMaLoaiPhong.Text = dgvQLLP.Rows[dong].Cells[0].Value.ToString();
                txtTenLoaiPhong.Text = dgvQLLP.Rows[dong].Cells[1].Value.ToString();
                txtSoLuong.Text = dgvQLLP.Rows[dong].Cells[2].Value.ToString();
                txtDonGia.Text = dgvQLLP.Rows[dong].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

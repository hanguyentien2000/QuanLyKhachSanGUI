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
    public partial class formQuanLyDichVu : Form
    {
        private int donGia;
        public formQuanLyDichVu()
        {
            InitializeComponent();
        }

        private void formQuanLyDichVu_Load(object sender, EventArgs e)
        {
            dgvDichVu.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgvDichVu.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            lbDichVu.Visible = false;
            txtMaDichVu.Visible = false;
            dgvDichVu.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgvDichVu.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            loadData();
        }

        public void loadData()
        {
            dbDataContext dt = new dbDataContext();
            var lstDichVu = from p in dt.DichVus select p;
            dgvDichVu.DataSource = lstDichVu;
        }
        private void xoaTrang()
        {
            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            txtDonGia.Text = "";
            txtTimKiem.Text = "";
            txtMaDichVu.Visible = false;
            lbDichVu.Visible = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            dbDataContext db = new dbDataContext();
            var query = db.DichVus.Where(x => x.TenDichVu.Equals(txtTenDichVu.Text)).SingleOrDefault();
            try
            {
                if (txtTenDichVu.Text.Equals(""))
                {
                    txtTenDichVu.Focus();
                    throw new Exception("Tên loại phòng không được bỏ trống");
                }
                if (txtDonGia.Text.Equals(""))
                {
                    txtDonGia.Focus();
                    throw new Exception("Đơn giá không được bỏ trống");
                }
               
                if (!int.TryParse(txtDonGia.Text, out donGia))
                {
                    throw new Exception("Đơn giá phải là số!");
                }
                if (query != null)
                {
                    MessageBox.Show("Tên dịch vụ đã tồn tại", "Thông báo");
                    return;
                }
                else
                {
                    DichVu dv = new DichVu();
                    dv.TenDichVu = txtTenDichVu.Text;
                    dv.DonGia = Convert.ToInt32(txtDonGia.Text);
                    db.DichVus.InsertOnSubmit(dv);
                    db.SubmitChanges();
                    xoaTrang();
                    loadData();
                    MessageBox.Show("Thêm mới dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            xoaTrang();
            loadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                dbDataContext db = new dbDataContext();
                var query = db.DichVus.Where(x => x.TenDichVu.Equals(txtTenDichVu.Text)).SingleOrDefault();

                if (txtTenDichVu.Text.Equals(""))
                {
                    txtTenDichVu.Focus();
                    throw new Exception("Tên loại phòng không được bỏ trống");
                }
                if (txtDonGia.Text.Equals(""))
                {
                    txtDonGia.Focus();
                    throw new Exception("Đơn giá không được bỏ trống");
                }

                if (!int.TryParse(txtDonGia.Text, out donGia))
                {
                    throw new Exception("Đơn giá phải là số!");
                }
                if (query != null)
                {
                    MessageBox.Show("Tên dịch vụ đã tồn tại", "Thông báo");
                    return;
                }
                else
                {
                    /* dsLoaiPhong.UpdateLoaiPhong(Convert.ToInt32(txtMaLoaiPhong.Text), txtTenLoaiPhong.Text, Convert.ToInt32(txtSoLuong.Text), Convert.ToInt32(txtDonGia.Text))*/
                    //loadData(dsLoaiPhong.GetTableLoaiPhong());
                    var update = db.DichVus.Single(x => x.MaDichVu == Convert.ToInt32(txtMaDichVu.Text));
                    update.TenDichVu = txtTenDichVu.Text;
                    update.DonGia = Convert.ToInt32(txtDonGia.Text);
                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDichVu.Rows.Count < 1)
                {
                    throw new Exception("Vui lòng thêm loại phòng trước khi xóa");
                }
                if (txtMaDichVu.TextLength == 0)
                {
                    throw new Exception("Vui lòng chọn loại phòng trước khi xóa");
                }
                else
                {
                    dbDataContext db = new dbDataContext();
                    var lstDichVu = from s in db.DichVus where s.MaDichVu == Convert.ToInt32(txtMaDichVu.Text) select s;
                    foreach (var item in lstDichVu)
                    {
                        db.DichVus.DeleteOnSubmit(item);
                        db.SubmitChanges();
                    }
                    MessageBox.Show("Xóa thông tin dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
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
                    MessageBox.Show("Bạn chưa nhập dịch vụ cần tìm!", "Thông báo");
                    return;
                }
                else
                {
                    var p = from s in db.DichVus
                            where s.TenDichVu.ToLower().Contains(txtTimKiem.Text)
                            select new { s.MaDichVu, s.TenDichVu, s.DonGia, };
                    dgvDichVu.DataSource = p;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDichVu.ReadOnly = true;
            int dong = e.RowIndex;
            try
            {
                if (dong < 0)
                {
                    throw new Exception("Ô này không có dữ liệu");
                }
                lbDichVu.Visible = true;
                txtMaDichVu.Visible = true;
                txtMaDichVu.Enabled = false;
                txtMaDichVu.Text = dgvDichVu.Rows[dong].Cells[0].Value.ToString();
                txtTenDichVu.Text = dgvDichVu.Rows[dong].Cells[1].Value.ToString();
                txtDonGia.Text = dgvDichVu.Rows[dong].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

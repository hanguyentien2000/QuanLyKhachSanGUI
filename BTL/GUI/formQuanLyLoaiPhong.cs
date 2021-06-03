using BTL.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.InterfaceQuanly
{
    public partial class formQuanLyLoaiPhong : Form
    {
        //LoaiPhongBUS dsLoaiPhong = new LoaiPhongBUS();
        private int soLuong, donGia;
        public formQuanLyLoaiPhong()
        {
            InitializeComponent();
        }

        private void formQuanLyLoaiPhong_Load(object sender, EventArgs e)
        {
            lbLoaiPhong.Visible = false;
            txtMaLoaiPhong.Visible = false;
            //loadData(dsLoaiPhong.GetTableLoaiPhong());
            loadData();
            dgvQLLP.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgvQLLP.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void loadData()
        {
            dbDataContext dt = new dbDataContext();
            var lstPhong = from p in dt.LoaiPhongs select p;
            dgvQLLP.DataSource = lstPhong;
        }

        //public void loadData(DataTable dt)
        //{
        //    dgvQLLP.Rows.Clear();
        //    foreach (DataRow a in dt.Rows)
        //    {
        //        dgvQLLP.Rows.Add((int)a.ItemArray[0],
        //            (string)a.ItemArray[1],
        //            (int)a.ItemArray[2],
        //            (int)a.ItemArray[3]);
        //    }
        //}

        private void btnThem_Click(object sender, EventArgs e)
        {
            dbDataContext db = new dbDataContext();
            var query = db.LoaiPhongs.Where(x => x.TenLoaiPhong.Equals(txtTenLoaiPhong.Text)).SingleOrDefault();
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
                if (!int.TryParse(txtSoLuong.Text, out soLuong))
                {
                    throw new Exception("Số lượng phải là số!");
                }
                if (!int.TryParse(txtDonGia.Text, out donGia))
                {
                    throw new Exception("Đơn giá phải là số!");
                }
                if (query != null)
                {
                    MessageBox.Show("Tên loại phòng đã tồn tại", "Thông báo");
                    return;
                }
                else
                {
                    //SQL
                    //dsLoaiPhong.AddLoaiPhong(txtTenLoaiPhong.Text, Convert.ToInt32(txtSoLuong.Text), Convert.ToInt32(txtDonGia.Text));
                    //loadData(dsLoaiPhong.GetTableLoaiPhong());
                    //LinQ
                    LoaiPhong lp = new LoaiPhong();
                    lp.TenLoaiPhong = txtTenLoaiPhong.Text;
                    lp.SoluongNguoi = Convert.ToInt32(txtSoLuong.Text);
                    lp.GiaPhong = Convert.ToInt32(txtDonGia.Text);
                    db.LoaiPhongs.InsertOnSubmit(lp);
                    db.SubmitChanges();
                    xoaTrang();
                    loadData();
                    MessageBox.Show("Thêm mới loại phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    //dsLoaiPhong.DeleteLoaiPhong(Convert.ToInt32(txtMaLoaiPhong.Text));
                    //loadData(dsLoaiPhong.GetTableLoaiPhong());
                    dbDataContext db = new dbDataContext();
                    var lstPhong = from s in db.LoaiPhongs where s.MaLoaiPhong == Convert.ToInt32(txtMaLoaiPhong.Text) select s;
                    foreach (var item in lstPhong)
                    {
                        db.LoaiPhongs.DeleteOnSubmit(item);
                        db.SubmitChanges();
                    }
                    MessageBox.Show("Xóa thông tin loại phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Bạn chưa nhập loại phòng cần tìm!","Thông báo");
                    return;
                }
                else
                {
                    var p = from s in db.LoaiPhongs where s.TenLoaiPhong.ToLower().Contains(txtTimKiem.Text)
                            select new { s.MaLoaiPhong, s.TenLoaiPhong, s.SoluongNguoi, s.GiaPhong };
                    dgvQLLP.DataSource = p;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }
        private void xoaTrang()
        {
            txtMaLoaiPhong.Text = "";
            txtTenLoaiPhong.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtTimKiem.Text = "";
            txtMaLoaiPhong.Visible = false;
            lbLoaiPhong.Visible = false;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            xoaTrang();
            loadData();
            //loadData(dsLoaiPhong.GetTableLoaiPhong());
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                dbDataContext db = new dbDataContext();
                var query = db.LoaiPhongs.Where(x => x.TenLoaiPhong.Equals(txtTenLoaiPhong.Text)).SingleOrDefault();

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
                if (!int.TryParse(txtSoLuong.Text, out soLuong))
                {
                    throw new Exception("Số lượng phải là số!");
                }
                if (!int.TryParse(txtDonGia.Text, out soLuong))
                {
                    throw new Exception("Đơn giá phải là số!");
                }
                if (query != null)
                {
                    MessageBox.Show("Tên loại phòng đã tồn tại", "Thông báo");
                    return;
                }
                else
                {
                    /* dsLoaiPhong.UpdateLoaiPhong(Convert.ToInt32(txtMaLoaiPhong.Text), txtTenLoaiPhong.Text, Convert.ToInt32(txtSoLuong.Text), Convert.ToInt32(txtDonGia.Text))*/
                    //loadData(dsLoaiPhong.GetTableLoaiPhong());
                    var update = db.LoaiPhongs.Single(x => x.MaLoaiPhong == Convert.ToInt32(txtMaLoaiPhong.Text));
                    update.TenLoaiPhong = txtTenLoaiPhong.Text;
                    update.SoluongNguoi = Convert.ToInt32(txtSoLuong.Text);
                    update.GiaPhong = Convert.ToInt32(txtDonGia.Text);
                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật loại phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
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
                if(dong < 0)
                {
                    throw new Exception("Ô này không có dữ liệu");
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

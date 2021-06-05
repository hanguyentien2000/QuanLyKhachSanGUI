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

namespace BTL.GUI
{
    public partial class formThongKeHoaDon : Form
    {
        HoaDonBUS hd = new HoaDonBUS();
        int dong;
        public formThongKeHoaDon()
        {
            InitializeComponent();
        }

        private void formThongKeHoaDon_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            guna2DataGridView1.DataSource = hd.getAllHoaDonAndDatPhong();
            loadCombo();
        }
        public void loadCombo()
        {
            cbxTrangThai.Items.Add("0");
            cbxTrangThai.Items.Add("1");
            cbxTrangThai.Items.Add("2");
            cbxTrangThai.Items.Add("Tất cả");
            cbxTrangThai.SelectedIndex = 3;
        }
        public void clearLabel()
        {
            lblTien.Text = "......";
            lblSoHD.Text = "......";
        }

        private void guna2DataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            guna2DataGridView1.ReadOnly = true;
            dong = e.RowIndex;
            try
            {
                if(dong <0)
                {
                    throw new Exception("Ô này không có dữ liệu");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearLabel();
            if (cbxTrangThai.Text == "Tất cả")
            {
                guna2DataGridView1.DataSource = hd.getAllHoaDonAndDatPhong();
            }
            else
            {
                int trangthai = Int32.Parse(cbxTrangThai.Text);
                guna2DataGridView1.DataSource = hd.getAllHoaDonAndDatPhongByTrangThai(trangthai);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DateTimePicker1.Value > guna2DateTimePicker2.Value)
                {
                    throw new Exception("Ngày ban đầu không được lớn hơn ngày kết thúc");
                }
                DateTime Ngay1 = guna2DateTimePicker1.Value;
                DateTime Ngay2 = guna2DateTimePicker2.Value;

              
                clearLabel();
                if (cbxTrangThai.Text == "Tất cả")
                {
                    guna2DataGridView1.DataSource = hd.getAllHoaDonAndDatPhongByDate(Ngay1.ToString("yyyy/MM/dd"), Ngay2.ToString("yyyy/MM/dd"));
                    if (guna2DataGridView1.RowCount == 0)
                    {
                        throw new Exception("Không có hóa đơn nào trong khoảng thời gian này");
                    }
                    lblSoHD.Text = hd.getCountHoaDonAndDatPhongByDate(Ngay1.ToString("yyyy/MM/dd"), Ngay2.ToString("yyyy/MM/dd")).ToString();
                    lblTien.Text = hd.getSumTongTienByDate(Ngay1.ToString("yyyy/MM/dd"), Ngay2.ToString("yyyy/MM/dd")).ToString();
                }
                else
                {
                    int trangthai = Int32.Parse(cbxTrangThai.Text);
                    guna2DataGridView1.DataSource = hd.getAllHoaDonAndDatPhongByDateAndTrangThai(trangthai, Ngay1.ToString("yyyy/MM/dd"), Ngay2.ToString("yyyy/MM/dd"));
                    if (guna2DataGridView1.RowCount == 0)
                    {
                        throw new Exception("Không có hóa đơn nào trong khoảng thời gian này");
                    }
                    lblSoHD.Text = hd.getCountHoaDonAndDatPhongByDateAndTrangThai(trangthai, Ngay1.ToString("yyyy/MM/dd"), Ngay2.ToString("yyyy/MM/dd")).ToString();
                    lblTien.Text = hd.getSumTongTienByDateAndTrangThai(trangthai, Ngay1.ToString("yyyy/MM/dd"), Ngay2.ToString("yyyy/MM/dd")).ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "THÔNG BÁO");
            }
        }

        private void btnXemCTDV_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridView1.Rows.Count == 0)
                    throw new Exception("Không có hóa đơn nào để xem");
                int mahd = Int32.Parse(guna2DataGridView1.Rows[dong].Cells[0].Value.ToString());
                if (hd.checkChiTietDichVuByMaHD(mahd) == false)
                    throw new Exception("Hóa đơn " + mahd + " không có dịch vụ nào");
                else
                {
                    formChiTietDichVu form = new formChiTietDichVu(mahd);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "THÔNG BÁO");
            }
        }
    }
}

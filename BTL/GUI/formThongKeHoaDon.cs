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
            dong = e.RowIndex;
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

                string[] ngay1 = Ngay1.ToShortDateString().Split('/');
                string[] ngay2 = Ngay2.ToShortDateString().Split('/');

                string nam1 = ngay1[2].Substring(0, 4);
                string nam2 = ngay2[2].Substring(0, 4);

                String NgayHD1 = ngay1[1] + "/" + ngay1[0] + "/" + nam1;
                String NgayHD2 = ngay2[1] + "/" + ngay2[0] + "/" + nam2;
                clearLabel();
                if (cbxTrangThai.Text == "Tất cả")
                {
                    guna2DataGridView1.DataSource = hd.getAllHoaDonAndDatPhongByDate(NgayHD1, NgayHD2);
                    if (guna2DataGridView1.RowCount == 0)
                    {
                        throw new Exception("Không có hóa đơn nào trong khoảng thời gian này");
                    }
                    lblSoHD.Text = hd.getCountHoaDonAndDatPhongByDate(NgayHD1, NgayHD2).ToString();
                    lblTien.Text = hd.getSumTongTienByDate(NgayHD1, NgayHD2).ToString();
                }
                else
                {
                    int trangthai = Int32.Parse(cbxTrangThai.Text);
                    guna2DataGridView1.DataSource = hd.getAllHoaDonAndDatPhongByDateAndTrangThai(trangthai, NgayHD1, NgayHD2);
                    if (guna2DataGridView1.RowCount == 0)
                    {
                        throw new Exception("Không có hóa đơn nào trong khoảng thời gian này");
                    }
                    lblSoHD.Text = hd.getCountHoaDonAndDatPhongByDateAndTrangThai(trangthai, NgayHD1, NgayHD2).ToString();
                    lblTien.Text = hd.getSumTongTienByDateAndTrangThai(trangthai, NgayHD1, NgayHD2).ToString();
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

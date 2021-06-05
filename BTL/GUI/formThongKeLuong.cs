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
    public partial class formThongKeLuong : Form
    {
        NhanVienBUS nv = new NhanVienBUS();
        ChamCongBUS cc = new ChamCongBUS();
        int manv;
        int luongcb;
        public formThongKeLuong()
        {
            InitializeComponent();
        }
        public void loadCombo()
        {
            cbxMaNV.ValueMember = "MaNhanVien";
            cbxMaNV.DisplayMember = "TenNhanVien";
            cbxMaNV.DataSource = nv.layTTNhanVien();
        }

        private void formThongKeLuong_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            loadCombo();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DateTimePicker1.Value > guna2DateTimePicker2.Value)
                {
                    throw new Exception("Ngày ban đầu không được lớn hơn ngày kết thúc");
                }
                DateTime Ngay1 = guna2DateTimePicker1.Value;
                DateTime Ngay2 = guna2DateTimePicker2.Value;


                guna2DataGridView1.DataSource = cc.getChamCongByMaNVAndDate(manv, Ngay1.ToString("yyyy/MM/dd"), Ngay2.ToString("yyyy/MM/dd"));

                int ngaycong = cc.getCountChamCongByMaNVAndDate(manv, Ngay1.ToString("yyyy/MM/dd"), Ngay2.ToString("yyyy/MM/dd"));
                lblNgayCong.Text = ngaycong.ToString();

                int luongtong = ngaycong * luongcb;
                lblTongLuong.Text = luongtong.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "THÔNG BÁO");
            }
        }

        private void cbxMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            manv = Int32.Parse(cbxMaNV.SelectedValue.ToString());

            guna2DataGridView1.DataSource = cc.getChamCongByMaNV(manv);

            luongcb = nv.getLuongCoBanByMaNV(manv);
            lblLuongCB.Text = luongcb.ToString();

            int ngaycong = cc.getCountChamCongByMaNV(manv);
            lblNgayCong.Text = ngaycong.ToString();

            int luongtong = ngaycong * luongcb;
            lblTongLuong.Text = luongtong.ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = cc.getChamCongByMaNV(manv);

            int ngaycong = cc.getCountChamCongByMaNV(manv);
            lblNgayCong.Text = ngaycong.ToString();

            int luongtong = ngaycong * luongcb;
            lblTongLuong.Text = luongtong.ToString();

            DialogResult confirm = MessageBox.Show("Bạn có CHẮC muốn thanh toán hết lương của nhân viên " + cbxMaNV.Text + " không???",
                "THÔNG BÁO", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                bool check = cc.deleteChamCongByMaNV(manv);
                if (check)
                {
                    MessageBox.Show("Đã thanh toán lương của nhân viên " + cbxMaNV.Text + " THÀNH CÔNG!"
                        + "\n" + "Số ngày công: " + ngaycong + "\n" +
                        "Tổng lương: " + luongtong, "THÔNG BÁO");
                }
                else
                {
                    MessageBox.Show("Thanh toán lương cho nhân viên " + cbxMaNV.Text + " THẤT BẠI!");
                }
            }
            guna2DataGridView1.DataSource = cc.getChamCongByMaNV(manv);
        }
    }
}

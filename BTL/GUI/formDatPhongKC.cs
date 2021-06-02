using BTL.BUS;
using BTL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class formDatPhongKC : Form
    {
        public formDatPhongKC()
        {
            InitializeComponent();
        }
        List<PhongDTO> dsPhong = new List<PhongDTO>();
        KhachHangBUS khachHangBUS = new KhachHangBUS();
        KhachHangDTO khachHangDTO = new KhachHangDTO();
        LoaiPhongBUS loaiPhongBUS = new LoaiPhongBUS();
        DatPhongBUS datPhongBus = new DatPhongBUS();
        KhachHangDTO kh = new KhachHangDTO();
        int tienCoc = 0;
        int tongTien = 0;
        string maNV;
        private void formDatPhong_Load(object sender, EventArgs e)
        {
            DataTable dt = loaiPhongBUS.GetTableLoaiPhong();
            cbxLoaiPhong.DataSource = dt;
            cbxLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbxLoaiPhong.ValueMember = "MaLoaiPhong";
            dateCheckIn.MinDate = DateTime.Now;
            dateCheckout.MinDate = DateTime.Now.AddDays(1);
        }


        private void CheckIn_Click(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            if(kh.MaKH == 0)
            {
                MessageBox.Show("Phải tìm khách hàng trước");
            }
            else if(cbxPhong.SelectedValue == null)
            {
                MessageBox.Show("Phòng không hợp lệ");
            }
            else
            {
                string checkIn = dateCheckIn.Value.ToString("yyyy/MM/dd");
                string checkOut = dateCheckout.Value.ToString("yyyy/MM/dd");
                int maNV = 1;
                int maKH = kh.MaKH;
                int maPhong = Convert.ToInt32(cbxPhong.SelectedValue.ToString());
                if(datPhongBus.datPhong(maNV, maKH, maPhong, checkIn, checkOut, tienCoc))
                {
                    MessageBox.Show("Đặt phòng thành công");
                }
                else
                {
                    MessageBox.Show("Đặt phòng thất bại");
                }
            }
        }
       
        private void tienPhaiTra()
        {
            
            tienCoc = Convert.ToInt32(txtPrice.Text);
            tongTien = tienCoc * ((dateCheckout.Value - dateCheckIn.Value).Days);
            lbTienCoc.Text = (tongTien/2).ToString();
            lbTongBill.Text = tongTien.ToString();
        }   
        private void cbxPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbxLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = 0;
            if (int.TryParse(cbxLoaiPhong.SelectedValue.ToString(), out n))
            {
                DataTable dt = datPhongBus.getPhong(dateCheckIn.Value, dateCheckout.Value, cbxLoaiPhong.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    cbxPhong.DataSource = dt;
                    cbxPhong.ValueMember = "MaPhong";
                    cbxPhong.DisplayMember = "MaPhong";
                    txtPrice.Text = datPhongBus.getGia(cbxLoaiPhong.SelectedValue.ToString()).ToString();
                    tienPhaiTra();
                }
                
            }
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
             kh = datPhongBus.getKhachHang(txtTuKhoa.Text);
            if(kh.MaKH != 0)
            {
                txtTenKH.Text = kh.HoTen;
                txtSDT.Text = kh.SoDT;
                txtCMND.Text = kh.Cmnd;
                txtEmail.Text = kh.Email;
                txtDiaChi.Text = kh.DiaChi;
                if (kh.GioiTinh == 0)
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }
                txtCMND.Text = kh.Cmnd;
                DateTime date = DateTime.Parse(kh.NgaySinh);
                dateNS.Value = date;
            }
            //dateNS.
        }


        private void dateCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dateCheckIn.Value.Date > dateCheckout.Value.Date)
            {
                dateCheckout.Value = dateCheckIn.Value;
                dateCheckout.MinDate = dateCheckIn.Value.AddDays(1);
            }
            else
            {
                dateCheckout.MinDate = dateCheckIn.Value.AddDays(1);
            }
            int n = 0;
            if (int.TryParse(cbxLoaiPhong.SelectedValue.ToString(), out n))
            {
                DataTable dt = datPhongBus.getPhong(dateCheckIn.Value, dateCheckout.Value, cbxLoaiPhong.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    cbxPhong.DataSource = dt;
                    cbxPhong.ValueMember = "MaPhong";
                    cbxPhong.DisplayMember = "MaPhong";
                    txtPrice.Text = datPhongBus.getGia(cbxLoaiPhong.SelectedValue.ToString()).ToString();
                    tienPhaiTra();
                }
                else
                {
                    cbxPhong.DataSource = null;
                    txtPrice.Text = "0";
                    tienPhaiTra();
                }
                
            }
        }

        private void dateCheckout_ValueChanged(object sender, EventArgs e)
        {
            if (dateCheckIn.Value.Date > dateCheckout.Value.Date)
            {
                MessageBox.Show("Ngày check out phải lớn hơn ngày check in");
                dateCheckIn.Value = dateCheckout.Value.AddDays(-1);
            }
            int n = 0;
            if (int.TryParse(cbxLoaiPhong.SelectedValue.ToString(), out n))
            {
                DataTable dt = datPhongBus.getPhong(dateCheckIn.Value, dateCheckout.Value, cbxLoaiPhong.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    cbxPhong.DataSource = dt;
                    cbxPhong.ValueMember = "MaPhong";
                    cbxPhong.DisplayMember = "MaPhong";
                    txtPrice.Text = datPhongBus.getGia(cbxLoaiPhong.SelectedValue.ToString()).ToString();
                    tienPhaiTra();
                }
               
            }
        }
    }
}

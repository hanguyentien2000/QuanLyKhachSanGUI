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
        private void formDatPhong_Load(object sender, EventArgs e)
        {
            DataTable dt = loaiPhongBUS.GetTableLoaiPhong();
            cbxLoaiPhong.DataSource = dt;
            cbxLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbxLoaiPhong.ValueMember = "MaLoaiPhong";
            dateCheckIn.MinDate = DateTime.Now;
            dateCheckout.MinDate = DateTime.Now;
        }


        private void CheckIn_Click(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnDatPhong_Click(object sender, EventArgs e)
        {

        }
        private Boolean SoSanhPhong(PhongDTO p)
        {
            for (int i = 0; i < lstRoom.Items.Count; i++)
            {
                PhongDTO ph = (PhongDTO)lstRoom.Items[i].Tag;
                if (ph.Equals(p))
                {
                    return false;
                }
            }
            return true;
        }
        private void tienPhaiTra()
        {
            int tienCoc = 0;
            int tongTien = 0;
            for (int i = 0; i < lstRoom.Items.Count; i++)
            {
                PhongDTO ph = (PhongDTO)lstRoom.Items[i].Tag;
                tienCoc += datPhongBus.getGia(ph.MaLoaiPhong.ToString());
            
            }
            tongTien = tienCoc * ((dateCheckout.Value - dateCheckIn.Value).Days + 1);
            lbTienCoc.Text = tienCoc.ToString();
            lbTongBill.Text = tongTien.ToString();
        }
        private void btnAddPhong_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            PhongDTO p = datPhongBus.getPhong(cbxPhong.SelectedValue.ToString());
            if(SoSanhPhong(p))
            {   
                item.Text = "Phòng" + p.MaPhong.ToString();
                item.Tag = p;
                lstRoom.Items.Add(item);
                tienPhaiTra();
            }    
        }

        private void lstRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            KhachHangDTO kh = datPhongBus.getKhachHang(txtTuKhoa.Text);
            txtTenKH.Text = kh.HoTen;
            txtSDT.Text = kh.SoDT;
            txtCMND.Text = kh.Cmnd;
            txtEmail.Text = kh.Email;
            txtDiaChi.Text = kh.DiaChi;
            if(kh.GioiTinh == 0)
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
            //dateNS.
        }

        //private void dateCheckIn_ValueChanged(object sender, EventArgs e)
        //{
        //    if (dateCheckIn.Value.Date > dateCheckout.Value.Date)
        //    {
        //        MessageBox.Show("Ngày check in phải nhỏ hơn ngày check out");
        //        dateCheckIn.Value = dateCheckout.Value;
        //    }
        //}

        //private void dateCheckOut_ValueChanged(object sender, EventArgs e)
        //{
        //    if (dateCheckIn.Value.Date > dateCheckout.Value.Date)
        //    {
        //        MessageBox.Show("Ngày check out phải lớn hơn ngày check in");
        //        dateCheckIn.Value = dateCheckout.Value;
        //    }

        //}

        private void dateCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dateCheckIn.Value.Date > dateCheckout.Value.Date)
            {
                dateCheckout.Value = dateCheckIn.Value;
                dateCheckout.MinDate = dateCheckIn.Value;
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

        private void dateCheckout_ValueChanged(object sender, EventArgs e)
        {
            if (dateCheckIn.Value.Date > dateCheckout.Value.Date)
            {
                MessageBox.Show("Ngày check out phải lớn hơn ngày check in");
                dateCheckIn.Value = dateCheckout.Value;
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

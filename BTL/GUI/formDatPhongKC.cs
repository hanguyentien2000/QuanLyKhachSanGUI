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
        }

        private void dateCheckIn_ValueChanged(object sender, EventArgs e)
        {
    
        }

        private void CheckIn_Click(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateNS_ValueChanged(object sender, EventArgs e)
        {

        }


        private void btnDatPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPhong_Click(object sender, EventArgs e)
        {

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
                DataTable dt = datPhongBus.getPhong(dateCheckIn.Value, dateCheckOut.Value, cbxLoaiPhong.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    cbxPhong.Enabled = true;
                    cbxPhong.DataSource = dt;
                    cbxPhong.ValueMember = "MaPhong";
                    cbxPhong.DisplayMember = "MaPhong";
                }
            }
            
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = khachHangBUS.getKhachHang(txtTuKhoa.Text);
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
    }
}

using BTL.BUS;
using BTL.Models;
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
    public partial class formTTHoaDon : Form
    {
        public formCheckOut f;
        DatPhongBUS datPhongBUS = new DatPhongBUS();
        HoaDonDTO hd = new HoaDonDTO();
        public formTTHoaDon(formCheckOut fs)
        {
            this.f = fs;
            InitializeComponent();
        }

        private void formTTHoaDon_Load(object sender, EventArgs e)
        {
            int maHD = datPhongBUS.getMaHD(f.maDatPhong);
            hd = datPhongBUS.ttHoaDon(maHD);
            lbHD.Text = "HÓA ĐƠN SỐ " + hd.MaHD.ToString();
            lbMaDP.Text = "Mã đặt phòng :" + hd.MaHD.ToString();
            lbNgayLap.Text = "Ngày lập :" + hd.NgayLap.ToString("dd/MM/yyyy");
            lbTTDV.Text = "Tổng tiền dịch vụ :" + String.Format("{ 0:0,0 vnđ}", datPhongBUS.getTongTienDV(maHD));
            lbTTP.Text = "Tổng tiền phòng :" + String.Format("{ 0:0,0 vnđ}", datPhongBUS.getTongTienPhong(maHD));
            lbTT.Text = "Thành tiền :" + String.Format("{ 0:0,0 vnđ}", hd.TongTien);
            lbTienCoc.Text = "Tiền cọc :" + datPhongBUS.getTienCoc(f.maDatPhong);
        }

        private void lbTTDV_Click(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

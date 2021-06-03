using BTL.BUS;
using BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            try
            {
                int maHD = datPhongBUS.getMaHD(f.maDatPhong);
                hd = datPhongBUS.ttHoaDon(maHD);
                lbHD.Text = "HÓA ĐƠN SỐ " + hd.MaHD.ToString();
                lbMaDP.Text = "Mã đặt phòng :" + hd.MaHD.ToString();
                lbNgayLap.Text = "Ngày lập :" + hd.NgayLap.ToString("dd/MM/yyyy");
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                string ttp = datPhongBUS.getTongTienPhong(maHD).ToString("#,###", cul.NumberFormat);
                string ttdv = datPhongBUS.getTongTienDV(maHD).ToString("#,###", cul.NumberFormat);
                string tt = hd.TongTien.ToString("#,###", cul.NumberFormat);
                string ttc = datPhongBUS.getTienCoc(f.maDatPhong).ToString("#,###", cul.NumberFormat);
                lbTTDV.Text = "Tổng tiền dịch vụ :" + ttdv;
                lbTTP.Text = "Tổng tiền phòng :" + ttp;
                lbTT.Text = "Thành tiền :" + tt;
                lbTienCoc.Text = "Tiền cọc :" + ttc;
            } catch(Exception)
            {
                MessageBox.Show("In hóa đơn lỗi");
            }
        }

        private void lbTTDV_Click(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbHD_Click(object sender, EventArgs e)
        {

        }
    }
}

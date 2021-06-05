using BTL.BUS;
using BTL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.GUI
{
    public partial class formDatPhongKM : Form
    {
        public formLogin f;
        public formDatPhongKM(formLogin fs)
        {
            this.f = fs;
            InitializeComponent();
        }
        KhachHangDTO khachHangDTO = new KhachHangDTO();
        LoaiPhongBUS loaiPhongBUS = new LoaiPhongBUS();
        DatPhongBUS datPhongBus = new DatPhongBUS();
        KhachHangDTO kh = new KhachHangDTO();
        int tienCoc = 0;
        int tongTien = 0;
        int lanVao = 0;
        private void formDatPhongKM_Load(object sender, EventArgs e)
        {
            DataTable dt = loaiPhongBUS.GetTableLoaiPhong();
            cbxLoaiPhong.DataSource = dt;
            cbxLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbxLoaiPhong.ValueMember = "MaLoaiPhong";
            dateCheckin.MinDate = DateTime.Now;
            dateCheckout.MinDate = DateTime.Now.AddDays(1);
            dateNS.MaxDate = DateTime.Now.AddYears(-18);
            rdNam.Checked = true;
        }
        private void tienPhaiTra(DateTime d1,DateTime d2)
        {
            tienCoc = Convert.ToInt32(txtPrice.Text);
            tongTien = tienCoc * (d2 - d1).Days;
            lbTienCoc.Text = (tongTien / 2).ToString();
            lbTongBill.Text = tongTien.ToString();
        }
        public void layThongTin()
        {
            khachHangDTO.HoTen = txtTenKH.Text;
            khachHangDTO.SoDT = txtSDT.Text;
            DateTime date = dateNS.Value;

            khachHangDTO.NgaySinh = dateNS.Value.ToString("yyyy/MM/dd");
            khachHangDTO.Email = txtEmail.Text;
            khachHangDTO.GioiTinh = rdNam.Checked ? 0 : rdNu.Checked ? 1 : 0;
            khachHangDTO.DiaChi = txtDiaChi.Text;
            khachHangDTO.Cmnd = txtCMND.Text;
            khachHangDTO.TrangThai = 1;
        }
        private void cbxLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            int n = 0;
            if (int.TryParse(cbxLoaiPhong.SelectedValue.ToString(), out n))
            {
                DataTable dt = datPhongBus.getPhong(dateCheckin.Value, dateCheckout.Value, cbxLoaiPhong.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    cbxPhong.DataSource = dt;
                    cbxPhong.ValueMember = "MaPhong";
                    cbxPhong.DisplayMember = "MaPhong";
                    txtPrice.Text = datPhongBus.getGia(cbxLoaiPhong.SelectedValue.ToString()).ToString();
                    tienPhaiTra(dateCheckin.Value, dateCheckout.Value);
                }
                else
                {
                    cbxPhong.DataSource = dt;
                    cbxPhong.ValueMember = "MaPhong";
                    cbxPhong.DisplayMember = "MaPhong";
                    txtPrice.Text = "";
                    lbTienCoc.Text = "";
                    lbTongBill.Text = "";
                }

            }
        }

        private void dateCheckin_ValueChanged(object sender, EventArgs e)
        {
            if(lanVao > 0)
            {
                dateCheckout.Enabled = true;
            }
            if (dateCheckin.Value.Date > dateCheckout.Value.Date)
            {
                dateCheckout.Value = dateCheckin.Value;
                dateCheckout.MinDate = dateCheckin.Value.AddDays(1);
            }
            else
            {
                dateCheckout.MinDate = dateCheckin.Value.AddDays(1);
            }
            
            int n = 0;
            if (int.TryParse(cbxLoaiPhong.SelectedValue.ToString(), out n))
            {
                DataTable dt = datPhongBus.getPhong(dateCheckin.Value, dateCheckout.Value, cbxLoaiPhong.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    cbxPhong.DataSource = dt;
                    cbxPhong.ValueMember = "MaPhong";
                    cbxPhong.DisplayMember = "MaPhong";
                    txtPrice.Text = datPhongBus.getGia(cbxLoaiPhong.SelectedValue.ToString()).ToString();
                    tienPhaiTra(dateCheckin.Value, dateCheckout.Value);
                }
                else
                {
                    cbxPhong.DataSource = null;
                    txtPrice.Text = "0";
                    tienPhaiTra(dateCheckin.Value, dateCheckout.Value);
                }

            }
            lanVao++;
        }

        private void dateCheckout_ValueChanged(object sender, EventArgs e)
        {
            int n = 0;
            if (int.TryParse(cbxLoaiPhong.SelectedValue.ToString(), out n))
            {
                DataTable dt = datPhongBus.getPhong(dateCheckin.Value, dateCheckout.Value, cbxLoaiPhong.SelectedValue.ToString());
                if (dt.Rows.Count > 0)
                {
                    cbxPhong.DataSource = dt;
                    cbxPhong.ValueMember = "MaPhong";
                    cbxPhong.DisplayMember = "MaPhong";
                    txtPrice.Text = datPhongBus.getGia(cbxLoaiPhong.SelectedValue.ToString()).ToString();
                    tienPhaiTra(dateCheckin.Value,dateCheckout.Value);
                }
                else
                {
                    cbxPhong.DataSource = null;
                    txtPrice.Text = "0";
                    tienPhaiTra(dateCheckin.Value, dateCheckout.Value);
                }

            }
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            string regEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            string regPhone = "(84|0[3|5|7|8|9])+([0-9]{8})";
            try
            {
                if (txtTenKH.Text.Trim().Length == 0)
                {
                    throw new Exception("Tên không được bỏ trống");
                }
                if (txtSDT.Text.Trim().Length == 0)
                {
                    throw new Exception("Số điện thoại không Được bỏ trống");
                }
                if (!Regex.IsMatch(txtSDT.Text, regPhone))
                {
                    throw new Exception("Số điện thoại không hợp lệ");
                }
                if (txtEmail.Text.Trim().Length == 0)
                {
                    throw new Exception("Email không Được bỏ trống");
                }
                if (!Regex.IsMatch(txtEmail.Text, regEmail))
                {
                    throw new Exception("Email không hợp lệ");
                }
                if (txtCMND.Text.Trim().Length == 0)
                {
                    throw new Exception("Chứng minh nhân dân không được để trống");
                }
                if (txtDiaChi.Text.Trim().Length == 0)
                {
                    throw new Exception("Địa chỉ không được để trống");
                }
                if (dateNS.Value > DateTime.Now.AddYears(-18))
                {
                    throw new Exception("Khách hàng phải trên 18 tuổi");
                }
                layThongTin();
                string checkIn = dateCheckin.Value.ToString("yyyy/MM/dd");
                string checkOut = dateCheckout.Value.ToString("yyyy/MM/dd");
                int maPhong = Convert.ToInt32(cbxPhong.SelectedValue.ToString());
                if (datPhongBus.datPhongKM(khachHangDTO,this.f.account.NhanVien.MaNhanVien, maPhong, checkIn, checkOut, tienCoc / 2))
                {
                    MessageBox.Show("Đặt phòng thành công");
                    int n = 0;
                    if (int.TryParse(cbxLoaiPhong.SelectedValue.ToString(), out n))
                    {
                        DataTable dt = datPhongBus.getPhong(dateCheckin.Value, dateCheckout.Value, cbxLoaiPhong.SelectedValue.ToString());
                        if (dt.Rows.Count > 0)
                        {
                            cbxPhong.DataSource = dt;
                            cbxPhong.ValueMember = "MaPhong";
                            cbxPhong.DisplayMember = "MaPhong";
                            txtPrice.Text = datPhongBus.getGia(cbxLoaiPhong.SelectedValue.ToString()).ToString();
                            tienPhaiTra(dateCheckin.Value, dateCheckout.Value);
                        }
                        else{
                            cbxPhong.DataSource = dt;
                            cbxPhong.ValueMember = "MaPhong";
                            cbxPhong.DisplayMember = "MaPhong";
                            txtPrice.Text = "";
                            lbTienCoc.Text = "";
                            lbTongBill.Text = "";
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Đặt phòng thất bại");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}

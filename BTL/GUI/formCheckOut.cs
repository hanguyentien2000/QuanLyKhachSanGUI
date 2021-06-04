﻿using BTL.BUS;
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
    public partial class formCheckOut : Form
    {
        DatPhongBUS datPhongBus = new DatPhongBUS();
        public DatPhong datPhong;
        public int maDatPhong = 0;
        int rowSelected;
        public formCheckOut()
        {
            InitializeComponent();
        }
        public void resetInfor()
        {
            maDatPhong = 0;
            txtMaKhach.Text = "";
            txtMaPhong.Text = "";
        }
        private void formCheckIn_Load(object sender, EventArgs e)
        {
            loadAllCheckOut();
        }
        public void loadAllCheckOut()
        {
            dgvCheckOut.DataSource = datPhongBus.getTTDatPhongCO();
        }
        public void loadTableCOToday()
        {
            dgvCheckOut.DataSource = datPhongBus.getCheckOutToday();
        }

        private void dgvCheckOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowSelected = e.RowIndex;
            try
            {
                if (dgvCheckOut.Rows.Count == rowSelected + 1)
                {
                    throw new Exception("Dữ liệu trống");
                }
                txtMaKhach.Text = dgvCheckOut.Rows[rowSelected].Cells[3].Value.ToString();
                txtMaPhong.Text = dgvCheckOut.Rows[rowSelected].Cells[1].Value.ToString();
                maDatPhong = Convert.ToInt32(dgvCheckOut.Rows[rowSelected].Cells[0].Value.ToString());
                btnDichVu.Enabled = true;
                if(DateTime.Parse(dgvCheckOut.Rows[rowSelected].Cells[6].Value.ToString()) <= DateTime.Now)
                {
                    btnCheckOut.Enabled = true;
                }
                else
                {
                    btnCheckOut.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListToday_Click(object sender, EventArgs e)
        {
            btnDichVu.Enabled = false;
            btnCheckOut.Enabled = true;
            resetInfor();
            loadTableCOToday();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            btnDichVu.Enabled = false;
            btnCheckOut.Enabled = false;
            loadAllCheckOut();
            resetInfor();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtKeyWords.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập keywords");
            }
            else
            {
                  
                dgvCheckOut.DataSource = datPhongBus.timKiemCheckOut(txtKeyWords.Text);
                btnCheckOut.Enabled = false;
                btnDichVu.Enabled = false;
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (maDatPhong > 0)
            {
                DialogResult result = MessageBox.Show("Checkin cho mã đặt phòng " + maDatPhong, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (datPhongBus.passToThongKe(maDatPhong))
                    {
                        int maHD = datPhongBus.getMaHD(maDatPhong);
                        int tongTienDV = datPhongBus.getTongTienDV(maHD);
                        int tongTienP = datPhongBus.getTongTienPhong(maDatPhong);
                        int tongTien = tongTienDV + tongTienP;
                        if(datPhongBus.updateHDSauKhiCheckOut(maHD,tongTien))
                        {
                            formTTHoaDon frmTT = new formTTHoaDon(this);
                            frmTT.ShowDialog();
                        }
                      
                        loadTableCOToday();
                        maDatPhong = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn đơn cần checkin");
            }
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            formDatDichVu frm = new formDatDichVu(this);
            frm.ShowDialog();
        }
    }
}

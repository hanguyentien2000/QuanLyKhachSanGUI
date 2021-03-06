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
            txtKeyWords.Text = "";
        }
        private void formCheckIn_Load(object sender, EventArgs e)
        {
            dgvCheckOut.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgvCheckOut.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            loadAllCheckOut();
            dgvCheckOut.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCheckOut.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCheckOut.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";
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
            dgvCheckOut.ReadOnly = true;
            rowSelected = e.RowIndex;
            try
            {
                if (rowSelected < 0)
                {
                    throw new Exception("Ô này không có dữ liệu");
                }
                txtMaKhach.Text = dgvCheckOut.Rows[rowSelected].Cells[2].Value.ToString();
                txtMaPhong.Text = dgvCheckOut.Rows[rowSelected].Cells[3].Value.ToString();
                maDatPhong = Convert.ToInt32(dgvCheckOut.Rows[rowSelected].Cells[0].Value.ToString());
                btnDichVu.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListToday_Click(object sender, EventArgs e)
        {
            btnDichVu.Enabled = false;
            resetInfor();
            loadTableCOToday();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            btnDichVu.Enabled = false;
            loadAllCheckOut();
            resetInfor();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int value;
            if (txtKeyWords.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập keywords");
            }
            else if(int.TryParse(txtKeyWords.Text,out value))
            {
                dgvCheckOut.DataSource = datPhongBus.timKiemCheckOut(txtKeyWords.Text);
                btnDichVu.Enabled = false;
            }    
            else
            {
                MessageBox.Show("Keywords nhập sai định dạng");
                
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (maDatPhong > 0)
            {
                DialogResult result = MessageBox.Show("Checkout cho mã đặt phòng " + maDatPhong, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (datPhongBus.checkout(maDatPhong))
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
                      
                        loadAllCheckOut();
                        maDatPhong = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn đơn cần checkout");
            }
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            formDatDichVu frm = new formDatDichVu(this);
            frm.ShowDialog();
        }
    }
}

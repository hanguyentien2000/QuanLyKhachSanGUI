using BTL.BUS;
using BTL.DTO;
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
    public partial class formCheckIn : Form
    {
        DatPhongBUS datPhongBus = new DatPhongBUS();
        int maDatPhong = 0;
        int rowSelected;
        public formCheckIn()
        {
            InitializeComponent();
        }

        private void formCheckOut_Load(object sender, EventArgs e)
        {
            dgvCheckIn.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgvCheckIn.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            loadTableAll();
            dgvCheckIn.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvCheckIn.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void formCheckOut_Click(object sender, EventArgs e)
        {

        }
        public void resetInfor()
        {
            maDatPhong = 0;
            txtMaKhach.Text = "";
            txtMaPhong.Text = "";
            txtKeyWords.Text = "";
        }
        private void btnListToday_Click(object sender, EventArgs e)
        {
            btnCheckIn.Enabled = true;
            btnConfirmOOD.Enabled = false;
            resetInfor();
            loadTableCIToday();
            
        }
        public void loadTableAll()
        {
            dgvCheckIn.DataSource = datPhongBus.getTTDatPhongCI();
        }
        public void loadTableCIToday()
        {
            dgvCheckIn.DataSource = datPhongBus.getCheckInToday();
        }
        public void loadTableOOD()
        {
            dgvCheckIn.DataSource = datPhongBus.getOutOfDate();
        }
        //private void btnLoc_Click(object sender, EventArgs e)
        //{
        //    dgvCheckIn.DataSource = datPhongBus.locCheckIn(dateStart.Value, dateEnd.Value);
        //}

        private void dgvCheckIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCheckIn.ReadOnly = true;
            rowSelected = e.RowIndex;
            try
            {
                if (rowSelected < 0)
                {
                    throw new Exception("Ô này không có dữ liệu");
                }
                txtMaKhach.Text = dgvCheckIn.Rows[rowSelected].Cells[3].Value.ToString();
                txtMaPhong.Text = dgvCheckIn.Rows[rowSelected].Cells[1].Value.ToString();
                maDatPhong = Convert.ToInt32(dgvCheckIn.Rows[rowSelected].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if(maDatPhong > 0)
            {
                DialogResult result = MessageBox.Show("Checkin cho mã đặt phòng " + maDatPhong, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (datPhongBus.passToCheckout(maDatPhong))
                    {
                        loadTableCIToday();
                        MessageBox.Show("Checkin thành công");
                        maDatPhong = 0;
                    }
                    else
                    {
                        MessageBox.Show("Checkin thất bại");
                    }
                } 
            }
            else
            {
                MessageBox.Show("Chưa chọn đơn cần checkin");
            }
        }

        private void btnOutOfDate_Click(object sender, EventArgs e)
        {

            loadTableOOD();
            btnConfirmOOD.Enabled = true;
            btnCheckIn.Enabled = false;
            resetInfor();
        }

        private void btnConfirmOOD_Click(object sender, EventArgs e)
        {
            if (maDatPhong > 0)
            {
                DialogResult result = MessageBox.Show("Checkin cho mã đặt phòng " + maDatPhong, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    if (datPhongBus.quaHanCheckIn(maDatPhong))
                    {
                        MessageBox.Show("Hủy phòng thành công");
                        maDatPhong = 0;
                        loadTableOOD();
                    }
                    else
                    {
                        MessageBox.Show("Checkin thất bại");
                    }
                }    
            }
            else
            {
                MessageBox.Show("Chưa chọn đơn quá hạn");
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            loadTableAll();
            resetInfor();
            btnCheckIn.Enabled = false;
            btnConfirmOOD.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int value;
            
                if (txtKeyWords.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập keywords");
            }
            else if (int.TryParse(txtKeyWords.Text, out value))
            {
                dgvCheckIn.DataSource = datPhongBus.timKiemCheckIn(txtKeyWords.Text);
                btnCheckIn.Enabled = false;
                btnConfirmOOD.Enabled = false;
            }    
            else
            {
                MessageBox.Show("Keywords sai định dạng");
            }
        }
    }
}

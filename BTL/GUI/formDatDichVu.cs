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
    public partial class formDatDichVu : Form
    {
        public formCheckOut f;
        DatPhongBUS datPhongBUS = new DatPhongBUS();
        int rowSelected = -1;
        public formDatDichVu(formCheckOut fs)
        {
            this.f = fs;
            InitializeComponent();
        }
        public void xoaTrang()
        {
            txtSL.Text = "";
            rTxtGC.Text = "";
            cbxDichVu.SelectedIndex = 0;
        }
        private void formDatDichVu_Load(object sender, EventArgs e)
        {
            dgvDichVu.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dgvDichVu.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvDichVu.DataSource = datPhongBUS.getDichVuOneRoom(f.maDatPhong);
            cbxDichVu.DataSource = datPhongBUS.getAllDichVu();
            cbxDichVu.DisplayMember = "TenDichVu";
            cbxDichVu.ValueMember = "MaDichVu";
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int value;
            if(int.TryParse(txtSL.Text,out value))
            {
                if (datPhongBUS.ktraDichVu(datPhongBUS.getMaHD(f.maDatPhong), Convert.ToInt32(cbxDichVu.SelectedValue.ToString())))
                {
                    int slMoi = Convert.ToInt32(txtSL.Text) + datPhongBUS.getSoLuongDung(datPhongBUS.getMaHD(f.maDatPhong), Convert.ToInt32(cbxDichVu.SelectedValue.ToString()));
                    if (datPhongBUS.suaDV(datPhongBUS.getMaHD(f.maDatPhong), Convert.ToInt32(cbxDichVu.SelectedValue.ToString()), slMoi, rTxtGC.Text))
                    {
                        MessageBox.Show("Thêm dịch vụ thành công");
                        dgvDichVu.DataSource = datPhongBUS.getDichVuOneRoom(f.maDatPhong);
                    }
                    else
                    {
                        MessageBox.Show("Thêm dịch vụ thất bại !!");
                    }
                }
                else
                {
                    if (datPhongBUS.themDV(datPhongBUS.getMaHD(f.maDatPhong), Convert.ToInt32(cbxDichVu.SelectedValue.ToString()), Convert.ToInt32(txtSL.Text), rTxtGC.Text))
                    {
                        MessageBox.Show("Thêm dịch vụ thành công");
                        dgvDichVu.DataSource = datPhongBUS.getDichVuOneRoom(f.maDatPhong);
                    }
                    else
                    {
                        MessageBox.Show("Thêm dịch vụ thất bại !!");
                    }
                }
                   
            }
            else
            {
                MessageBox.Show("Số lượng không hợp lệ");
            }
            
        }
    
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDichVu.ReadOnly = true;
            rowSelected = e.RowIndex;
            if(rowSelected < 0)
            {
                MessageBox.Show("Ô này không có dữ liệu");
            }
            else
            {
                cbxDichVu.Text = dgvDichVu.Rows[rowSelected].Cells[1].Value.ToString();
                txtSL.Text = dgvDichVu.Rows[rowSelected].Cells[2].Value.ToString();
                rTxtGC.Text = dgvDichVu.Rows[rowSelected].Cells[4].Value.ToString();
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            txtSL.Text = "";
            rTxtGC.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(rowSelected < 0)
            {
                MessageBox.Show("Chưa chọn dịch vụ muốn sửa");
            }
            else
            {
                int value;
                if (int.TryParse(txtSL.Text, out value))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa dịch vụ ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (datPhongBUS.suaDV(datPhongBUS.getMaHD(f.maDatPhong), Convert.ToInt32(cbxDichVu.SelectedValue.ToString()), Convert.ToInt32(txtSL.Text), rTxtGC.Text))
                        {
                            MessageBox.Show("Sửa thành công");
                            dgvDichVu.DataSource = datPhongBUS.getDichVuOneRoom(f.maDatPhong);
                            rowSelected = -1;
                        }
                        else
                        {
                            MessageBox.Show("Sửa dịch vụ thất bại !!");
                        }
                    }    
                       
                }
                else
                {
                    MessageBox.Show("Số lượng không hợp lệ");
                }
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(rowSelected < 0)
            {
                MessageBox.Show("Bạn chưa chọn dịch vụ muốn xóa");
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa dịch vụ ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (datPhongBUS.xoaDichVu(datPhongBUS.getMaHD(f.maDatPhong), Convert.ToInt32(cbxDichVu.SelectedValue.ToString())))
                    {
                        MessageBox.Show("Xóa thành công");
                        dgvDichVu.DataSource = datPhongBUS.getDichVuOneRoom(f.maDatPhong);
                        rowSelected = -1;
                        xoaTrang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa dịch vụ thất bại !!");
                    }
                }
            }
               
        }
    }
}

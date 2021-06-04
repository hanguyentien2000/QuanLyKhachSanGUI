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
    public partial class formChamCong : Form
    {
        int MaNV;
        DateTime Ngay;
        ChamCongBUS chamcong = new ChamCongBUS();
        public formChamCong(int MaNV)
        {
            InitializeComponent();
            this.MaNV = MaNV;
        }
        public void loadData()
        {
            guna2DataGridView1.DataSource = chamcong.getChamCongByMaNV(MaNV);
            guna2DateTimePicker2.Value = DateTime.Now;
        }

        private void formChamCong_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            guna2DateTimePicker2.Enabled = false;
            loadData();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            Ngay = guna2DateTimePicker2.Value;
            string[] ngay = Ngay.ToShortDateString().Split('/');
            string nam = ngay[2].Substring(0, 4);
            String NgayCC = ngay[1] + "/" + ngay[0] + "/" + nam;
            bool cc = chamcong.checkChamCongByMaNVandNgay(MaNV, NgayCC);
            if (cc)
            {
                chamcong.insertChamCongByMaNVandNgay(MaNV, NgayCC);
                MessageBox.Show("Chấm công ngày " + NgayCC + " thành công");
            }
            else
            {
                MessageBox.Show("ĐÃ CHẤM CÔNG");
            }
            loadData();
        }
    }
}

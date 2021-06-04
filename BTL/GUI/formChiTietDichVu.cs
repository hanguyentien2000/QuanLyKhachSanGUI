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
    public partial class formChiTietDichVu : Form
    {
        int mahd;
        HoaDonBUS hd = new HoaDonBUS();
        public formChiTietDichVu(int mahd)
        {
            InitializeComponent();
            this.mahd = mahd;
        }

        private void formChiTietDichVu_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.ReadOnly = true;
            guna2DataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            guna2DataGridView1.DataSource = hd.getChiTietDichVuByMaHD(mahd);
        }
    }
}

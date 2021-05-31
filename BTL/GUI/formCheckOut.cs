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
        public formCheckOut()
        {
            InitializeComponent();
        }

        private void formCheckOut_Load(object sender, EventArgs e)
        {
            dgvCheckIn.DataSource = datPhongBus.getTTDatPhong();
        }
        public void loadTable()
        {

        }
    }
}

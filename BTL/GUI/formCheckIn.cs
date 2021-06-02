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

        private void formCheckIn_Load(object sender, EventArgs e)
        {

        }
        public void loadAllCheckOut()
        {

        }
    }
}

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
    public partial class formThemDichVu : Form
    {
        public formCheckOut f;
        DatPhongBUS datPhongBus = new DatPhongBUS();
        public formThemDichVu(formCheckOut fs)
        {
            this.f = fs;
            InitializeComponent();
        }

        private void formThemDichVu_Load(object sender, EventArgs e)
        {
            dgvDichVu.DataSource = datPhongBus.getDichVuOneRoom(f.maDatPhong);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void cbxDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

﻿using System;
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
    public partial class formThongTinHoaDon : Form
    {
        public formCheckOut checkOut;
        string MaDatPhong;
        public formThongTinHoaDon(formCheckOut ckout, string Ma)
        {
            InitializeComponent();
            MaDatPhong = Ma;
            this.checkOut = ckout;
            //lbCheckout.Text = checkOut.datPhong.MaDatPhong.ToString();
        }

        private void formThongTinHoaDon_Load(object sender, EventArgs e)
        {
            lbCheckout.Text = MaDatPhong;

        }
    }
}

﻿using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class formMain : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderbtn;
        private Form currentChildForm;
        public formMain()
        {
            InitializeComponent();
            leftBorderbtn = new Panel();
            leftBorderbtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderbtn);

            //FormTilerBar
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(57, 100, 251);
        }

        //Methods
        private void ActiveButton(object senderBtn, Color color)
        {
            DisabledButton();
            //Button
            currentBtn = (IconButton)senderBtn;
            currentBtn.BackColor = Color.FromArgb(37, 36, 81);
            currentBtn.ForeColor = color;
            currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.IconColor = color;
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            currentBtn.ImageAlign = ContentAlignment.MiddleRight;
            //LeftBorderbutton
            leftBorderbtn.BackColor = color;
            leftBorderbtn.Location = new Point(0, currentBtn.Location.Y);
            leftBorderbtn.Visible = true;
            leftBorderbtn.BringToFront();
            //IconCurrent
            IconCurrentForm.IconChar = currentBtn.IconChar;
            IconCurrentForm.IconColor = color;
        }
        private void DisabledButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        //OpenForm
        private void OpenCurrentForm(Form childForm)
        {
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            //addChildFormToParentForm
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
         
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
            OpenCurrentForm(new formDatPhong());
        }

        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            OpenCurrentForm(new formQuanLyPhong());
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color6);
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color7);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            RefreshData();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
    
        }
        private void RefreshData()
        {
            DisabledButton();
            leftBorderbtn.Visible = false;

            IconCurrentForm.IconChar = IconChar.Home;
            IconCurrentForm.IconColor = Color.MediumPurple;
            
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        
    }
}

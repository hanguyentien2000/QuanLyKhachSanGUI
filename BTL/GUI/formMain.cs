using BTL.GUI;
using BTL.InterfaceQuanly;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
            CustomizeDesign();
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
        private void CustomizeDesign()
        {
            panelSubmenu.Visible = false;
            panelSubmenu2.Visible = false;
        }

        private void HideSubmenu()
        {
            if(panelSubmenu.Visible == true)
            {
                panelSubmenu.Visible = false;
            }
            if (panelSubmenu2.Visible == true)
            {
                panelSubmenu2.Visible = false;
            }
        }

        private void ShowSubmenu(Panel Submenu)
        {
            if (Submenu.Visible == false)
            {
                HideSubmenu();
                Submenu.Visible = true;
            }
            else
                Submenu.Visible = false;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có thật sự muốn thoát khỏi ứng dụng???", "Thông báo",  MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
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

        private void panelHidden_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowFormLogin()
        {
            var formLogin = new formLogin();
            formLogin.ShowDialog();
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có thật sự muốn đăng xuất khỏi ứng dụng???", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Thread thread = new Thread(new ThreadStart(ShowFormLogin));
                thread.Start();
                this.Close();
            }
            else
            {
                return;
            }

        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
            OpenCurrentForm(new formDatPhongKC());
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            OpenCurrentForm(new formCheckOut());
        }

        private void btnQuanLyMain_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            //OpenCurrentForm(new formQuanLyPhong());
            ShowSubmenu(panelSubmenu);
        }

        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
            OpenCurrentForm(new formQuanLyPhong());
            //HideSubmenu();
        }

        private void btnQuanLyLoaiPhong_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color6);
            OpenCurrentForm(new formQuanLyLoaiPhong());
            //HideSubmenu();
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            OpenCurrentForm(new formQuanLyTaiKhoan());
            //HideSubmenu();
        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            OpenCurrentForm(new formQuanLyKhachHang());
            //HideSubmenu();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
            OpenCurrentForm(new formQuanLyNhanVien());
            //HideSubmenu();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            //OpenCurrentForm(new formThongKeHoaDon());
            ShowSubmenu(panelSubmenu2);
        }

        private void btnThongKeHoaDon_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            OpenCurrentForm(new formThongKeHoaDon());
            //HideSubmenu();
        }

        private void btnThongKeLuong_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
            OpenCurrentForm(new formThongKeLuong());
            //HideSubmenu();
        }

      
    }
}

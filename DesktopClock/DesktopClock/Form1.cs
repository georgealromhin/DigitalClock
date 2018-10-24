using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClock
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();


            // from transparent back color
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
            // hide from taskbar
            this.ShowInTaskbar = false;
            // custom font
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("digital-7.ttf");
            clockTxt.Font = new Font(pfc.Families[0],48, FontStyle.Regular);
            // show icon in Tray
            Icon formIcon = Properties.Resources.digitalclock;
            NotifyIcon mainIcon = new NotifyIcon();
            mainIcon.Icon = formIcon;
            mainIcon.Visible = true;

            // notification items
            MenuItem exitItem = new MenuItem("Quit");
            MenuItem settingsItem = new MenuItem("Settings");

            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(settingsItem);
            contextMenu.MenuItems.Add(exitItem);
            mainIcon.ContextMenu = contextMenu;

            exitItem.Click += ExitItem_Click;
            settingsItem.Click += SettingsItem_Click;

        }

        private void SettingsItem_Click(object sender, EventArgs e)
        {
            SettingsForm settFrm = new SettingsForm();
            if (settFrm.ShowDialog() == DialogResult.OK) {
                clockTxt.ForeColor = settFrm.clockTxtColor;
            }
                

        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clockTxt.Text = DateTime.Now.ToString("T");
        }

        //Make a borderless form and cloclTxt movable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void clockTxt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}

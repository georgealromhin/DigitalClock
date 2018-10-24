using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopClock
{
    
    public partial class SettingsForm : Form
    {
        Color newColor;
        public SettingsForm()
        {
            InitializeComponent();
        }
        public Color clockTxtColor
        {
            get { return this.newColor; }
            set { this.newColor = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK) {
                newColor = cd.Color;
                label1.ForeColor = cd.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

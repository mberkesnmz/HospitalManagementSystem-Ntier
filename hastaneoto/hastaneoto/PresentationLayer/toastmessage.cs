using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hastaneoto;



namespace hastaneoto.PresentationLayer
{
    public partial class toastmessage : Form
    {
        public toastmessage()
        {
            InitializeComponent();
        }

        public Color BackColorToastMessage
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public Color ColorToastMessage
        {
            get { return toastpnl.BackColor; }
            set { toastpnl.BackColor =Lbltoasttitle.ForeColor = Lbltoasttext.ForeColor = value; }
        }

        public System.Drawing.Image IconeToastMessage
        {
            get { return PicAlertBox.Image; }
            set { PicAlertBox.Image = value; }
        }

        public string TitleToastMessage
        {
            get { return Lbltoasttitle.Text; }
            set { Lbltoasttitle.Text = value; }
        }

        public string TextToastMessage
        {
            get { return Lbltoasttext.Text; }
            set { Lbltoasttext.Text = value; }
        }


        private void PositionAlertBox()
        {
            
           int xPos = 0; int yPos = 0;
           xPos = Screen.GetWorkingArea(this).Width;
           yPos = Screen.GetWorkingArea(this).Height;
           this.Location = new Point(xPos - this.Width, yPos-this.Height);

        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            toastpnl.Width = toastpnl.Width + 2;
            if(toastpnl.Width >= 500)
            {
                this.Close();
            }
        }

        private void toastmessage_Load(object sender, EventArgs e)
        {
            PositionAlertBox();
            for(int i = 0; i < 500; i++)
            {
                timerAnimation.Start();
            }
        }
    }
}

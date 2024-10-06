using hastaneoto.PresentationLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace hastaneoto
{
    public partial class login : Form
    {



        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            kullanici_cmb.Text = "Doktor";
        }

        private void girisyap_btn_Click(object sender, EventArgs e)
        {
            if(kullanici_cmb.Text== "Doktor")
            {
                this.Hide();
                doktor f2 = new doktor();
                f2.Show();
                Business.ToastMessage(Color.LightGreen, Color.SeaGreen, "Başarılı!", "Doktor girişi başarıyla gerçekleştirilmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

            }
            else if ( kullanici_cmb.Text == "Sekreter")
            {
                this.Hide();
                sekreter f2 = new sekreter();
                f2.Show();
                Business.ToastMessage(Color.LightGreen, Color.SeaGreen, "Başarılı!", "Sekreter girişi başarıyla gerçekleştirilmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

            }
            else if (kullanici_cmb.Text == "")
            {
                Business.ToastMessage(Color.LightPink, Color.DarkRed, "Hata !", "Lütfen bir kullanıcı seçiniz.", Properties.Resources.error);

            }
            else
            {
                Business.ToastMessage(Color.LightPink, Color.DarkRed, "Hata !", "Böyle bir kullanıcı bulunmamaktadır.", Properties.Resources.error);
            }

        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // Login ekranı - Üst Panelden tutularak formun hareket ettirilebilmesi için kod satırı -------başlangıç
        private bool dragging = false;
        private Point startpoint = new Point(0, 0);
        private void loginekran_ustpanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void loginekran_ustpnl_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                dragging = true;
                startpoint = new Point(e.X, e.Y);
            }
            else
            {
                dragging = true;
                startpoint = new Point(e.X, e.Y);
            }
        }

        private void loginekran_ustpnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startpoint.X, p.Y - this.startpoint.Y);
            }
        }

        private void reset_lbl_Click(object sender, EventArgs e)
        {
            kullanici_cmb.Text = "";
        }

        // Login ekranı - Üst Panelden tutularak formun hareket ettirilebilmesi için kod satırı -------bitiş
    }
}

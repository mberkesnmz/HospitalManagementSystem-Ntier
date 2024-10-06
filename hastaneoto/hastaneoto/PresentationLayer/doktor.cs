
using hastaneoto.dbConn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using hastaneoto;
using iTextSharp.text;
using iTextSharp.text.pdf;
using hastaneoto.PresentationLayer;
using System.Threading;
using ZedGraph;




namespace hastaneoto
{
    public partial class doktor : Form
    {
        public doktor()
        {
            InitializeComponent();
        }

        private void doktor_Load(object sender, EventArgs e)
        {
            // Buton tıklamalarında, sol tarafında çıkan panel
            select_anasayfa_pnl.Visible = true;
            select_grsmekytlr_pnl.Visible = false;
            select_randevularım_pnl.Visible = false;
            select_skrtryntm_pnl.Visible = false;
            anasayfapnl.Visible = true;
            randevularimpnl.Visible = false;
            gorusmekayitlarimpnl.Visible = false;
            dr_hesapdegistirpnl.Visible = false;
            Business.Hastasayisinagorebolumler_LoadGraph(zedGraphControl1);
            Business.Doktoragorehastasayisi_LoadGraph(zedGraphControl2);


        }

        private void ıconButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void oturumukapatbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            login lgn = new login();
            lgn.Show();
        }

        private void anasayfa_sidepnl_btn_Click(object sender, EventArgs e)
        {
            // Buton tıklamalarında, sol tarafında çıkan panel
            select_anasayfa_pnl.Visible=true;
            select_grsmekytlr_pnl.Visible=false;
            select_randevularım_pnl.Visible=false;
            select_skrtryntm_pnl.Visible=false;

            randevularimpnl.Visible = false;
            anasayfapnl.Visible = true;
            gorusmekayitlarimpnl.Visible = false;
            dr_hesapdegistirpnl.Visible = false;

            Business.Hastasayisinagorebolumler_LoadGraph(zedGraphControl1);
            Business.Doktoragorehastasayisi_LoadGraph(zedGraphControl2);

        }

        private void randevularım_sidepnl_btn_Click(object sender, EventArgs e)
        {
            // Buton tıklamalarında, sol tarafında çıkan panel
            select_anasayfa_pnl.Visible = false;
            select_grsmekytlr_pnl.Visible = false;
            select_randevularım_pnl.Visible = true;
            select_skrtryntm_pnl.Visible = false;

            randevularimpnl.Visible = true;
            anasayfapnl.Visible = false;
            gorusmekayitlarimpnl.Visible = false;
            dr_hesapdegistirpnl.Visible = false;

            Business.Doktor_Randevularim_Listele(dataGridView2, drtc_label.Text);
        }

        private void grsmekytlr_sidepnl_btn_Click(object sender, EventArgs e)
        {
            // Buton tıklamalarında, sol tarafında çıkan panel
            select_anasayfa_pnl.Visible = false;
            select_grsmekytlr_pnl.Visible = true;
            select_randevularım_pnl.Visible = false;
            select_skrtryntm_pnl.Visible = false;

            randevularimpnl.Visible = false;
            gorusmekayitlarimpnl.Visible = true;
            anasayfapnl.Visible = false;
            dr_hesapdegistirpnl.Visible = false;

            Business.Doktor_Goruslerim_Listele(dataGridView3, drtc_label.Text);
        }

 


        // Doktor ekranı - Üst Panelden tutularak formun hareket ettirilebilmesi için kod satırı -------başlangıç

        private bool dragging = false;
        private Point startpoint = new Point(0, 0);
        private void dr_ustpanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void dr_ustpanel_MouseDown(object sender, MouseEventArgs e)
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

        private void dr_ustpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startpoint.X, p.Y - this.startpoint.Y);
            }
        }
        // Doktor ekranı - Üst Panelden tutularak formun hareket ettirilebilmesi için kod satırı -------bitiş

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            
        }

 

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            randevuid_txt.Text = dataGridView2.CurrentRow.Cells["Randevu ID"].Value.ToString();

            if (dataGridView2.CurrentRow.Cells["Randevu Durum"].Value == null)
            { randevudurum_cmb.Text = ""; }
            else { randevudurum_cmb.Text = dataGridView2.CurrentRow.Cells["Randevu Durum"].Value.ToString(); }

            if (dataGridView2.CurrentRow.Cells["Kişisel Görüşüm"].Value == null)
            { kisiselg_richbox.Text = ""; }
            else { kisiselg_richbox.Text = dataGridView2.CurrentRow.Cells["Kişisel Görüşüm"].Value.ToString(); }

            if (dataGridView2.CurrentRow.Cells["Tahlil Sonucu"].Value == null)
            { tahlilsonuc_richbox.Text = ""; }
            else { tahlilsonuc_richbox.Text = dataGridView2.CurrentRow.Cells["Tahlil Sonucu"].Value.ToString(); }

        }

 


        private void randevularim_guncellebtn_Click(object sender, EventArgs e)
        {
            Business.Doktor_Randevularım_Guncelle(randevudurum_cmb.Text, kisiselg_richbox.Text, tahlilsonuc_richbox.Text, randevuid_txt.Text);
            Business.Doktor_Randevularim_Listele(dataGridView2, drtc_label.Text);
            // ToastMessage(Color.LightBlue, Color.DodgerBlue, "Bilgilendirme", "İşlem sürüyor...", Properties.Resources.info);
            Business.ToastMessage(Color.LightGreen, Color.SeaGreen, "Başarılı!", 
                "Güncelleme işlemi başarıyla gerçekleştirilmiştir.", Properties.Resources.success); //Sağ altta çıkan mesaj kutuları
        }

        private void dataGridView3_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            g_randevuid_txt.Text = dataGridView3.CurrentRow.Cells["Randevu ID"].Value.ToString();

            if (dataGridView3.CurrentRow.Cells["Randevu Durum"].Value == null)
            { g_randevudurum_cmb.Text = ""; }
            else { g_randevudurum_cmb.Text = dataGridView3.CurrentRow.Cells["Randevu Durum"].Value.ToString(); }

            if (dataGridView3.CurrentRow.Cells["Kişisel Görüşüm"].Value == null)
            { g_kisiselg_richbox.Text = ""; }
            else { g_kisiselg_richbox.Text = dataGridView3.CurrentRow.Cells["Kişisel Görüşüm"].Value.ToString(); }

            if (dataGridView3.CurrentRow.Cells["Tahlil Sonucu"].Value == null)
            { g_tahlilsonuc_richbox.Text = ""; }
            else { g_tahlilsonuc_richbox.Text = dataGridView3.CurrentRow.Cells["Tahlil Sonucu"].Value.ToString(); }

            gorusmekayitlarim_hastamail_txt.Text = dataGridView3.CurrentRow.Cells["Hasta E-Mail"].Value.ToString();
        }

        private void g_randevularim_guncellebtn_Click(object sender, EventArgs e)
        {
            Business.Doktor_Randevularım_Guncelle(g_randevudurum_cmb.Text, g_kisiselg_richbox.Text, g_tahlilsonuc_richbox.Text, g_randevuid_txt.Text);
            Business.Doktor_Goruslerim_Listele(dataGridView3, drtc_label.Text);
            Business.ToastMessage(Color.LightGreen, Color.SeaGreen, "Başarılı!", 
                "Güncelleme işlemi başarıyla gerçekleştirilmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

        }

        private void g_pdfolustur_Click(object sender, EventArgs e)
        {
            Business.PDF_Disa_Aktar(dataGridView3);
            Thread.Sleep(300);
            Business.ToastMessage(Color.LightGreen, Color.SeaGreen, "Başarılı!", 
                "PDF oluşturma işlemi başarıyla gerçekleştirilmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları
        }                                                                                                                                                     

            private void r_pdfolustur_Click(object sender, EventArgs e)
        {
            Business.PDF_Disa_Aktar(dataGridView2);
            Thread.Sleep(300);
            Business.ToastMessage(Color.LightGreen, Color.SeaGreen, "Başarılı!", 
                "PDF oluşturma işlemi başarıyla gerçekleştirilmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

        }

        private void dr_hesapdegistirsidepnl_btn_Click(object sender, EventArgs e)
        {
            // Buton tıklamalarında, sol tarafında çıkan panel
            select_anasayfa_pnl.Visible = false;
            select_grsmekytlr_pnl.Visible = false;
            select_randevularım_pnl.Visible = false;
            select_skrtryntm_pnl.Visible = true;

            randevularimpnl.Visible = false;
            anasayfapnl.Visible = false;
            gorusmekayitlarimpnl.Visible = false;
            dr_hesapdegistirpnl.Visible = true;

            Business.Doktor_Hesap_Listele(dataGridView4);

        }

        private void dr_hesapdegistir_btn_Click(object sender, EventArgs e)
        {
            if(drtc_label.Text == dataGridView4.CurrentRow.Cells["Doktor TC"].Value.ToString())
            {
                Business.ToastMessage(Color.LightBlue, Color.DodgerBlue, "Bilgilendirme !", "Zaten şuan "+ drtc_label.Text +
                    " TC'li doktor hesabındasınız !", Properties.Resources.info);
            }
            else { 
                drtc_label.Text = dataGridView4.CurrentRow.Cells["Doktor TC"].Value.ToString();
                doktoradlbl.Text = dataGridView4.CurrentRow.Cells["Doktor Ad"].Value.ToString();
                doktorsoyadlbl.Text = dataGridView4.CurrentRow.Cells["Doktor Soyad"].Value.ToString();
                Business.ToastMessage(Color.LightGreen, Color.SeaGreen, "Başarılı !",drtc_label.Text +
                    " TC'li doktor hesabına geçiş yapılmıştır !", Properties.Resources.success);
            }
        }

        private void hastayamailgonder_btn_Click(object sender, EventArgs e)
        {

            if (gorusmekayitlarim_hastamail_txt.Text =="" || gorusmekayitlarim_hastamail_txt.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Mail Adresi Yok !", 
                    "Hasta e-mail adresi bırakmamış.", Properties.Resources.error);
            }else if (g_tahlilsonuc_richbox.Text == "" || g_tahlilsonuc_richbox.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Alan Boş !", 
                    "Önce hastanın tahlil sonuçlarını giriniz.", Properties.Resources.error);
            }
            else if (g_kisiselg_richbox.Text == "" || g_kisiselg_richbox.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Alan Boş !", 
                    "Önce kişisel görüşünüzü giriniz.", Properties.Resources.error);
            }else { 
            Business.Kaydi_Hastayamailgonder(dataGridView3.CurrentRow.Cells["Randevu Durum"].Value.ToString(),g_randevuid_txt.Text,
                dataGridView3.CurrentRow.Cells["Hasta TC"].Value.ToString(),
                dataGridView3.CurrentRow.Cells["Randevu Tarih"].Value.ToString(),
                dataGridView3.CurrentRow.Cells["Randevu Saat"].Value.ToString(),
                gorusmekayitlarim_hastamail_txt.Text,
                g_tahlilsonuc_richbox.Text, g_kisiselg_richbox.Text);
                Business.ToastMessage(Color.LightGreen, Color.SeaGreen, "Başarılı !", drtc_label.Text + "Hastaya mail gönderilmiştir. !", Properties.Resources.success);
            }
        }


    }
}

using FontAwesome.Sharp;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;


namespace hastaneoto.PresentationLayer
{
    public partial class sekreter : Form
    {
        public sekreter()
        {
            InitializeComponent();
        }

        private void sekreter_Load(object sender, EventArgs e)
        {
            // Buton tıklamalarında, sol tarafında çıkan panel
            select_dryntm_pnl.Visible = false;
            select_hastayon_pnl.Visible = false;
            select_randvkyt_pnl.Visible = true;
            select_sekreteryntm_pnl.Visible = false;

            randevukayitpnl.Visible = true;
            doktoryonetimpnl.Visible = false;
            hastayonetimpnl.Visible = false;
            sekreteryonetimipnl.Visible = false;

            Business.Sekreter_Randevu_Listele(dataGridView1);
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

        private void rndvkyt_sidepnl_btn_Click(object sender, EventArgs e)
        {
            // Buton tıklamalarında, sol tarafında çıkan panel
            select_dryntm_pnl.Visible = false;
            select_hastayon_pnl.Visible = false;
            select_randvkyt_pnl.Visible = true;
            select_sekreteryntm_pnl.Visible = false;

            randevukayitpnl.Visible = true;
            doktoryonetimpnl.Visible = false;
            hastayonetimpnl.Visible = false;
            sekreteryonetimipnl.Visible = false;

            Business.Sekreter_Randevu_Listele(dataGridView1);

        }

        private void hstyntm_sidepnl_btn_Click(object sender, EventArgs e)
        {
            // Buton tıklamalarında, sol tarafında çıkan panel
            select_dryntm_pnl.Visible = false;
            select_hastayon_pnl.Visible = true;
            select_randvkyt_pnl.Visible = false;
            select_sekreteryntm_pnl.Visible = false;

            randevukayitpnl.Visible = false;
            doktoryonetimpnl.Visible = false;
            hastayonetimpnl.Visible = true;
            sekreteryonetimipnl.Visible = false;

            Business.Hasta_Listele(dataGridView4);
        }

        private void dryntm_sidepnl_btn_Click(object sender, EventArgs e)
        {
            // Buton tıklamalarında, sol tarafında çıkan panel
            select_dryntm_pnl.Visible = true;
            select_hastayon_pnl.Visible = false;
            select_randvkyt_pnl.Visible = false;
            select_sekreteryntm_pnl.Visible = false;

            randevukayitpnl.Visible = false;
            doktoryonetimpnl.Visible = true;
            hastayonetimpnl.Visible = false;
            sekreteryonetimipnl.Visible = false;

            Business.Doktor_Listele(dataGridView3);

        }

        private void skrtryntm_sidepnl_btn_Click(object sender, EventArgs e)
        {
            // Buton tıklamalarında, sol tarafında çıkan panel
            select_dryntm_pnl.Visible = false;
            select_hastayon_pnl.Visible = false;
            select_randvkyt_pnl.Visible = false;
            select_sekreteryntm_pnl.Visible = true;

            randevukayitpnl.Visible = false;
            doktoryonetimpnl.Visible = false;
            hastayonetimpnl.Visible = false;
            sekreteryonetimipnl.Visible = true;

            Business.Sekreter_Listele(dataGridView2);



        }



        private void randevu_saatsec_Click(object sender, EventArgs e)
        {
            if (randevukayit_uzmanliksecimi_cmb.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Branş Alanı Boş Bırakılamaz !", "Uzmanlık alanı seçimi yapınız.", Properties.Resources.error);
            }
            else if (randevukayit_doktorsecimitc_cmb.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Doktor Seçimi Yapınız !", "Buton yardımı ile doktorları listeleyiniz.", Properties.Resources.error);

            }
            else
            {
                saatsecimipnl.BringToFront();
                randevutakvim_tarihlbl.Text = randevutarih.Text;
                randevutakvim_drtc_lbl.Text = randevukayit_doktorsecimitc_cmb.Text;
                saatsecimipnl.Visible = true;
                Business.Randevu_Saatsecim_lbl(randevu_saatsec, randevusaat_9_10_btn, randevukayit_doktorsecimitc_cmb.Text, randevutarih.Text);
                Business.Randevu_Saatsecim_lbl(randevu_saatsec, randevusaat_10_11_btn, randevukayit_doktorsecimitc_cmb.Text, randevutarih.Text);
                Business.Randevu_Saatsecim_lbl(randevu_saatsec, randevusaat_11_12_btn, randevukayit_doktorsecimitc_cmb.Text, randevutarih.Text);
                Business.Randevu_Saatsecim_lbl(randevu_saatsec, randevusaat_13_14_btn, randevukayit_doktorsecimitc_cmb.Text, randevutarih.Text);
                Business.Randevu_Saatsecim_lbl(randevu_saatsec, randevusaat_14_15_btn, randevukayit_doktorsecimitc_cmb.Text, randevutarih.Text);
                Business.Randevu_Saatsecim_lbl(randevu_saatsec, randevusaat_15_16_btn, randevukayit_doktorsecimitc_cmb.Text, randevutarih.Text);
                Business.Randevu_Saatsecim_lbl(randevu_saatsec, randevusaat_16_17_btn, randevukayit_doktorsecimitc_cmb.Text, randevutarih.Text);
                Business.Randevu_Saatsecim_lbl(randevu_saatsec, randevusaat_17_18_btn, randevukayit_doktorsecimitc_cmb.Text, randevutarih.Text);
            }

        }

        private void ıconButton3_Click(object sender, EventArgs e)
        {
            saatsecimipnl.Visible = false;
            randevu_saatsec.Text = "Saat Seç";
        }

        private void ıconButton4_Click(object sender, EventArgs e)
        {
            saatsecimipnl.Visible = false;
        }

        // Sekreter ekranı - Üst Panelden tutularak formun hareket ettirilebilmesi için kod satırı -------başlangıç
        private bool dragging = false;
        private Point startpoint = new Point(0, 0);
        private void skrtr_ustpanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void skrtr_ustpanel_MouseDown(object sender, MouseEventArgs e)
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

        private void skrtr_ustpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startpoint.X, p.Y - this.startpoint.Y);
            }
        }
        // Sekreter ekranı - Üst Panelden tutularak formun hareket ettirilebilmesi için kod satırı -------bitiş

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            randevuka_hastatc_txt.Text = dataGridView1.CurrentRow.Cells["Hasta TC"].Value.ToString();
            randevuka_randevuid_txt.Text = dataGridView1.CurrentRow.Cells["Randevu ID"].Value.ToString();
        }

        private void randevuka_hastabilgigetir_btn_Click(object sender, EventArgs e)
        {
            Business.Sekreter_RandevuKayit_Hastabilgilerinigetir(randevuka_hastatc_txt.Text, randevuka_hastaad_txt, randevuka_hastasoyad_txt,
                randevuka_hastacinsiyet_txt, randevuka_hastaemail_txt, randevuka_hastatelno_txt);

        }

        private void randevukayit_ilgilibolumdoktorgetir_btn_Click(object sender, EventArgs e)
        {
            randevukayit_doktorsecimitc_cmb.Items.Clear();
            if (randevukayit_uzmanliksecimi_cmb.Text == "" || randevukayit_uzmanliksecimi_cmb.Text == null )
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Branş Alanı Boş Bırakılamaz !", "Uzmanlık alanı seçimi yapınız.", Properties.Resources.error);
            }
            else
            {
                Business.Sekreter_RandevuKayit_BolumDoktorgetir(randevukayit_uzmanliksecimi_cmb.Text, randevukayit_doktorsecimitc_cmb);
                Business.Sekreter_RandevuKayit_DrTcsinegoreadsoyadgetir(randevukayit_doktorsecimitc_cmb.Text, randevuka_doktorad_txt, randevuka_doktorsoyad_txt);

            }
        }

        private void randevukayit_uzmanliksecimi_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            randevuka_doktorad_txt.Text = "";
            randevuka_doktorsoyad_txt.Text = "";  // Branş değişikliği yapıldığında Doktor Seçimi Combobox'ının değeri sıfırlanmalı çünkü
            randevukayit_doktorsecimitc_cmb.Text = ""; // Randevu Kayıt Ekle butonu ile yanlış doktor-branş eşleşmesi yapılır
        }

        private void randevukayit_doktorsecimitc_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

            Business.Sekreter_RandevuKayit_DrTcsinegoreadsoyadgetir(randevukayit_doktorsecimitc_cmb.Text, randevuka_doktorad_txt, randevuka_doktorsoyad_txt);
        }

        private void randevukayit_ekle_btn_Click(object sender, EventArgs e)
        {
            //Randevu ekle butonu kontrolleri (boş değer olmamalı)
            if (randevuka_hastatc_txt.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Hasta TC Alanı Boş Olamaz !", "Hasta TC kimlik alanını doldurunuz.", Properties.Resources.error);
            }
            else if (randevuka_hastatc_kontrol.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Hasta TC alanını kontrol ediniz.", Properties.Resources.error);

            }
            else if (randevuka_hastaad_txt.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Hasta Ad Alanı Boş Olamaz !", "Hasta bilgilerini buton yardımı ile getiriniz.", Properties.Resources.error);
            }
            else if (randevuka_hastasoyad_txt.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Hasta Soyad Alanı Boş Olamaz !", "Hasta bilgilerini buton yardımı ile getiriniz.", Properties.Resources.error);
            }

            else if (randevukayit_uzmanliksecimi_cmb.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Uzmanlık Alanı Boş Olamaz !", "Branş seçimi yapınız.", Properties.Resources.error);
            }
            else if (randevukayit_doktorsecimitc_cmb.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Doktor Seçimi Boş Olamaz !", "Branşa ait doktorları buton yardımı ile getiriniz.", Properties.Resources.error);
            }
            else if (randevu_saatsec.Text == "SAAT SEÇ")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Saat Seçimi Yapınız !", "Uygun randevu aralığını seçiniz.", Properties.Resources.error);

            }
            else
            {
                Business.Sekreter_Randevu_Ekle(randevuka_hastatc_txt.Text, randevuka_hastaad_txt.Text, randevuka_hastasoyad_txt.Text, randevuka_hastaemail_txt.Text, randevutarih.Text,
                randevu_saatsec.Text, randevukayit_doktorsecimitc_cmb.Text, randevuka_doktorad_txt.Text, randevuka_doktorsoyad_txt.Text,
                randevukayit_uzmanliksecimi_cmb.Text);
                randevu_saatsec.Text = "SAAT SEÇ";
                Business.Sekreter_Randevu_Listele(dataGridView1);
                Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı !", "Randevu başarıyla oluşturulmuştur.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları


            }
        }

        private void randevukayit_guncelle_btn_Click(object sender, EventArgs e)
        {
            if (randevuka_hastaad_txt.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Hasta Ad Alanı Boş Olamaz !", 
                    "Hasta bilgilerini buton yardımı ile getiriniz.", Properties.Resources.error);
            }
            else if (randevuka_hastatc_txt.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Hasta TC Alanı Boş Olamaz !", 
                    "Hasta TC kimlik alanını doldurunuz.", Properties.Resources.error);
            }
            else if (randevuka_hastasoyad_txt.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Hasta Soyad Alanı Boş Olamaz !", 
                    "Hasta bilgilerini buton yardımı ile getiriniz.", Properties.Resources.error);
            }
            else if (randevukayit_uzmanliksecimi_cmb.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Uzmanlık Alanı Boş Olamaz !", 
                    "Branş seçimi yapınız.", Properties.Resources.error);
            }
            else if (randevukayit_doktorsecimitc_cmb.Text == "")
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Doktor Seçimi Boş Olamaz !", 
                    "Branşa ait doktorları buton yardımı ile getiriniz.", Properties.Resources.error);
            }
            else
            {
                Business.Sekreter_Randevu_Guncelle(randevuka_hastatc_txt.Text, randevuka_hastaad_txt.Text, randevuka_hastasoyad_txt.Text, randevuka_hastaemail_txt.Text,
                    randevutarih.Text, randevu_saatsec.Text, randevukayit_doktorsecimitc_cmb.Text, randevuka_doktorad_txt.Text, randevuka_doktorsoyad_txt.Text, 
                    randevukayit_uzmanliksecimi_cmb.Text, randevuka_randevuid_txt.Text);
                randevu_saatsec.Text = "SAAT SEÇ";
                Business.Sekreter_Randevu_Listele(dataGridView1);
                Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı!", 
                    "Randevu kayıt güncelleme işlemi gerçekleştirilmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları
            }
        }

        private void randevuka_hastatc_txt_TextChanged(object sender, EventArgs e)
        {
            randevuka_hastaad_txt.Text="";
            randevuka_hastasoyad_txt.Text = "";
            randevuka_hastacinsiyet_txt.Text = "";
            randevuka_hastaemail_txt.Text = "";
            randevuka_hastatelno_txt.Text = "";

            if (System.Text.RegularExpressions.Regex.IsMatch(randevuka_hastatc_txt.Text, @"\d{11}") && randevuka_hastatc_txt.Text.Length == 11)
            {
                randevuka_hastatc_kontrol.Visible = true;
                randevuka_hastatc_kontrol.IconChar = IconChar.Check;
                randevuka_hastatc_kontrol.IconColor = System.Drawing.Color.ForestGreen;
            }
            else
            {
                randevuka_hastatc_kontrol.Visible = true;
                randevuka_hastatc_kontrol.IconChar = IconChar.Ban;
                randevuka_hastatc_kontrol.IconColor = System.Drawing.Color.FromArgb(169, 29, 58);
            }
        }

        private void randevukayit_sil_btn_Click(object sender, EventArgs e)
        {
            Business.Sekreter_Randevu_Sil(randevuka_randevuid_txt.Text);
            Business.Sekreter_Randevu_Listele(dataGridView1);
            Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı!", "Randevu kayıt silme işlemi başarıyla gerçekleştirilmiştir.",
                Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

        }

        private void arrowrotateright_yenile_btn_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            Business.Sekreter_Randevu_Listele(dataGridView1);
            dataGridView1.Visible = true;
        }

        private void randevuka_pdfolustur_btn_Click(object sender, EventArgs e)
        {
            Business.PDF_Disa_Aktar(dataGridView1);
            Thread.Sleep(300);
            Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı!", "PDF oluşturma işlemi başarıyla gerçekleştirilmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları
        }


        private void randevusaat_9_10_btn_Click(object sender, EventArgs e)
        {
            if (randevusaat_9_10_btn.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Dolu!", "Saat " + randevusaat_9_10_btn.Text + " randevu aralığı doludur.", Properties.Resources.error);
            }
            else
            {
                randevu_saatsec.Text = randevusaat_9_10_btn.Text;
            }
        }

        private void randevusaat_10_11_btn_Click(object sender, EventArgs e)
        {
            if (randevusaat_10_11_btn.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Dolu!", "Saat " + randevusaat_10_11_btn.Text + " randevu aralığı doludur.", Properties.Resources.error);
            }
            else
            {
                randevu_saatsec.Text = randevusaat_10_11_btn.Text;
            }
        }

        private void randevusaat_11_12_btn_Click(object sender, EventArgs e)
        {
            if (randevusaat_11_12_btn.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Dolu!", "Saat " + randevusaat_11_12_btn.Text + " randevu aralığı doludur.", Properties.Resources.error);
            }
            else
            {
                randevu_saatsec.Text = randevusaat_11_12_btn.Text;
            }
        }

        private void randevusaat_13_14_btn_Click(object sender, EventArgs e)
        {
            if (randevusaat_13_14_btn.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Dolu!", "Saat " + randevusaat_13_14_btn.Text + " randevu aralığı doludur.", Properties.Resources.error);
            }
            else
            {
                randevu_saatsec.Text = randevusaat_13_14_btn.Text;
            }
        }

        private void randevusaat_14_15_btn_Click(object sender, EventArgs e)
        {
            if (randevusaat_14_15_btn.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Dolu!", "Saat " + randevusaat_14_15_btn.Text + " randevu aralığı doludur.", Properties.Resources.error);
            }
            else
            {
                randevu_saatsec.Text = randevusaat_14_15_btn.Text;
            }
        }

        private void randevusaat_15_16_btn_Click(object sender, EventArgs e)
        {
            if (randevusaat_15_16_btn.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Dolu!", "Saat " + randevusaat_15_16_btn.Text + " randevu aralığı doludur.", Properties.Resources.error);
            }
            else
            {
                randevu_saatsec.Text = randevusaat_15_16_btn.Text;
            }
        }

        private void randevusaat_16_17_btn_Click(object sender, EventArgs e)
        {
            if (randevusaat_16_17_btn.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Dolu!", "Saat " + randevusaat_16_17_btn.Text + " randevu aralığı doludur.", Properties.Resources.error);
            }
            else
            {
                randevu_saatsec.Text = randevusaat_16_17_btn.Text;
            }
        }

        private void randevusaat_17_18_btn_Click(object sender, EventArgs e)
        {
            if (randevusaat_17_18_btn.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata - Dolu!", "Saat " + randevusaat_17_18_btn.Text + " randevu aralığı doludur.", Properties.Resources.error);
            }
            else
            {
                randevu_saatsec.Text = randevusaat_17_18_btn.Text;
            }
        }

        private void skrtyntm_skrtr_telno_TextChanged(object sender, EventArgs e)
        {
            string text = skrtyntm_skrtr_telno.Text;
            string pattern = @"\d{10}";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(text);
            if (match.Success)
            {
                skrtyntm_skrtr_telno.Text = String.Format("{0:(###) ###-####}", Convert.ToInt64(text));

            }
            else
            {
                
            }
        }


        private void sekreter_yonetim_eklebtn_Click(object sender, EventArgs e)
        {
            if (skrtyntm_skrtr_tc.Text == "" || skrtyntm_skrtr_tc.Text == null )
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Sekreter TC alanı boş olamaz.", Properties.Resources.error);

            }else if (sekretertckontrol_icon.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Sekreter TC alanını kontrol ediniz.", Properties.Resources.error);

            }
            else if (skrtyntm_skrtr_ad.Text == "" || skrtyntm_skrtr_ad.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Sekreter Ad alanı boş olamaz.", Properties.Resources.error);

            }
            else if(skrtyntm_skrtr_soyad.Text == "" || skrtyntm_skrtr_soyad.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Sekreter Soyad alanı boş olamaz.", Properties.Resources.error);

            }
            else if (skrtyntm_skrtr_cinsiyet.Text == "" || skrtyntm_skrtr_cinsiyet.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Sekreter Cinsiyet alanı boş olamaz.", Properties.Resources.error);

            }else { 
            Business.Sekreter_Yonetim_Sekreter_Ekle(skrtyntm_skrtr_tc.Text, skrtyntm_skrtr_ad.Text, skrtyntm_skrtr_soyad.Text, 
                skrtyntm_skrtr_cinsiyet.Text, skrtyntm_skrtr_email.Text, skrtyntm_skrtr_telno.Text, skrtyntm_skrtr_adres.Text);
            Business.Sekreter_Listele(dataGridView2);
            }

        }
        //  skrtyntm_skrtr_telno_TextChanged'de Convert.ToInt64 olduğu için textbox (####### olduğunda hata veriyor. Bunun önüne geçmek için tüm texti sil
        private void skrtyntm_skrtr_telno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                skrtyntm_skrtr_telno.Text = "";
            }
        }

        private void skrtyntm_skrtr_tc_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(skrtyntm_skrtr_tc.Text, @"\d{11}") && skrtyntm_skrtr_tc.Text.Length == 11)
            {
                sekretertckontrol_icon.Visible = true;
                sekretertckontrol_icon.IconChar = IconChar.Check;
                sekretertckontrol_icon.IconColor = System.Drawing.Color.ForestGreen;
            }
            else
            {
                sekretertckontrol_icon.Visible = true;
                sekretertckontrol_icon.IconChar = IconChar.Ban;
                sekretertckontrol_icon.IconColor = System.Drawing.Color.FromArgb(169, 29, 58);
            }
        }



        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            skrtyntm_skrtr_tc.Text = dataGridView2.CurrentRow.Cells["Sekreter TC"].Value.ToString();
            skrtyntm_skrtr_ad.Text = dataGridView2.CurrentRow.Cells["Ad"].Value.ToString();
            skrtyntm_skrtr_soyad.Text = dataGridView2.CurrentRow.Cells["Soyad"].Value.ToString();
            skrtyntm_skrtr_cinsiyet.Text = dataGridView2.CurrentRow.Cells["Cinsiyet"].Value.ToString();
            skrtyntm_skrtr_email.Text = dataGridView2.CurrentRow.Cells["E-Mail"].Value.ToString();
            skrtyntm_skrtr_telno.Text = dataGridView2.CurrentRow.Cells["Telefon"].Value.ToString();
            skrtyntm_skrtr_adres.Text = dataGridView2.CurrentRow.Cells["Adres"].Value.ToString();

        }

        private void sekreter_yonetim_guncellebtn_Click(object sender, EventArgs e)
        {
            if (skrtyntm_skrtr_tc.Text == "" || skrtyntm_skrtr_tc.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Sekreter TC alanı boş olamaz.", Properties.Resources.error);

            }
            else if (sekretertckontrol_icon.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Sekreter TC alanını kontrol ediniz.", Properties.Resources.error);

            }
            else
            {
                Business.Sekreter_Guncelle(skrtyntm_skrtr_tc.Text, skrtyntm_skrtr_ad.Text, skrtyntm_skrtr_soyad.Text, 
                    skrtyntm_skrtr_cinsiyet.Text, skrtyntm_skrtr_email.Text, skrtyntm_skrtr_telno.Text, skrtyntm_skrtr_adres.Text);
                Business.Sekreter_Listele(dataGridView2);
            }

        }

        private void sekreter_yonetim_silbtn_Click(object sender, EventArgs e)
        {
            Business.Sekreter_Sil(skrtyntm_skrtr_tc.Text);
            Business.Sekreter_Listele(dataGridView2);
        }

        private void skrtyntm_skrtr_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                skrtyntm_skrtr_ad.Text = "";
                skrtyntm_skrtr_soyad.Text = "";
                skrtyntm_skrtr_cinsiyet.Text = "";
                skrtyntm_skrtr_email.Text = "";
                skrtyntm_skrtr_telno.Text = "";
                skrtyntm_skrtr_adres.Text = "";
            }
        }

        private void skrtr_hastayonetimi_ekle_btn_Click(object sender, EventArgs e)
        {
            if (skrtr_hastayonetimi_tc_txt.Text == "" || skrtr_hastayonetimi_tc_txt.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Hasta TC alanı boş olamaz.", Properties.Resources.error);

            }
            else if (hastatckontrol_icon.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Hasta TC alanını kontrol ediniz.", Properties.Resources.error);

            }
            else if (skrtr_hastayonetimi_ad_txt.Text == "" || skrtr_hastayonetimi_ad_txt.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Hasta Ad alanı boş olamaz.", Properties.Resources.error);

            }
            else if (skrtr_hastayonetimi_soyad_txt.Text == "" || skrtr_hastayonetimi_soyad_txt.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Hasta Soyad alanı boş olamaz.", Properties.Resources.error);

            }
            else if (skrtr_hastayonetimi_cinsiyet_cmb.Text == "" || skrtr_hastayonetimi_cinsiyet_cmb.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Hasta Cinsiyet alanı boş olamaz.", Properties.Resources.error);

            }
            else
            {
                Business.Hasta_Ekle(skrtr_hastayonetimi_tc_txt.Text, skrtr_hastayonetimi_ad_txt.Text, skrtr_hastayonetimi_soyad_txt.Text, 
                    skrtr_hastayonetimi_cinsiyet_cmb.Text, skrtr_hastayonetimi_email_txt.Text, skrtr_hastayonetimi_tel_txt.Text);
                Business.Hasta_Listele(dataGridView4);
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            skrtr_hastayonetimi_tc_txt.Text = dataGridView4.CurrentRow.Cells["Hasta TC"].Value.ToString();
            skrtr_hastayonetimi_ad_txt.Text = dataGridView4.CurrentRow.Cells["Ad"].Value.ToString();
            skrtr_hastayonetimi_soyad_txt.Text = dataGridView4.CurrentRow.Cells["Soyad"].Value.ToString();
            skrtr_hastayonetimi_cinsiyet_cmb.Text = dataGridView4.CurrentRow.Cells["Cinsiyet"].Value.ToString();
            skrtr_hastayonetimi_email_txt.Text = dataGridView4.CurrentRow.Cells["E-mail"].Value.ToString();
            skrtr_hastayonetimi_tel_txt.Text = dataGridView4.CurrentRow.Cells["Telefon"].Value.ToString();
        }

        private void skrtr_hastayonetimi_tc_txt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(skrtr_hastayonetimi_tc_txt.Text, @"\d{11}") && skrtr_hastayonetimi_tc_txt.Text.Length == 11)
            {
                hastatckontrol_icon.Visible = true;
                hastatckontrol_icon.IconChar = IconChar.Check;
                hastatckontrol_icon.IconColor = System.Drawing.Color.ForestGreen;
            }
            else
            {
                hastatckontrol_icon.Visible = true;
                hastatckontrol_icon.IconChar = IconChar.Ban;
                hastatckontrol_icon.IconColor = System.Drawing.Color.FromArgb(169, 29, 58);
            }
        }

        private void hastayonetimi_alanlaritemizle_Click(object sender, EventArgs e)
        {
            skrtr_hastayonetimi_tc_txt.Text = "";
            skrtr_hastayonetimi_ad_txt.Text = "";
            skrtr_hastayonetimi_soyad_txt.Text = "";
            skrtr_hastayonetimi_cinsiyet_cmb.Text = "";
            skrtr_hastayonetimi_email_txt.Text = "";
            skrtr_hastayonetimi_tel_txt.Text = "";
        }

        private void skrtr_hastayonetimi_tc_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                skrtr_hastayonetimi_ad_txt.Text = "";
                skrtr_hastayonetimi_soyad_txt.Text = "";
                skrtr_hastayonetimi_cinsiyet_cmb.Text = "";
                skrtr_hastayonetimi_email_txt.Text = "";
                skrtr_hastayonetimi_tel_txt.Text = "";
            }
        }

        private void skrtr_hastayonetimi_sil_btn_Click(object sender, EventArgs e)
        {
            Business.Hasta_Sil(skrtr_hastayonetimi_tc_txt.Text);
            Business.Hasta_Listele(dataGridView4);
        }

        private void skrtr_hastayonetimi_guncelle_btn_Click(object sender, EventArgs e)
        {
            if (skrtr_hastayonetimi_tc_txt.Text == "" || skrtr_hastayonetimi_tc_txt.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Hasta TC alanı boş olamaz.", Properties.Resources.error);

            }
            else if (hastatckontrol_icon.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Hasta TC alanını kontrol ediniz.", Properties.Resources.error);

            }
            else
            {
                Business.Hasta_Guncelle(skrtr_hastayonetimi_tc_txt.Text, skrtr_hastayonetimi_ad_txt.Text, skrtr_hastayonetimi_soyad_txt.Text, 
                    skrtr_hastayonetimi_cinsiyet_cmb.Text, skrtr_hastayonetimi_email_txt.Text, skrtr_hastayonetimi_tel_txt.Text);
                Business.Hasta_Listele(dataGridView4);
            }
        }

        private void hasta_arrowright_yenile_Click(object sender, EventArgs e)
        {
            Business.Hasta_Listele(dataGridView4);
        }

        private void hasta_pdfolustur_Click(object sender, EventArgs e)
        {
            Business.PDF_Disa_Aktar(dataGridView4);
            Thread.Sleep(300);
            Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı!", "PDF oluşturma işlemi başarıyla gerçekleştirilmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

        }

        private void skrtr_doktoryonetimi_ekle_btn_Click(object sender, EventArgs e)
        {
            if (skrtr_doktoryonetimi_tc_txt.Text == "" || skrtr_doktoryonetimi_tc_txt.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Doktor TC alanı boş olamaz.", Properties.Resources.error);

            }
            else if (doktortc_kontrol_icon.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Doktor TC alanını kontrol ediniz.", Properties.Resources.error);

            }
            else if (skrtr_doktoryonetimi_ad_txt.Text == "" || skrtr_doktoryonetimi_ad_txt.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Doktor Ad alanı boş olamaz.", Properties.Resources.error);

            }
            else if (skrtr_doktoryonetimi_soyad_txt.Text == "" || skrtr_doktoryonetimi_soyad_txt.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Doktor Soyad alanı boş olamaz.", Properties.Resources.error);

            }
            else if (skrtr_doktoryonetimi_cinsiyet_cmb.Text == "" || skrtr_doktoryonetimi_cinsiyet_cmb.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Doktor Cinsiyet alanı boş olamaz.", Properties.Resources.error);

            }
            else if (skrtr_doktoryonetimi_brans_cmb.Text == "" || skrtr_doktoryonetimi_brans_cmb.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", " Doktor Branş alanı boş olamaz.", Properties.Resources.error);

            }
            else
            {
                Business.Doktor_Ekle(skrtr_doktoryonetimi_tc_txt.Text, skrtr_doktoryonetimi_ad_txt.Text, skrtr_doktoryonetimi_soyad_txt.Text, 
                    skrtr_doktoryonetimi_cinsiyet_cmb.Text, skrtr_doktoryonetimi_brans_cmb.Text, skrtr_doktoryonetimi_mail_txt.Text,
                    skrtr_doktoryonetimi_tel_txt.Text, skrtr_doktoryonetimi_adres_txt.Text);
                Business.Doktor_Listele(dataGridView3);
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            skrtr_doktoryonetimi_tc_txt.Text = dataGridView3.CurrentRow.Cells["Doktor TC"].Value.ToString();
            skrtr_doktoryonetimi_ad_txt.Text = dataGridView3.CurrentRow.Cells["Ad"].Value.ToString();
            skrtr_doktoryonetimi_soyad_txt.Text = dataGridView3.CurrentRow.Cells["Soyad"].Value.ToString();
            skrtr_doktoryonetimi_cinsiyet_cmb.Text = dataGridView3.CurrentRow.Cells["Cinsiyet"].Value.ToString();
            skrtr_doktoryonetimi_brans_cmb.Text = dataGridView3.CurrentRow.Cells["Branş"].Value.ToString();
            skrtr_doktoryonetimi_mail_txt.Text = dataGridView3.CurrentRow.Cells["E-mail"].Value.ToString();
            skrtr_doktoryonetimi_tel_txt.Text = dataGridView3.CurrentRow.Cells["Telefon"].Value.ToString();
            skrtr_doktoryonetimi_adres_txt.Text = dataGridView3.CurrentRow.Cells["Adres"].Value.ToString();

        }

        private void skrtr_doktoryonetimi_tc_txt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(skrtr_doktoryonetimi_tc_txt.Text, @"\d{11}") && skrtr_doktoryonetimi_tc_txt.Text.Length == 11)
            {
                doktortc_kontrol_icon.Visible = true;
                doktortc_kontrol_icon.IconChar = IconChar.Check;
                doktortc_kontrol_icon.IconColor = System.Drawing.Color.ForestGreen;
            }
            else
            {
                doktortc_kontrol_icon.Visible = true;
                doktortc_kontrol_icon.IconChar = IconChar.Ban;
                doktortc_kontrol_icon.IconColor = System.Drawing.Color.FromArgb(169, 29, 58);
            }
        }

        private void skrtr_doktoryonetimi_tc_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                skrtr_doktoryonetimi_ad_txt.Text = "";
                skrtr_doktoryonetimi_soyad_txt.Text = "";
                skrtr_doktoryonetimi_cinsiyet_cmb.Text = "";
                skrtr_doktoryonetimi_brans_cmb.Text = "";
                skrtr_doktoryonetimi_mail_txt.Text = "";
                skrtr_doktoryonetimi_tel_txt.Text = "";
                skrtr_doktoryonetimi_adres_txt.Text = "";
            }
        }

        private void skrtr_doktoryonetimi_guncelle_btn_Click(object sender, EventArgs e)
        {
            if (skrtr_doktoryonetimi_tc_txt.Text == "" || skrtr_doktoryonetimi_tc_txt.Text == null)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !", 
                    " Doktor TC alanı boş olamaz.", Properties.Resources.error);

            }
            else if (doktortc_kontrol_icon.IconChar == IconChar.Ban)
            {
                Business.ToastMessage(System.Drawing.Color.LightPink, System.Drawing.Color.DarkRed, "Hata !",
                    " Doktor TC alanını kontrol ediniz.", Properties.Resources.error);

            }
            else
            {
                Business.Doktor_Guncelle(skrtr_doktoryonetimi_tc_txt.Text, skrtr_doktoryonetimi_ad_txt.Text, skrtr_doktoryonetimi_soyad_txt.Text,
                    skrtr_doktoryonetimi_cinsiyet_cmb.Text, skrtr_doktoryonetimi_brans_cmb.Text, skrtr_doktoryonetimi_mail_txt.Text,
                    skrtr_doktoryonetimi_tel_txt.Text, skrtr_doktoryonetimi_adres_txt.Text);
                Business.Doktor_Listele(dataGridView3);
            }
        }

        private void skrtr_doktoryonetimi_sil_btn_Click(object sender, EventArgs e)
        {
            Business.Doktor_Sil(skrtr_doktoryonetimi_tc_txt.Text);
            Business.Doktor_Listele(dataGridView3);
        }

        private void doktor_alanlarıtemizle_Click(object sender, EventArgs e)
        {
            skrtr_doktoryonetimi_tc_txt.Text = "";
            skrtr_doktoryonetimi_ad_txt.Text = "";
            skrtr_doktoryonetimi_soyad_txt.Text = "";
            skrtr_doktoryonetimi_cinsiyet_cmb.Text = "";
            skrtr_doktoryonetimi_brans_cmb.Text = "";
            skrtr_doktoryonetimi_mail_txt.Text = "";
            skrtr_doktoryonetimi_tel_txt.Text = "";
            skrtr_doktoryonetimi_adres_txt.Text = "";
        }

        private void doktor_pdfolustur_Click(object sender, EventArgs e)
        {
            Business.PDF_Disa_Aktar(dataGridView3);
            Thread.Sleep(300);
            Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı!", "PDF oluşturma işlemi başarıyla gerçekleştirilmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

        }

        private void doktor_arrowright_yenile_Click(object sender, EventArgs e)
        {
            Business.Doktor_Listele(dataGridView3);

        }

        private void skrtr_doktoryonetimi_tel_txt_TextChanged(object sender, EventArgs e)
        {
            string text = skrtr_doktoryonetimi_tel_txt.Text;
            string pattern = @"\d{10}";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(text);
            if (match.Success)
            {
                skrtr_doktoryonetimi_tel_txt.Text = String.Format("{0:(###) ###-####}", Convert.ToInt64(text));

            }
            else
            {

            }
        }

        private void skrtr_doktoryonetimi_tel_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                skrtr_doktoryonetimi_tel_txt.Text = "";
            }
        }

        private void skrtr_hastayonetimi_tel_txt_TextChanged(object sender, EventArgs e)
        {
            string text = skrtr_hastayonetimi_tel_txt.Text;
            string pattern = @"\d{10}";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(text);
            if (match.Success)
            {
                skrtr_hastayonetimi_tel_txt.Text = String.Format("{0:(###) ###-####}", Convert.ToInt64(text));

            }
            else
            {

            }
        }

        private void skrtr_hastayonetimi_tel_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                skrtr_hastayonetimi_tel_txt.Text = "";
            }
        }
    }
}




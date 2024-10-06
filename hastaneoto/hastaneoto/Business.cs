using hastaneoto.dbConn;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hastaneoto.PresentationLayer;
using hastaneoto;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Documents;
using System.Data.Common;
using System.Drawing;
using Org.BouncyCastle.Ocsp;
using FontAwesome.Sharp;
using System.Net.Mail;
using Org.BouncyCastle.Crypto.Macs;
using System.Threading;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using ZedGraph;


namespace hastaneoto
{
    public class Business
    {
        //Sağ altta çıkan mesaj kutuları
        public static void ToastMessage(Color backColor, Color color, string title, string text, System.Drawing.Image icon)
        {
            toastmessage frm = new toastmessage();
            frm.BackColor = backColor;
            frm.ColorToastMessage = color;
            frm.TitleToastMessage = title;
            frm.TextToastMessage = text;
            frm.IconeToastMessage = icon;
            frm.Show();
        }

            public static void Doktor_Randevularim_Listele(DataGridView datatable, string labeldrtc)
        {
            try
            {
                SqlDataAdapter da;
                veritabanibaglanti conn = new veritabanibaglanti();
                da = new SqlDataAdapter("SELECT randevu_id as 'Randevu ID',randevudurum as 'Randevu Durum', hasta_tcno as 'Hasta TC', " +
                    "hasta_Ad as 'Hasta Ad', hasta_soyad as 'Hasta Soyad', randevu_tarih as 'Randevu Tarih', randevu_saat as 'Randevu Saat', " +
                    "dr_tcno as 'Doktor TC', dr_ad as 'Doktor Ad', dr_soyad as 'Doktor Soyad', branş as 'Branş',"+
                    "doktor_kisiselgorus as 'Kişisel Görüşüm', tahlil_sonuc as 'Tahlil Sonucu' FROM randevuTbl " +
                    "WHERE randevudurum='Bekleniyor' AND dr_tcno="+labeldrtc, conn.baglanti);

                
                DataTable randevularim_tablo = new DataTable();
                da.Fill(randevularim_tablo);
                datatable.DataSource = randevularim_tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Connection Error!" + ex.ToString());

            }
            finally
            {

            }

        }

        public static void Doktor_Goruslerim_Listele(DataGridView datatable, string labeldrtc)
        {
            try
            {
                SqlDataAdapter da;
                veritabanibaglanti conn = new veritabanibaglanti();
                da = new SqlDataAdapter("SELECT randevu_id as 'Randevu ID',randevudurum as 'Randevu Durum', hasta_tcno as 'Hasta TC', " +
                    "hasta_Ad as 'Hasta Ad', hasta_soyad as 'Hasta Soyad', hasta_email as 'Hasta E-Mail', randevu_tarih as 'Randevu Tarih', randevu_saat as 'Randevu Saat', " +
                    "doktor_kisiselgorus as 'Kişisel Görüşüm', tahlil_sonuc as 'Tahlil Sonucu' " +
                    "FROM randevuTbl WHERE randevudurum NOT LIKE 'Bekleniyor' AND dr_tcno="+labeldrtc, conn.baglanti);
                DataTable randevularim_tablo = new DataTable();
                da.Fill(randevularim_tablo);
                datatable.DataSource = randevularim_tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Connection Error!" + ex.ToString());

            }
            finally
            {

            }

        }

        public static void Kaydi_Hastayamailgonder(string randevurum, string randevuid, string hsatatc, string tarih, string saat, 
            string hastamail, string tahlilsonuc, string kisiselgorus)
        {
            string fromMail = "ornek@gmail.com";  // Mail Adresiniz
            string fromPassword = ""; // Gmail üzerinden "APP PASSWORD" alınması gerekiyor, normal hesaba giriş şifrenizi yazmayacaksınız buraya!!

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Randevu ID: " + randevuid + " Görüşme Kayıtları - Sönmez Sağlık Özel Hastane";
            message.To.Add(new MailAddress(hastamail));
            message.Body = "<b>Randevu Durumu:</b> " + randevurum + "<br /><b>Hasta TC:</b> " +
                hsatatc + "<br /><b>Randevu Tarih:</b> " + tarih + "<br /><b>Randevu Saat:</b> " + saat 
                + "<br /><b>Doktor Kişisel Görüşü:</b>" + kisiselgorus + "<br /><b>Tahlil Sonucu:</b>" + tahlilsonuc;
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }

        public static void Doktor_Hesap_Listele(DataGridView datatable)
        {
            try
            {
                SqlDataAdapter da;
                veritabanibaglanti conn = new veritabanibaglanti();
                da = new SqlDataAdapter("SELECT dr_tcno as 'Doktor TC', dr_ad as 'Doktor Ad', dr_soyad as 'Doktor Soyad', " +
                    "dr_cinsiyet as 'Doktor Cinsiyet', branş as 'Branş', dr_email as 'E-Mail', dr_adres as 'Adres' FROM doktorTbl", conn.baglanti); 
                DataTable drhesap_tablo = new DataTable();
                da.Fill(drhesap_tablo);
                datatable.DataSource = drhesap_tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Connection Error!" + ex.ToString());

            }
            finally
            {

            }

        }


        public static void Doktor_Randevularım_Guncelle(string rd, string dkg, string ts, string rid)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand komut;
            string sorgu = "UPDATE randevuTbl SET randevudurum=@randevudurum, " +
                "doktor_kisiselgorus=@doktor_kisiselgorus,tahlil_sonuc=@tahlil_sonuc WHERE randevu_id=@randevu_id";
            komut = new SqlCommand(sorgu, conn.baglanti);
            komut.Parameters.AddWithValue("@randevudurum", rd);
            komut.Parameters.AddWithValue("@doktor_kisiselgorus", dkg);
            komut.Parameters.AddWithValue("@tahlil_sonuc", ts);
            komut.Parameters.AddWithValue("@randevu_id", Convert.ToInt32(rid));
            conn.baglanti.Open();
            komut.ExecuteNonQuery();
            conn.baglanti.Close();
        }

        public static void PDF_Disa_Aktar(DataGridView dataGridView1)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "PDF Dosyaları";
            save.DefaultExt = "pdf";
            save.Filter = "PDF Dosyaları (*.pdf)|*.pdf|Tüm Dosyalar(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);

                // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.
                pdfTable.DefaultCell.Padding = 3; // hücre duvarı ve veri arasında mesafe
                pdfTable.WidthPercentage = 100; // hücre genişliği
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT; // yazı hizalaması
                pdfTable.DefaultCell.BorderWidth = 1; // kenarlık kalınlığı
                // Bu alanlarla oynarak tasarımı iyileştirebilirsiniz.

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240); // hücre arka plan rengi
                    pdfTable.AddCell(cell);
                }
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                    }
                }
                catch (NullReferenceException)
                {
                }
                using (FileStream stream = new FileStream(save.FileName , FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);// sayfa boyutu.
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }

        //------------------------------------------------------------
        //---------SEKRETER------------------------------------------------------------
        //------------------------------------------------------------

        public static void Sekreter_Randevu_Listele(DataGridView datatable)
        {
            try
            {
                SqlDataAdapter da;
                veritabanibaglanti conn = new veritabanibaglanti();
                da = new SqlDataAdapter("SELECT randevu_id as 'Randevu ID',randevudurum as 'Randevu Durum', hasta_tcno as 'Hasta TC', " +
                     "randevu_tarih as 'Randevu Tarih', randevu_saat as 'Randevu Saat', " +
                    "dr_tcno as 'Doktor TC', dr_ad as 'Doktor Ad', dr_soyad as 'Doktor Soyad', branş as 'Branş'," +
                    "doktor_kisiselgorus as 'Kişisel Görüşüm', tahlil_sonuc as 'Tahlil Sonucu' FROM randevuTbl", conn.baglanti);



                DataTable sekreter_randevu_tablo = new DataTable();
                da.Fill(sekreter_randevu_tablo);
                datatable.DataSource = sekreter_randevu_tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Connection Error!" + ex.ToString());
            }
            finally{
            }
        }

        public static void Sekreter_RandevuKayit_Hastabilgilerinigetir(string aranacaktc, TextBox hastaad, TextBox hastasoyad, TextBox hastacinsiyet, TextBox hastaemail, TextBox hastatelno)
        {
            try
            {
                veritabanibaglanti conn = new veritabanibaglanti();
                SqlCommand sqlkomut = new SqlCommand("SELECT hasta_ad, hasta_soyad, hasta_cinsiyet, hasta_email, hasta_telno from hastaTbl" +
                    " WHERE hasta_tcno ='" + aranacaktc + "'", conn.baglanti);
                conn.baglanti.Open();
                SqlDataReader sqlDR = sqlkomut.ExecuteReader();

                if (sqlDR.HasRows == true)
                {
                    ToastMessage(Color.LightGreen, Color.SeaGreen, "Başarılı!", "Hasta bilgilerini getirme başarıyla gerçekleştirilmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

                }
                else
                {
                    ToastMessage(Color.LightPink, Color.DarkRed, "Hata - TC Alanını Kontrol Ediniz !", "Böyle bir hasta bulunmamaktadır", Properties.Resources.error);
                }

                while (sqlDR.Read())
                {
                    hastaad.Text = sqlDR["hasta_ad"].ToString();
                    hastasoyad.Text = sqlDR["hasta_soyad"].ToString();
                    hastacinsiyet.Text = sqlDR["hasta_cinsiyet"].ToString();
                    hastaemail.Text = sqlDR["hasta_email"].ToString();
                    hastatelno.Text = sqlDR["hasta_telno"].ToString();
                }
            }
            catch (Exception ex)
            {  MessageBox.Show("SQL Connection Error!" + ex.ToString()); }
            finally
            {
            }
        }

        public static void Sekreter_RandevuKayit_BolumDoktorgetir(string aranacakbrans, ComboBox drtcsecimi)
        {
            try
            {
                veritabanibaglanti conn = new veritabanibaglanti();
                SqlCommand sqlkomut = new SqlCommand("SELECT dr_tcno FROM doktorTbl" +
                    " WHERE branş ='" + aranacakbrans + "'", conn.baglanti);
                conn.baglanti.Open();
                SqlDataReader sqlDR = sqlkomut.ExecuteReader();


                if (sqlDR.HasRows == true)
                {
                    ToastMessage(Color.LightGreen, Color.SeaGreen, "Başarılı!", "Doktor bilgileri başarıyla getirilmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

                }
                else
                {
                    ToastMessage(Color.LightPink, Color.DarkRed, "Hata - Geçersiz Uzmanlık Alanı !", "Böyle bir branş bulunmamaktadır.", Properties.Resources.error);
                }

                while (sqlDR.Read())
                {
                    int dbFields = sqlDR.FieldCount;
                    for (int i = 0; i < dbFields; i++) {
                        drtcsecimi.Text = sqlDR[0].ToString();
                        drtcsecimi.Items.Add(sqlDR["dr_tcno"]); }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("SQL Connection Error!" + ex.ToString()); }
            finally
            {
            }
        }

        public static void Sekreter_RandevuKayit_DrTcsinegoreadsoyadgetir(string aranacaktc, TextBox drad, TextBox drsoyad )
        {
            try
            {
                veritabanibaglanti conn = new veritabanibaglanti();
                SqlCommand sqlkomut = new SqlCommand("SELECT dr_ad, dr_soyad FROM doktorTbl" +
                    " WHERE dr_tcno ='" + aranacaktc + "'", conn.baglanti);
                conn.baglanti.Open();
                SqlDataReader sqlDR = sqlkomut.ExecuteReader();

                while (sqlDR.Read())
                {
                        drad.Text = sqlDR["dr_ad"].ToString();
                        drsoyad.Text = sqlDR["dr_soyad"].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("SQL Connection Error!" + ex.ToString()); }
            finally
            {
            }
        }


        // Sekreter Kullanımında "Randevu Kayıt" Panelinden Randevu Ekleme
        public static void Sekreter_Randevu_Ekle(string hastatc, string hastaad, string hastasoyad, string hastamail,string randevutarih, 
            string randevusaat, string drtc, string drad, string drsoyad, string brans )
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand komut = new SqlCommand("INSERT INTO randevuTbl(randevudurum, hasta_tcno, hasta_ad, hasta_soyad, hasta_email, randevu_tarih," +
                "randevu_saat, dr_tcno, dr_ad, dr_soyad, branş) VALUES('Bekleniyor', @hasta_tcno, @hasta_ad, @hasta_soyad, @hasta_email, " +
                "@randevu_tarih, @randevu_saat, @dr_tcno, @dr_ad, @dr_soyad, @branş )", conn.baglanti);
            komut.Parameters.AddWithValue("@hasta_tcno", hastatc);
            komut.Parameters.AddWithValue("@hasta_ad", hastaad.ToUpper());
            komut.Parameters.AddWithValue("@hasta_soyad", hastasoyad.ToUpper());
            komut.Parameters.AddWithValue("@hasta_email", hastamail);
            komut.Parameters.AddWithValue("@randevu_tarih", DateTime.Parse(randevutarih));
            komut.Parameters.AddWithValue("@randevu_saat", randevusaat);
            komut.Parameters.AddWithValue("@dr_tcno", drtc);
            komut.Parameters.AddWithValue("@dr_ad", drad.ToUpper());
            komut.Parameters.AddWithValue("@dr_soyad", drsoyad.ToUpper());
            komut.Parameters.AddWithValue("@branş", brans);
            conn.baglanti.Open();
            komut.ExecuteNonQuery();
            conn.baglanti.Close();
        }


        // Sekreter Kullanımında "Randevu Kayıt" Panelinden Randevu Güncelleme
        public static void Sekreter_Randevu_Guncelle( string hastatc, string hastaad, string hastasoyad, string hastamail, 
            string randevutarih, string randevusaat, string drtc, string drad, string drsoyad, string brans, string randevuid)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand komut;
            string sorgu = "UPDATE randevuTbl SET hasta_tcno=@hasta_tcno,hasta_ad=@hasta_ad," +
                "hasta_soyad=@hasta_soyad, hasta_email=@hasta_email, randevu_tarih=@randevu_tarih," +
                "randevu_saat=@randevu_saat,dr_tcno=@dr_tcno,dr_ad=@dr_ad,dr_soyad=@dr_soyad,branş=@branş " +
                "WHERE randevu_id=@randevu_id";
            komut = new SqlCommand(sorgu, conn.baglanti);
            komut.Parameters.AddWithValue("@hasta_tcno", hastatc);
            komut.Parameters.AddWithValue("@hasta_ad", hastaad.ToUpper());
            komut.Parameters.AddWithValue("@hasta_soyad", hastasoyad.ToUpper());
            komut.Parameters.AddWithValue("@hasta_email", hastamail);
            komut.Parameters.AddWithValue("@randevu_tarih", DateTime.Parse(randevutarih)); // Convert.ToDateTime saat ile birlikte aldığı için ekleme-güncelleme 
            komut.Parameters.AddWithValue("@randevu_saat", randevusaat);                     //yaparken "randevu tarih" alanına YYYY/MM/D 00:00:00 olarak ekliyor 
            komut.Parameters.AddWithValue("@dr_tcno", drtc);                                    //veya değiştiriyor bu da benim veritabanımdaki değerimi bozuyor. 
            komut.Parameters.AddWithValue("@dr_ad", drad.ToUpper());                              //Tarihi sorgulatırken hata veriyor. Bu sorunumu DateTime.Parse ile çözdüm.
            komut.Parameters.AddWithValue("@dr_soyad", drsoyad.ToUpper());
            komut.Parameters.AddWithValue("@branş", brans);
            komut.Parameters.AddWithValue("@randevu_id", Convert.ToInt32(randevuid));
            conn.baglanti.Open();
            komut.ExecuteNonQuery();
            conn.baglanti.Close();
        }




        // Sekreter Kullanımında "Randevu Kayıt" Panelinden Randevu Silme
        public static void Sekreter_Randevu_Sil(string randevuid)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand komut;
            string sorgu = "DELETE FROM randevuTbl WHERE randevu_id=@randevu_id";
            komut = new SqlCommand(sorgu, conn.baglanti);
            komut.Parameters.AddWithValue("@randevu_id", Convert.ToInt32(randevuid));
            conn.baglanti.Open();
            komut.ExecuteNonQuery();
            conn.baglanti.Close();
        }


        // Sekreter kullanımında ki "Randevu Kayıt" Panelinde Saat Seçim Paneli
        public static void Randevu_Saatsecim_lbl(System.Windows.Forms.Label saatsecimilbl, IconButton randevusaatleribtn, string drtc, string randevutarih)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand sqlkomut = new SqlCommand("SELECT randevu_id  FROM randevuTbl" +
                " WHERE dr_tcno='"+drtc+ "' AND randevu_tarih=@randevu_tarih AND randevu_saat='"+ randevusaatleribtn.Text+"'", conn.baglanti);
            sqlkomut.Parameters.AddWithValue("@randevu_tarih", DateTime.Parse(randevutarih)); 
            conn.baglanti.Open();
            SqlDataReader sqlDR = sqlkomut.ExecuteReader();

            

            if (sqlDR.HasRows == true)
            {
                Btn_Red();

            }
            else
            {
                Btn_Green();
            }

            void Btn_Red()
             {
                randevusaatleribtn.IconChar = IconChar.Ban;
                randevusaatleribtn.IconColor = System.Drawing.Color.FromArgb(169, 29, 58);
                randevusaatleribtn.ForeColor = System.Drawing.Color.FromArgb(169, 29, 58);
                randevusaatleribtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(169, 29, 58);
                randevusaatleribtn.Cursor = Cursors.No;
             }

            void Btn_Green()
            {
                randevusaatleribtn.IconChar = IconChar.Check;
                randevusaatleribtn.IconColor = System.Drawing.Color.ForestGreen;
                randevusaatleribtn.ForeColor = System.Drawing.Color.ForestGreen;
                randevusaatleribtn.FlatAppearance.BorderColor = System.Drawing.Color.ForestGreen;
                randevusaatleribtn.Cursor = Cursors.Hand;
            }

        }

        /// SEKRETER YÖNETİMİ PANELİ
        //


        // Sekreter Kullanımında "Sekreter Yönetimi" Panelinden Sekreter Ekleme
        public static void Sekreter_Yonetim_Sekreter_Ekle(string skrtrtc, string skrtrad, string skrtrsoyad, string skrtrcinsiyet, string skrtremail, string skrtrtel, string adres)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand sqlkomut = new SqlCommand("SELECT * FROM sekreterTbl WHERE skrter_tcno=" + skrtrtc, conn.baglanti);

            conn.baglanti.Open();
            SqlDataReader sqlDR = sqlkomut.ExecuteReader();
            if (sqlDR.HasRows)
            {
                ToastMessage(Color.LightPink, Color.DarkRed, "Hata !", skrtrtc+" 'TC nolu sekreter bulunmaktadır.", Properties.Resources.error);
                conn.baglanti.Close();
            }
            else { 
                sqlDR.Close();
                SqlCommand komut = new SqlCommand("INSERT INTO sekreterTbl(skrter_tcno, skrter_ad, skrter_soyad, skrter_cinsiyet," +
                    "skrter_email, skrter_telno, skrter_adres) VALUES( @skrter_tcno, @skrter_ad, @skrter_soyad, @skrter_cinsiyet," +
                    "@skrter_email, @skrter_telno, @skrter_adres)", conn.baglanti);
                komut.Parameters.AddWithValue("@skrter_tcno", skrtrtc);
                komut.Parameters.AddWithValue("@skrter_ad", skrtrad.ToUpper());
                komut.Parameters.AddWithValue("@skrter_soyad", skrtrsoyad.ToUpper());
                komut.Parameters.AddWithValue("@skrter_cinsiyet", skrtrcinsiyet.ToUpper());
                komut.Parameters.AddWithValue("@skrter_email", skrtremail);
                komut.Parameters.AddWithValue("@skrter_telno",  skrtrtel);
                komut.Parameters.AddWithValue("@skrter_adres", adres);

                
                komut.ExecuteNonQuery();
                conn.baglanti.Close();
                Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı !", 
                    "Sekreter başarıyla eklenmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

            }

        }

        public static void Sekreter_Listele(DataGridView datatable)
        {
            try
            {
                SqlDataAdapter da;
                veritabanibaglanti conn = new veritabanibaglanti();
                da = new SqlDataAdapter("SELECT skrter_tcno as 'Sekreter TC',skrter_ad as 'Ad', skrter_soyad as 'Soyad', " +
                     "skrter_cinsiyet as 'Cinsiyet', skrter_email as 'E-mail', " +
                    "skrter_telno as 'Telefon', skrter_adres as 'Adres'" +
                    " FROM sekreterTbl", conn.baglanti);



                DataTable sekreter_tablo = new DataTable();
                da.Fill(sekreter_tablo);
                datatable.DataSource = sekreter_tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Connection Error!" + ex.ToString());
            }
            finally
            {
            }
        }


        // Sekreter Kullanımında "Sekreter Yönetimi" Panelinden Sekreter Güncelleme
        public static void Sekreter_Guncelle(string stcno, string sad, string ssoyad, string scinsiyet, string semail, string stel, string sadres)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand komut;
            SqlCommand komut2;
            string sorgu = "UPDATE sekreterTbl SET skrter_ad=@skrter_ad," +
                "skrter_soyad=@skrter_soyad,skrter_cinsiyet=@skrter_cinsiyet," +
                "skrter_email=@skrter_email,skrter_telno=@skrter_telno,skrter_adres=@skrter_adres " +
                "WHERE skrter_tcno=@skrter_tcno";
            string sorgu2 = "SELECT * FROM sekreterTbl WHERE skrter_tcno=@skrter_tcno";
            komut = new SqlCommand(sorgu, conn.baglanti);
            komut2 = new SqlCommand(sorgu2, conn.baglanti);
            conn.baglanti.Open();
            komut2.Parameters.AddWithValue("@skrter_tcno", stcno);

            SqlDataReader sqlDR2 = komut2.ExecuteReader();
            
            if (sqlDR2.HasRows == true)
            {
                sqlDR2.Close();
                komut.Parameters.AddWithValue("@skrter_tcno", stcno);
                komut.Parameters.AddWithValue("@skrter_ad", sad.ToUpper());
                komut.Parameters.AddWithValue("@skrter_soyad", ssoyad.ToUpper());
                komut.Parameters.AddWithValue("@skrter_cinsiyet", scinsiyet.ToUpper());
                komut.Parameters.AddWithValue("@skrter_email", semail);
                komut.Parameters.AddWithValue("@skrter_telno", stel);
                komut.Parameters.AddWithValue("@skrter_adres", sadres);
                
                komut.ExecuteNonQuery();
                conn.baglanti.Close();
            }
            else
            {
                conn.baglanti.Close();
                ToastMessage(Color.LightPink, Color.DarkRed, "Hata - TC Alanını Kontrol Ediniz !", "Böyle bir sekreter bulunmamaktadır.", Properties.Resources.error);
            }
        }

        // Sekreter Kullanımında "Sekreter Yönetimi" Panelinden Sekreter Silme
        public static void Sekreter_Sil(string stcno)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand komut;
            SqlCommand komut2;
            string sorgu = "DELETE FROM sekreterTbl WHERE skrter_tcno=@skrter_tcno";
            string sorgu2 = "SELECT * FROM sekreterTbl WHERE skrter_tcno=@skrter_tcno";
            komut = new SqlCommand(sorgu, conn.baglanti);
            komut2 = new SqlCommand(sorgu2, conn.baglanti);
            conn.baglanti.Open();
            komut2.Parameters.AddWithValue("@skrter_tcno", stcno);

            SqlDataReader sqlDR2 = komut2.ExecuteReader();

            if (sqlDR2.HasRows == true)
            {
                sqlDR2.Close();
                komut.Parameters.AddWithValue("@skrter_tcno", stcno);
                komut.ExecuteNonQuery();
                conn.baglanti.Close();
            }
            else
            {
                conn.baglanti.Close();
                ToastMessage(Color.LightPink, Color.DarkRed, "Hata - TC Alanını Kontrol Ediniz !", 
                    "Böyle bir sekreter bulunmamaktadır.", Properties.Resources.error);
            }
        }


        ///// HASTA YÖNETİMİ PANELİ
        ///
        // Sekreter Kullanımında "Hasta Yönetimi" Panelinden Hasta Ekleme
        public static void Hasta_Ekle(string hastatc, string hastaad, string hastasoyad, string hastacinsiyet, string hastaemail, string hastatel)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand sqlkomut = new SqlCommand("SELECT * FROM hastaTbl WHERE hasta_tcno=" + hastatc, conn.baglanti);

            conn.baglanti.Open();
            SqlDataReader sqlDR = sqlkomut.ExecuteReader();
            if (sqlDR.HasRows)
            {
                ToastMessage(Color.LightPink, Color.DarkRed, "Hata !", hastatc + " 'TC nolu hasta bulunmaktadır.", Properties.Resources.error);
                conn.baglanti.Close();
            }
            else
            {
                sqlDR.Close();
                SqlCommand komut = new SqlCommand("INSERT INTO hastaTbl(hasta_tcno, hasta_ad, hasta_soyad, hasta_cinsiyet," +
                    "hasta_email, hasta_telno) VALUES( @hasta_tcno, @hasta_ad, @hasta_soyad, @hasta_cinsiyet," +
                    "@hasta_email, @hasta_telno)", conn.baglanti);
                komut.Parameters.AddWithValue("@hasta_tcno", hastatc);
                komut.Parameters.AddWithValue("@hasta_ad", hastaad.ToUpper());
                komut.Parameters.AddWithValue("@hasta_soyad", hastasoyad.ToUpper());
                komut.Parameters.AddWithValue("@hasta_cinsiyet", hastacinsiyet.ToUpper());
                komut.Parameters.AddWithValue("@hasta_email", hastaemail);
                komut.Parameters.AddWithValue("@hasta_telno", hastatel);


                komut.ExecuteNonQuery();
                conn.baglanti.Close();
                Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı !", 
                    "Hasta başarıyla eklenmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

            }

        }

        public static void Hasta_Listele(DataGridView datatable)
        {
            try
            {
                SqlDataAdapter da;
                veritabanibaglanti conn = new veritabanibaglanti();
                da = new SqlDataAdapter("SELECT hasta_tcno as 'Hasta TC',hasta_ad as 'Ad', hasta_soyad as 'Soyad', " +
                     "hasta_cinsiyet as 'Cinsiyet', hasta_email as 'E-mail', " +
                    "hasta_telno as 'Telefon'" +
                    " FROM hastaTbl", conn.baglanti);

                DataTable hasta_tablo = new DataTable();
                da.Fill(hasta_tablo);
                datatable.DataSource = hasta_tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Connection Error!" + ex.ToString());
            }
            finally
            {
            }
        }


        // Sekreter Kullanımında "Hasta Yönetimi" Panelinden Hasta Güncelleme
        public static void Hasta_Guncelle(string htcno, string had, string hsoyad, string hcinsiyet, string hemail, string htel)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand komut;
            SqlCommand komut2;
            string sorgu = "UPDATE hastaTbl SET hasta_ad=@hasta_ad," +
                "hasta_soyad=@hasta_soyad,hasta_cinsiyet=@hasta_cinsiyet," +
                "hasta_email=@hasta_email,hasta_telno=@hasta_telno " +
                "WHERE hasta_tcno=@hasta_tcno";
            string sorgu2 = "SELECT * FROM hastaTbl WHERE hasta_tcno=@hasta_tcno";
            komut = new SqlCommand(sorgu, conn.baglanti);
            komut2 = new SqlCommand(sorgu2, conn.baglanti);
            conn.baglanti.Open();
            komut2.Parameters.AddWithValue("@hasta_tcno", htcno);

            SqlDataReader sqlDR2 = komut2.ExecuteReader();

            if (sqlDR2.HasRows == true)
            {
                sqlDR2.Close();
                komut.Parameters.AddWithValue("@hasta_tcno", htcno);
                komut.Parameters.AddWithValue("@hasta_ad", had.ToUpper());
                komut.Parameters.AddWithValue("@hasta_soyad", hsoyad.ToUpper());
                komut.Parameters.AddWithValue("@hasta_cinsiyet", hcinsiyet.ToUpper());
                komut.Parameters.AddWithValue("@hasta_email", hemail);
                komut.Parameters.AddWithValue("@hasta_telno", htel);
                komut.ExecuteNonQuery();
                conn.baglanti.Close();
                Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı !", 
                    htcno + "TC' li  hasta başarıyla güncellenmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

            }
            else
            {
                conn.baglanti.Close();
                ToastMessage(Color.LightPink, Color.DarkRed, "Hata - TC Alanını Kontrol Ediniz !", "Böyle bir hasta bulunmamaktadır.", Properties.Resources.error);
            }


        }

        // Sekreter Kullanımında "Hasta Yönetimi" Panelinden Hasta Silme
        public static void Hasta_Sil(string htcno)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand komut;
            SqlCommand komut2;
            string sorgu = "DELETE FROM hastaTbl WHERE hasta_tcno=@hasta_tcno";
            string sorgu2 = "SELECT * FROM hastaTbl WHERE hasta_tcno=@hasta_tcno";
            komut = new SqlCommand(sorgu, conn.baglanti);
            komut2 = new SqlCommand(sorgu2, conn.baglanti);
            conn.baglanti.Open();
            komut2.Parameters.AddWithValue("@hasta_tcno", htcno);

            SqlDataReader sqlDR2 = komut2.ExecuteReader();

            if (sqlDR2.HasRows == true)
            {
                sqlDR2.Close();
                komut.Parameters.AddWithValue("@hasta_tcno", htcno);
                komut.ExecuteNonQuery();
                conn.baglanti.Close();
                Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı !", 
                    htcno + "TC' li  hasta başarıyla silinmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

            }
            else
            {
                conn.baglanti.Close();
                ToastMessage(Color.LightPink, Color.DarkRed, "Hata - TC Alanını Kontrol Ediniz !", "Böyle bir hasta bulunmamaktadır.", Properties.Resources.error);
            }
        }


        ///// DOKTOR YÖNETİMİ PANELİ
        ///
        // Sekreter Kullanımında "Doktor Yönetimi" Panelinden Doktor Ekleme
        public static void Doktor_Ekle(string doktortc, string doktorad, string doktorsoyad, string doktorcinsiyet, string doktorbrans,
            string doktoremail, string doktortel, string doktoradres)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand sqlkomut = new SqlCommand("SELECT * FROM doktorTbl WHERE dr_tcno=" + doktortc, conn.baglanti);

            conn.baglanti.Open();
            SqlDataReader sqlDR = sqlkomut.ExecuteReader();
            if (sqlDR.HasRows)
            {
                ToastMessage(Color.LightPink, Color.DarkRed, "Hata !", doktortc + " 'TC nolu doktor bulunmaktadır.", Properties.Resources.error);
                conn.baglanti.Close();
            }
            else
            {
                sqlDR.Close();
                SqlCommand komut = new SqlCommand("INSERT INTO doktorTbl(dr_tcno, dr_ad, dr_soyad, dr_cinsiyet, branş, " +
                    "dr_email, dr_telno, dr_adres) VALUES( @dr_tcno, @dr_ad, @dr_soyad, @dr_cinsiyet," +
                    "@branş, @dr_email, @dr_telno, @dr_adres)", conn.baglanti);
                komut.Parameters.AddWithValue("@dr_tcno", doktortc);
                komut.Parameters.AddWithValue("@dr_ad", doktorad.ToUpper());
                komut.Parameters.AddWithValue("@dr_soyad", doktorsoyad.ToUpper());
                komut.Parameters.AddWithValue("@dr_cinsiyet", doktorcinsiyet.ToUpper());
                komut.Parameters.AddWithValue("@branş", doktorbrans);
                komut.Parameters.AddWithValue("@dr_email", doktoremail);
                komut.Parameters.AddWithValue("@dr_telno", doktortel);
                komut.Parameters.AddWithValue("@dr_adres", doktoradres);


                komut.ExecuteNonQuery();
                conn.baglanti.Close();
                Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı !", 
                    "Doktor başarıyla eklenmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları
            }
        }

        public static void Doktor_Listele(DataGridView datatable)
        {
            try
            {
                SqlDataAdapter da;
                veritabanibaglanti conn = new veritabanibaglanti();
                da = new SqlDataAdapter("SELECT dr_tcno as 'Doktor TC',dr_ad as 'Ad', dr_soyad as 'Soyad', " +
                     "dr_cinsiyet as 'Cinsiyet',branş as 'Branş', dr_email as 'E-mail', " +
                    "dr_telno as 'Telefon', dr_adres as 'Adres' " +
                    " FROM doktorTbl", conn.baglanti);

                DataTable doktor_tablo = new DataTable();
                da.Fill(doktor_tablo);
                datatable.DataSource = doktor_tablo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQL Connection Error!" + ex.ToString());
            }
            finally
            {
            }
        }


        // Sekreter Kullanımında "Doktor Yönetimi" Panelinden Doktor Güncelleme
        public static void Doktor_Guncelle(string dtcno, string dad, string dsoyad, string dcinsiyet, string dbrans, string demail, string dtel, string dadres)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand komut;
            SqlCommand komut2;
            string sorgu = "UPDATE doktorTbl SET dr_ad=@dr_ad," +
                "dr_soyad=@dr_soyad,dr_cinsiyet=@dr_cinsiyet, branş=@branş," +
                "dr_email=@dr_email,dr_telno=@dr_telno, dr_adres=@dr_adres " +
                " WHERE dr_tcno=@dr_tcno";
            string sorgu2 = "SELECT * FROM doktorTbl WHERE dr_tcno=@dr_tcno";
            komut = new SqlCommand(sorgu, conn.baglanti);
            komut2 = new SqlCommand(sorgu2, conn.baglanti);
            conn.baglanti.Open();
            komut2.Parameters.AddWithValue("@dr_tcno", dtcno);

            SqlDataReader sqlDR2 = komut2.ExecuteReader();

            if (sqlDR2.HasRows == true)
            {
                sqlDR2.Close();
                komut.Parameters.AddWithValue("@dr_tcno", dtcno);
                komut.Parameters.AddWithValue("@dr_ad", dad.ToUpper());
                komut.Parameters.AddWithValue("@dr_soyad", dsoyad.ToUpper());
                komut.Parameters.AddWithValue("@dr_cinsiyet", dcinsiyet.ToUpper());
                komut.Parameters.AddWithValue("@branş", dbrans.ToUpper());
                komut.Parameters.AddWithValue("@dr_email", demail);
                komut.Parameters.AddWithValue("@dr_telno", dtel);
                komut.Parameters.AddWithValue("@dr_adres", dadres);
                komut.ExecuteNonQuery();
                conn.baglanti.Close();
                Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı !", 
                    dtcno + "TC' li  doktor başarıyla güncellenmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

            }
            else
            {
                conn.baglanti.Close();
                ToastMessage(Color.LightPink, Color.DarkRed, "Hata - TC Alanını Kontrol Ediniz !", "Böyle bir doktor bulunmamaktadır.", Properties.Resources.error);
            }
        }

        // Sekreter Kullanımında "Doktor Yönetimi" Panelinden Doktor Silme
        public static void Doktor_Sil(string dtcno)
        {
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand komut;
            SqlCommand komut2;
            string sorgu = "DELETE FROM doktorTbl WHERE dr_tcno=@dr_tcno";
            string sorgu2 = "SELECT * FROM doktorTbl WHERE dr_tcno=@dr_tcno";
            komut = new SqlCommand(sorgu, conn.baglanti);
            komut2 = new SqlCommand(sorgu2, conn.baglanti);
            conn.baglanti.Open();
            komut2.Parameters.AddWithValue("@dr_tcno", dtcno);

            SqlDataReader sqlDR2 = komut2.ExecuteReader();

            if (sqlDR2.HasRows == true)
            {
                sqlDR2.Close();
                komut.Parameters.AddWithValue("@dr_tcno", dtcno);
                komut.ExecuteNonQuery();
                conn.baglanti.Close();
                Business.ToastMessage(System.Drawing.Color.LightGreen, System.Drawing.Color.SeaGreen, "Başarılı !", 
                    dtcno + "TC' li  doktor başarıyla silinmiştir.", Properties.Resources.success);//Sağ altta çıkan mesaj kutuları

            }
            else
            {
                conn.baglanti.Close();
                ToastMessage(Color.LightPink, Color.DarkRed, "Hata - TC Alanını Kontrol Ediniz !", 
                    "Böyle bir doktor bulunmamaktadır.", Properties.Resources.error);
            }
        }

        /// ANA SAYFA ZED GRAPH
        //
        public static void Hastasayisinagorebolumler_LoadGraph(ZedGraphControl zedgraph)
        {
            
            string query = "SELECT COUNT(randevu_id )as 'Hasta Sayısı' , branş as Bölümler FROM randevuTbl group by branş ";

            DataTable dataTable = new DataTable();
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand command = new SqlCommand(query, conn.baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.baglanti.Open();
            adapter.Fill(dataTable);

            GraphPane myPane = zedgraph.GraphPane;

            // Grafiği temizleyin
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            myPane.Title.Text = "Hasta Sayısı - Branşlar";
            myPane.XAxis.Title.Text = "Branş";
            myPane.YAxis.Title.Text = "Hasta Sayısı";
           


            string[] labels = new string[dataTable.Rows.Count];
            double[] values = new double[dataTable.Rows.Count];

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                labels[i] = dataTable.Rows[i]["Bölümler"].ToString();
                values[i] = Convert.ToDouble(dataTable.Rows[i]["Hasta Sayısı"]);
            }

            // BarItem eklemek için myPane.AddBar metodunu kullanıyoruz
           
            myPane.AddBar("Hasta Sayısı", null, values, Color.Blue);

            myPane.XAxis.Type = AxisType.Text;
            myPane.XAxis.Scale.TextLabels = labels;
            myPane.XAxis.Scale.FontSpec.Angle = 90; // İsteğe bağlı: X ekseni etiketlerini dikey yapar.

            zedgraph.AxisChange();
            zedgraph.Invalidate();

        }

        public static void Doktoragorehastasayisi_LoadGraph(ZedGraphControl zedgraph)
        {

            string query = "SELECT COUNT(randevu_id )as 'Hasta Sayısı' , CONCAT(dr_ad, ' - ', dr_tcno) " +
                "AS 'Doktor Bilgisi' FROM randevuTbl group by dr_ad, dr_tcno\r\n";

            DataTable dataTable = new DataTable();
            veritabanibaglanti conn = new veritabanibaglanti();
            SqlCommand command = new SqlCommand(query, conn.baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            conn.baglanti.Open();
            adapter.Fill(dataTable);

            GraphPane myPane = zedgraph.GraphPane;

            // Grafiği temizleyin
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            myPane.Title.Text = "Hasta Sayısı - Doktorlar";
            myPane.XAxis.Title.Text = "Doktor Bilgisi";
            myPane.YAxis.Title.Text = "Hasta Sayısı";



            string[] labels = new string[dataTable.Rows.Count];
            double[] values = new double[dataTable.Rows.Count];

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                labels[i] = dataTable.Rows[i]["Doktor Bilgisi"].ToString();
                values[i] = Convert.ToDouble(dataTable.Rows[i]["Hasta Sayısı"]);
            }

            // BarItem eklemek için myPane.AddBar metodunu kullanıyoruz

            myPane.AddBar("Hasta Sayısı", null, values, Color.Blue);

            myPane.XAxis.Type = AxisType.Text;
            myPane.XAxis.Scale.TextLabels = labels;
            myPane.XAxis.Scale.FontSpec.Angle = 90; // İsteğe bağlı: X ekseni etiketlerini dikey yapar.

            zedgraph.AxisChange();
            zedgraph.Invalidate();

        }

    }
}

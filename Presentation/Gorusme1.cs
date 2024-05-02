using iText.Kernel.Geom;
using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Presentation
{
    public partial class Gorusme1 : Form
    {
        private Business.Mail mail = new Business.Mail();
        private Business.Randevu randevu = new Business.Randevu();
        private Business.Sırala sırala = new Business.Sırala();
        public string kim;

        /*   public Gorusme1(string kimlik, string brans)
          {
              label7.Text = kimlik;
              kim = brans;
              InitializeComponent();
          }*/
        public Gorusme1(string kimlik, string brans)
        {
            InitializeComponent();
            label7.Text = kimlik;
            kim = brans;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                void KontrolBilgileriniEkle(Control control, PdfPTable pdfxTablosu)
                {
                    PdfPCell pdfHucresi = new PdfPCell();
                    pdfHucresi.Border = PdfPCell.NO_BORDER;
                    pdfHucresi.Padding = 5f;

                    if (control is Label)
                    {
                        Label label = (Label)control;

                        pdfHucresi.Phrase = new Phrase(
                                                       $"Hasta Bilgisi: {label.Text}");
                    }
                    else if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;

                        pdfHucresi.Phrase = new Phrase(
                                                       $"İçerik: {textBox.Text}");
                    }
                    else if (control is RichTextBox)
                    {
                        RichTextBox richTextBox = (RichTextBox)control;

                        pdfHucresi.Phrase = new Phrase(
                                                       $"{richTextBox.Text}");
                    }

                    pdfxTablosu.AddCell(pdfHucresi);
                }

                // PDF oluşturma işlemi
                PdfPTable pdfTablosu = new PdfPTable(1); // Tek sütun olacak
                pdfTablosu.DefaultCell.Padding = 3;
                pdfTablosu.WidthPercentage = 100;
                pdfTablosu.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;

                foreach (Control control in groupBox2.Controls)
                {
                    if (control is GroupBox)
                    {
                        GroupBox groupBox = (GroupBox)control;
                        foreach (Control innerControl in groupBox.Controls)
                        {
                            KontrolBilgileriniEkle(innerControl, pdfTablosu);
                        }
                    }
                    else
                    {
                        KontrolBilgileriniEkle(control, pdfTablosu);
                    }
                }

                SaveFileDialog pdfkaydetme = new SaveFileDialog();
                pdfkaydetme.Filter = "PDF Dosyaları|*.pdf";
                pdfkaydetme.Title = "PDF Olarak Kaydet";
                if (pdfkaydetme.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(pdfkaydetme.FileName, FileMode.Create))
                    {
                        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 5f, 5f, 11f, 10f);
                        iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDosya, stream);
                        pdfDosya.Open();
                        pdfDosya.Add(pdfTablosu);
                        pdfDosya.Close();
                        stream.Close();
                        MessageBox.Show("PDF dosyası başarıyla oluşturuldu!\n" + "Dosya Konumu: " + pdfkaydetme.FileName, "İşlem Tamam");
                    }
                }

            }
            /*string richTextBoxText1 = groupBox2;


            {

                PdfPTable pdfTablosu = new PdfPTable(1);
                pdfTablosu.DefaultCell.Padding = 3;
                pdfTablosu.WidthPercentage = 100;
                pdfTablosu.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;


                PdfPCell pdfHucresi = new PdfPCell(new Phrase(groupBox2));
                pdfTablosu.AddCell(pdfHucresi);
                SaveFileDialog pdfkaydetme = new SaveFileDialog();
                pdfkaydetme.Filter = "PDF Dosyaları|*.pdf";
                pdfkaydetme.Title = "PDF Olarak Kaydet";
                if (pdfkaydetme.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(pdfkaydetme.FileName, FileMode.Create))
                    {
                        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 5f, 5f, 11f, 10f);
                        iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDosya, stream);
                        pdfDosya.Open();
                        pdfDosya.Add(pdfTablosu);
                        pdfDosya.Close();
                        stream.Close();
                        MessageBox.Show("PDF dosyası başarıyla oluşturuldu!\n" + "Dosya Konumu: " + pdfkaydetme.FileName, "İşlem Tamam");

                        pdfDosya.Add(pdfTablosu);

                        pdfDosya.Close();
                        stream.Close();
                        MessageBox.Show("PDF dosyası başarıyla oluşturuldu!\n" + "Dosya Konumu: output.pdf", "İşlem Tamam");
                    }

            */

            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }

        }

        private static void GroupBoxIcerigiEkle(GroupBox groupBox, PdfPTable pdfTablosu)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is Label)
                {
                    Label label = (Label)control;

                    PdfPCell pdfEtiketAdiHucresi = new PdfPCell(new Phrase("Etiket Adı: " + label.Name));
                    pdfTablosu.AddCell(pdfEtiketAdiHucresi);

                    PdfPCell pdfIcerikHucresi = new PdfPCell(new Phrase("İçerik: " + label.Text));
                    pdfTablosu.AddCell(pdfIcerikHucresi);
                }
                else if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;

                    PdfPCell pdfEtiketAdiHucresi = new PdfPCell(new Phrase("Etiket Adı: " + textBox.Name));
                    pdfTablosu.AddCell(pdfEtiketAdiHucresi);

                    PdfPCell pdfIcerikHucresi = new PdfPCell(new Phrase("İçerik: " + textBox.Text));
                    pdfTablosu.AddCell(pdfIcerikHucresi);
                }
                else if (control is RichTextBox)
                {
                    RichTextBox richTextBox = (RichTextBox)control;

                    PdfPCell pdfEtiketAdiHucresi = new PdfPCell(new Phrase("Etiket Adı: " + richTextBox.Name));
                    pdfTablosu.AddCell(pdfEtiketAdiHucresi);

                    PdfPCell pdfIcerikHucresi = new PdfPCell(new Phrase("İçerik: " + richTextBox.Text));
                    pdfTablosu.AddCell(pdfIcerikHucresi);
                }
                else if (control is GroupBox)
                {
                    GroupBoxIcerigiEkle((GroupBox)control, pdfTablosu);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            EskiKayıtlar doktor = new EskiKayıtlar(label7.Text);
            doktor.StartPosition = FormStartPosition.CenterScreen;
            doktor.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> liste = new List<string>();
            try
            {
                string gorus = ("Tanı : \n" + richTextBox1.Text + "\n\nGörüş: \n" + richTextBox2.Text + "\n\nTahlil: \n" + richTextBox3.Text);
             mail.SendMail(liste, label7.Text,"X Devlet Hastanesi", gorus);
                 MessageBox.Show("Mail Gönderildi");
            }
            catch
            {
                MessageBox.Show("Hata");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            randevu.RandevuKaydet(  label7.Text,richTextBox1.Text, richTextBox2.Text, richTextBox3.Text,kim);
            MessageBox.Show("Görüşme Kaydedildi");

        }

        private void Gorusme1_Load(object sender, EventArgs e)
        {
            List<string> liste = new List<string>();

            sırala.HastaSırala(label7.Text, liste);
            label8.Text = liste[0];
            label9.Text = liste[1];
            label10.Text = liste[2];
            label14.Text = liste[3];
            label6.Text = liste[4];


        }
    }
}

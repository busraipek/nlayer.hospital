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
//using iText;
//using iText.IO;
//using iTextSharp.text;
//using iTextSharp.text.pdf;

namespace Presentation
{
    public partial class Gorusme1 : Form
    {
        private Business.Mail mail = new Business.Mail();
        private Business.Randevu randevu = new Business.Randevu();
        public Gorusme1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //PdfPTable pdfTablosu = new PdfPTable(dataGridView1.ColumnCount);
                //pdfTablosu.DefaultCell.Padding = 3;
                //pdfTablosu.WidthPercentage = 100;
                //pdfTablosu.HorizontalAlignment = Element.ALIGN_LEFT;
                //pdfTablosu.DefaultCell.BorderWidth = 1;
                //foreach (DataGridViewColumn sutun in dataGridView1.Columns)
                //{
                //    PdfPCell pdfHucresi = new PdfPCell(new Phrase(sutun.HeaderText));
                //    pdfTablosu.AddCell(pdfHucresi);
                //}
                //foreach (DataGridViewRow satir in dataGridView1.Rows)
                //{
                //    foreach (DataGridViewCell cell in satir.Cells)
                //    {
                //        pdfTablosu.AddCell(cell.Value.ToString());
                //    }
                //}

                //SaveFileDialog pdfkaydetme = new SaveFileDialog();
                //pdfkaydetme.Filter = "PDF Dosyaları|*.pdf";
                //pdfkaydetme.Title = "PDF Olarak Kaydet";
                //if (pdfkaydetme.ShowDialog() == DialogResult.OK)
                //{
                //    using (FileStream stream = new FileStream(pdfkaydetme.FileName, FileMode.Create))
                //    {
                //        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document(PageSize.A4, 5f, 5f, 11f, 10f);
                //        iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDosya, stream);
                //        pdfDosya.Open();
                //        pdfDosya.Add(pdfTablosu);
                //        pdfDosya.Close();
                //        stream.Close();
                //        MessageBox.Show("PDF dosyası başarıyla oluşturuldu!\n" + "Dosya Konumu: " + pdfkaydetme.FileName, "İşlem Tamam");
                //    }
                //}
            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EskiKayıtlar doktor = new EskiKayıtlar();
            doktor.StartPosition = FormStartPosition.CenterScreen;
            doktor.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> liste = new List<string>();
            mail.SendMail(liste, label10.Text,"tanı", "gorus");
            //HATA
        }

        private void button1_Click(object sender, EventArgs e)
        {
            randevu.RandevuKaydet(label10.Text, richTextBox1.Text, richTextBox2.Text, richTextBox3.Text, label13.Text);
            //HATA
        }

    }
}

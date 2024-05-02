using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Giris1 : Form
    {
        private string ad = "ad";
        private string kimlikno = "kimlik";
        private Business.Giris giris = new Business.Giris();

        public Giris1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
                if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("Kullanıcı adı ve şifre gereklidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    int sayı = 0;

                    giris.GirisYap(textBox3.Text, textBox4.Text, ref ad, ref kimlikno, ref sayı);

                    if (sayı == 1)
                    {
                        while (progressBar2.Value < 100)
                        {

                            progressBar2.Value = +progressBar1.Value + 100;

                        }
                        if (progressBar2.Value == 100)
                        {
                            MessageBox.Show("Giriş Yapılıyor");
                            progressBar2.Value = 0;
                        }
                            Doktor doktor = new Doktor(kimlikno);
                            doktor.Show();
                    }
                    else if (sayı == 2)
                    {
                        while (progressBar2.Value < 100)
                        {

                            progressBar2.Value = +progressBar1.Value + 100;

                        }
                        if (progressBar2.Value == 100)
                        {
                            MessageBox.Show("Yanlış Giriş Yaptınız Tekrar Deneyin");
                            progressBar2.Value = 0;
                        }
                    
                        return;
                    }
                    else
                    {
                        while (progressBar2.Value < 100)
                        {

                            progressBar2.Value = +progressBar1.Value + 100;

                        }
                        if (progressBar2.Value == 100)
                        {
                            MessageBox.Show("Hatalı Kimlik Numarası Girdiniz");
                            progressBar2.Value = 0;
                        }
                        textBox1.Clear();
                            textBox2.Clear();
                            return;
                    }
                this.Close();
            } 

            }

        private void Giris1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaGiriş anagiris = new AnaGiriş();
            anagiris.Show();
            this.Close();
        }
    }
    }

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
        public string ad="ad";
        public string kimlikno="kimlik";
        private Business.Giris giris = new Business.Giris();

        public Giris1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre gereklidir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int sayı = 0;
                
                giris.GirisYap(textBox1.Text, textBox2.Text, ad, kimlikno,ref sayı);

                if (sayı == 1)
                {
                    Gorusme1 gorusme = new Gorusme1();
                    gorusme.Show();
                }
                else if (sayı==2)
                {
                    Sekreter1 sekreter = new Sekreter1();
                    sekreter.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı kimlik numarası veya şifre. Tekrar deneyin");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }

        }

        private void Giris1_Load(object sender, EventArgs e)
        {
            BackColor = Color.DarkTurquoise;

        }
    }
}

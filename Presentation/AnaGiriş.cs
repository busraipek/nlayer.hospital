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
    public partial class AnaGiriş : Form
    {
        public AnaGiriş()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Giris1"] == null)
            {
                Giris1 giris1Form = new Giris1();
                giris1Form.Show();
            }
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Giris2"] == null)
            {
                Giris2 giris1Form = new Giris2();
                giris1Form.Show();
            }
            this.Hide();
        }

        private void AnaGiriş_Load(object sender, EventArgs e)
        {

        }
    }
}

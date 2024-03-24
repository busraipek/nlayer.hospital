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
    public partial class Doktor : Form
    {            
        Giris1 giris = new Giris1();

        public Doktor()
        {
            InitializeComponent();
        }

        private void Doktor_Load(object sender, EventArgs e)
        {
            label7.Text = DateTime.Today.ToLongDateString();
            dataGridView1.DataSource = dataGridView1;

        }
    }
}

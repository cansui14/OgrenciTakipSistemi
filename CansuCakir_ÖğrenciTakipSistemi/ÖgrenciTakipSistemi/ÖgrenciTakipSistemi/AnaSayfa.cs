using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ÖgrenciTakipSistemi
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Okul_Takip oo = new Okul_Takip();
            oo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ÖgrenciTakip pp = new ÖgrenciTakip();
           pp.Show();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {

        }
    }
}

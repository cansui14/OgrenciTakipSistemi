using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ÖgrenciTakipSistemi
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            string tc = maskedTextBox1.Text;
            string sifre = textBox2.Text;
            con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source =.\\Veritabanim.mdb");//baglanti
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kullanici_kayit where tc='" + maskedTextBox1.Text + "' AND sifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                AnaSayfa dp = new AnaSayfa();
                dp.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }

            con.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label3.Left > -340)
            {
                label3.Left -= 1;
            }
            else
            {
                label3.Left = 700;
            }
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanici_kayit dp = new Kullanici_kayit();
            dp.Show();
        }
    }
}

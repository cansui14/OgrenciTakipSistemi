using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ÖgrenciTakipSistemi
{
    public partial class Kullanici_kayit : Form
    {
        public Kullanici_kayit()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Veritabanim.mdb");
        OleDbCommand komut = new OleDbCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Insert Into kullanici_kayit(tc,adsoyad,telefon,sifre) values ('" + maskedTextBox1.Text + "','" + textBox3.Text + "','" + maskedTextBox2.Text + "','" + textBox2.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            if (textBox3.Text == "" || textBox2.Text == "" || maskedTextBox2.Text == "" || maskedTextBox1.Text == "")
            {
                MessageBox.Show("BOŞ ALAN BIRAKMAYINIZ!!!!!");
            }
            else
            {
                MessageBox.Show("kayıt gerçekleşti");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

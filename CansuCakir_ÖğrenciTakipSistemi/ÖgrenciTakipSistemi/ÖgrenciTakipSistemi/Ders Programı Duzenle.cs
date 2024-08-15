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
    public partial class Ders_Programı_Duzenle : Form
    {
        public Ders_Programı_Duzenle()
        {
            InitializeComponent();
        }
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Veritabanim.mdb");
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        private void Ders_Programı_Duzenle_Load(object sender, EventArgs e)
        {
           
            connect.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From DersProgramı", connect);
            DataSet dtst = new DataSet();

            adtr.Fill(dtst, "DersProgramı");

            dataGridView1.DataSource = dtst.Tables["DersProgramı"];

            adtr.Dispose();
            connect.Close();



        }
       
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {






            if (listBox1.Text == "PAZARTESİ")
            {
                comboBox1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                comboBox4.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                comboBox5.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
                comboBox6.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
                comboBox7.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
                comboBox8.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
        

            }

            if (listBox1.Text == "SALI")
            {
                comboBox1.Text = dataGridView1.Rows[2].Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[2].Cells[2].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[2].Cells[3].Value.ToString();
                comboBox4.Text = dataGridView1.Rows[2].Cells[4].Value.ToString();
                comboBox5.Text = dataGridView1.Rows[2].Cells[5].Value.ToString();
                comboBox6.Text = dataGridView1.Rows[2].Cells[6].Value.ToString();
                comboBox7.Text = dataGridView1.Rows[2].Cells[7].Value.ToString();
                comboBox8.Text = dataGridView1.Rows[2].Cells[8].Value.ToString();
               

            }
            if (listBox1.Text == "CARSAMBA")
            {
                comboBox1.Text = dataGridView1.Rows[4].Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[4].Cells[2].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[4].Cells[3].Value.ToString();
                comboBox4.Text = dataGridView1.Rows[4].Cells[4].Value.ToString();
                comboBox5.Text = dataGridView1.Rows[4].Cells[5].Value.ToString();
                comboBox6.Text = dataGridView1.Rows[4].Cells[6].Value.ToString();
                comboBox7.Text = dataGridView1.Rows[4].Cells[7].Value.ToString();
                comboBox8.Text = dataGridView1.Rows[4].Cells[8].Value.ToString();
               
            }
            if (listBox1.Text == "PERSEMBE")
            {
                comboBox1.Text = dataGridView1.Rows[6].Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[6].Cells[2].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[6].Cells[3].Value.ToString();
                comboBox4.Text = dataGridView1.Rows[6].Cells[4].Value.ToString();
                comboBox5.Text = dataGridView1.Rows[6].Cells[5].Value.ToString();
                comboBox6.Text = dataGridView1.Rows[6].Cells[6].Value.ToString();
                comboBox7.Text = dataGridView1.Rows[6].Cells[7].Value.ToString();
                comboBox8.Text = dataGridView1.Rows[6].Cells[8].Value.ToString();
                


            }

            if (listBox1.Text == "CUMA")
            {
                comboBox1.Text = dataGridView1.Rows[8].Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[8].Cells[2].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[8].Cells[3].Value.ToString();
                comboBox4.Text = dataGridView1.Rows[8].Cells[4].Value.ToString();
                comboBox5.Text = dataGridView1.Rows[8].Cells[5].Value.ToString();
                comboBox6.Text = dataGridView1.Rows[8].Cells[6].Value.ToString();
                comboBox7.Text = dataGridView1.Rows[8].Cells[7].Value.ToString();
                comboBox8.Text = dataGridView1.Rows[8].Cells[8].Value.ToString();
               

            }
            if (listBox1.Text == "")
            { 
             comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
                comboBox8.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            if (checkBox1.Checked == true)
            {


                OleDbCommand güncelle = new OleDbCommand("update DersProgramı set Ders1='" + comboBox1.Text + "' where gün ='" + listBox1.Text + "'", connect);

                güncelle.ExecuteNonQuery();
            

            }
            if (checkBox2.Checked == true)
            {


                OleDbCommand güncelle = new OleDbCommand("update DersProgramı set Ders2='" + comboBox2.Text + "' where gün ='" + listBox1.Text + "'", connect);

                güncelle.ExecuteNonQuery();


            }
            if (checkBox3.Checked == true)
            {


                OleDbCommand güncelle = new OleDbCommand("update DersProgramı set Ders3='" + comboBox3.Text + "' where gün ='" + listBox1.Text + "'", connect);

                güncelle.ExecuteNonQuery();


            }

            if (checkBox4.Checked == true)
            {


                OleDbCommand güncelle = new OleDbCommand("update DersProgramı set Ders4='" + comboBox4.Text + "' where gün ='" + listBox1.Text + "'", connect);

                güncelle.ExecuteNonQuery();


            }

            if (checkBox5.Checked == true)
            {


                OleDbCommand güncelle = new OleDbCommand("update DersProgramı set Ders5='" + comboBox5.Text + "' where gün ='" + listBox1.Text + "'", connect);

                güncelle.ExecuteNonQuery();


            }
            if (checkBox6.Checked == true)
            {


                OleDbCommand güncelle = new OleDbCommand("update DersProgramı set Ders6='" + comboBox6.Text + "' where gün ='" + listBox1.Text + "'", connect);

                güncelle.ExecuteNonQuery();


            }
            if (checkBox7.Checked == true)
            {


                OleDbCommand güncelle = new OleDbCommand("update DersProgramı set Ders7='" + comboBox7.Text + "' where gün ='" + listBox1.Text + "'", connect);

                güncelle.ExecuteNonQuery();


            }

            if (checkBox8.Checked == true)
            {


                OleDbCommand güncelle = new OleDbCommand("update DersProgramı set Ders8='" + comboBox8.Text + "' where gün ='" + listBox1.Text + "'", connect);

                güncelle.ExecuteNonQuery();


            }
        
           
            connect.Close();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                checkBox12.Checked = false;
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
            
               
            }

            catch
            {
                MessageBox.Show("Mantıksız Bira Hata Oluştu");
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                checkBox11.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
              
            }
            catch
            {
                MessageBox.Show("Mantıksız Bira Hata Oluştu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Close();
        }
    }
}

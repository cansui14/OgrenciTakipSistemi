using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
namespace ÖgrenciTakipSistemi
{
    public partial class ÖgrenciTakip : Form
    {
        public ÖgrenciTakip()
        {
            InitializeComponent();
        }   
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Veritabanim.mdb");
        OleDbDataAdapter adtr = new OleDbDataAdapter();

        public int c = 0;
        int arama = 0;
    
        public void listeyiyenile()
        {

            yenile();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From Ögrenciler", connect);
            DataSet dtst = new DataSet();

            adtr.Fill(dtst, "Ögrenciler");

            dataGridView1.DataSource = dtst.Tables["Ögrenciler"];

            adtr.Dispose();

            listBox1.Items.Clear();

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                listBox1.Items.Add(dataGridView1.Rows[i].Cells[1].Value.ToString() + " " + dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
        }
        public void yenile()
        {
            OleDbCommand cmd = new OleDbCommand("select * from Ögrenciler", connect);
            OleDbDataReader oku = null;

            oku = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem kayit = new ListViewItem(oku["Numarası"].ToString());
                kayit.SubItems.Add(oku["Adı"].ToString());
                kayit.SubItems.Add(oku["Soyadı"].ToString());
                kayit.SubItems.Add(oku["Sınıfı"].ToString());
                kayit.SubItems.Add(oku["Bölümü"].ToString());
                kayit.SubItems.Add(oku["Ders"].ToString());
                kayit.SubItems.Add(oku["Konu"].ToString());
                kayit.SubItems.Add(oku["VerilişTarihi"].ToString());
                kayit.SubItems.Add(oku["TeslimTarihi"].ToString());
                kayit.SubItems.Add(oku["Sonuc"].ToString());
                kayit.SubItems.Add(oku["Sinav1"].ToString());
                kayit.SubItems.Add(oku["Sinav2"].ToString());
                listView1.Items.Add(kayit);
            }
            oku.Close();

        }

        private void ÖgrenciTakip_Load(object sender, EventArgs e)
        {
        }

        public void Ara(ListBox name, string kelime)
        {

            if (arama >= name.Items.Count)
            {
                arama = 0;
            }
            if (name.Items.Count > 0)
                for (int i = arama; i < name.Items.Count; i++)
                {
                    string item = name.Items[i].ToString();
                    if (item.Length >= kelime.Length)
                        if (item.Substring(0, kelime.Length).ToUpper() == kelime.ToUpper())
                        {
                            name.SelectedIndex = i;
                            arama = i + 1;
                            return;
                        }

                    for (int l = 0; l < item.Length; l++)
                    {
                        if (l <= item.Length - kelime.Length)
                            if (item.Substring(l, kelime.Length).ToUpper() == kelime.ToUpper())
                            {
                                name.SelectedIndex = i;
                                arama = i + 1;
                                return;
                            }
                    }
                }

            for (int i = 0; i < name.Items.Count; i++)
            {
                string item = name.Items[i].ToString();
                if (item.Length >= kelime.Length)
                    if (item.Substring(0, kelime.Length).ToUpper() == kelime.ToUpper())
                    {
                        name.SelectedIndex = i;
                        arama = i + 1;
                        return;
                    }
                for (int l = 0; l < item.Length; l++)
                {
                    if (l <= item.Length - kelime.Length)
                        if (item.Substring(l, kelime.Length).ToUpper() == kelime.ToUpper())
                        {
                            name.SelectedIndex = i;
                            arama = i + 1;
                            return;
                        }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                if (textBox2.Text == "")
                {

                    MessageBox.Show("Adı Kısmı Boş Bırakılamaz"); a++;

                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Soyadı Kısmı Boş Bırakılamaz"); a++;
                }
                else if (textBox4.Text == "")
                {

                    MessageBox.Show("Sınıfı Kısmı Boş Bırakılamaz"); a++;

                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Numarası Kısmı Boş Bırakılamaz"); a++;

                }
                else if (comboBox1.Text == "")
                {

                    MessageBox.Show("Bölümü Kısmı Boş Bırakılamaz"); a++;
                }
                else if (comboBox2.Text == "")
                {
                    MessageBox.Show("Ders Kısmı Boş Bırakılamaz"); a++;
                }
                else if (textBox5.Text == "")
                {

                    MessageBox.Show("Konu Kısmı Boş Bırakılamaz"); a++;
                }

                if (a == 0)
                {
                    int gh = Int32.Parse(textBox6.Text);
                    int sinav1 = Int32.Parse(textBox9.Text);
                    int sinav2 = Int32.Parse(textBox10.Text);
                    if (gh > 100 && sinav1 > 100 && sinav2 > 100)
                    {
                        MessageBox.Show("Not 100'den büyük olamaz");
                    }
                    else if (gh < 0 && sinav2 < 0 && sinav2 < 0)
                    {
                        MessageBox.Show("Not 0'dan küçük olamaz");
                    }
                    else
                    {
                        connect.Open();
                        string ekle = "Insert into Ögrenciler (Numarası,Adı,Soyadı,Sınıfı,Bölümü,Ders,Konu,VerilişTarihi,TeslimTarihi,Sonuc,Sinav1,Sinav2) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox6.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')";
                        OleDbCommand cmd = new OleDbCommand(ekle, connect);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Öğrenci Kaydedilmiştir");
                        connect.Close();
                        if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox9.Text == "" || textBox10.Text == "")
                        {
                            MessageBox.Show("BOŞ ALAN BIRAKMAYINIZ!!!!!");
                        }
                        else
                        {
                            MessageBox.Show("kayıt gerçekleşti");
                        }
                    }
                }
            }
            catch
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            try
            {

                if (textBox13.Text == "")
                {
                    MessageBox.Show("Silinecek Kişinin Numarasını Girmelisiniz");

                }
                else
                {
                    DialogResult secim;
                    secim = MessageBox.Show("Bu Kişiyi Silmek İstediginize Emin Misiniz?", "", MessageBoxButtons.YesNo);

                    if (secim == DialogResult.Yes)
                    {
                        OleDbCommand cmd = new OleDbCommand("DELETE FROM Ögrenciler WHERE Numarası='" + textBox13.Text + "'", connect);

                        cmd.ExecuteNonQuery();

                        yenile();
                        connect.Close();

                    }
                    else
                    {
                        Refresh();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Silenecek Öge Kalmamıştır");

                this.Close();
            }
            connect.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            connect.Open();
            try
            {

                yenile();
                connect.Close();

            }
            catch
            {
                MessageBox.Show("Hata");

            }
            connect.Close();
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            connect.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Ögrenciler", connect);


            try
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (listBox1.Text == dataGridView1.Rows[i].Cells[1].Value.ToString() + " " + dataGridView1.Rows[i].Cells[2].Value.ToString())
                    {

                        Adı.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        Soyadı.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        Sınıfı.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        Numarası.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        Bölümü.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        Ders.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        Konu.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        dateTimePicker1.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        dateTimePicker1.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
                        Sonuc.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
                        textBox12.Text= dataGridView1.Rows[i].Cells[10].Value.ToString();
                        textBox11.Text = dataGridView1.Rows[i].Cells[11].Value.ToString();
                        textBox16.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    }
                }
                OleDbDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {
                }
            }
            catch
            {
                MessageBox.Show("Hata");

            }
            connect.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();

            try
            {
                if (Adı.Text == "")
                {
                    MessageBox.Show("Adı Kısmı Boş Bırakılamaz");

                }
                else if (Soyadı.Text == "")
                {
                    MessageBox.Show("Soyadı Kısmı Boş Bırakılamaz");
                }
                else if (Sınıfı.Text == "")
                {
                    MessageBox.Show("Sınıfı Kısmı Boş Bırakılamaz");
                }
                else if (Numarası.Text == "")
                {
                    MessageBox.Show("Numarası Kısmı Boş Bırakılamaz");
                }
                else if (Bölümü.Text == "")
                {
                    MessageBox.Show("Bölümü Kısmı Boş Bırakılamaz");
                }
                else if (Ders.Text == "")
                {
                    MessageBox.Show("Ders Kısmı Boş Bırakılamaz");
                }
                else if (Konu.Text == "")
                {
                    MessageBox.Show("Konu Kısmı Boş Bırakılamaz");
                }
                else if (Sonuc.Text == "")
                {
                    MessageBox.Show("Not Kısmı Boş Bırakılamaz");
                }
                else
                {
                    int s = 0;

                    if (checkBox.Checked == true)
                    {
                        s++;

                        OleDbCommand güncelle = new OleDbCommand("update Ögrenciler set Adı='" + Adı.Text + "' where Numarası ='" + textBox16.Text + "'", connect);

                        güncelle.ExecuteNonQuery();

                    }

                    if (checkBox2.Checked == true)
                    {
                        s++;
                        OleDbCommand güncelle = new OleDbCommand("update Ögrenciler set Soyadı='" + Soyadı.Text + "' where Numarası ='" + textBox16.Text + "'", connect);

                        güncelle.ExecuteNonQuery();

                    }
                    if (checkBox3.Checked == true)
                    {
                        s++;
                        OleDbCommand güncelle = new OleDbCommand("update Ögrenciler set Sınıfı='" + Sınıfı.Text + "' where Numarası ='" + textBox16.Text + "'", connect);

                        güncelle.ExecuteNonQuery();

                    }
                    if (checkBox4.Checked == true)
                    {
                        s++;
                        OleDbCommand güncelle = new OleDbCommand("update Ögrenciler set Numarası='" + Numarası.Text + "' where Numarası ='" + textBox16.Text + "'", connect);

                        güncelle.ExecuteNonQuery();

                    }
                    if (checkBox5.Checked == true)
                    {
                        s++;
                        OleDbCommand güncelle = new OleDbCommand("update Ögrenciler set Bölümü='" + Bölümü.Text + "' where Numarası ='" + textBox16.Text + "'", connect);

                        güncelle.ExecuteNonQuery();

                    }
                    if (checkBox6.Checked == true)
                    {
                        s++;
                        OleDbCommand güncelle = new OleDbCommand("update Ögrenciler set Ders='" + Ders.Text + "' where Numarası ='" + textBox16.Text + "'", connect);

                        güncelle.ExecuteNonQuery();

                    }
                    if (checkBox7.Checked == true)
                    {
                        s++;
                        OleDbCommand güncelle = new OleDbCommand("update Ögrenciler set Konu='" + Konu.Text + "' where Numarası ='" + textBox16.Text + "'", connect);

                        güncelle.ExecuteNonQuery();

                    }
                    if (checkBox8.Checked == true)
                    {
                        s++;
                        OleDbCommand güncelle = new OleDbCommand("update Ögrenciler set VerilişTarihi='" + VerilişTarihi.Text + "' where Numarası ='" + textBox16.Text + "'", connect);

                        güncelle.ExecuteNonQuery();

                    }
                    if (checkBox9.Checked == true)
                    {
                        s++;
                        OleDbCommand güncelle = new OleDbCommand("update Ögrenciler set TeslimTarihi='" + TeslimTarihi.Text + "' where Numarası ='" + textBox16.Text + "'", connect);

                        güncelle.ExecuteNonQuery();

                    }
                    if (checkBox10.Checked == true)
                    {

                        int aö = Int32.Parse(Sonuc.Text);
                        int Sinav1 = Int32.Parse(textBox12.Text);
                        int Sinav2 = Int32.Parse(textBox11.Text);

                        if (aö > 100 && Sinav1 > 100 && Sinav2 > 100)
                        {
                            s = 60;
                            MessageBox.Show("Not 100'den büyük alamaz");
                        }
                        else
                        {
                            s++;
                            OleDbCommand güncelle = new OleDbCommand("update Ögrenciler set Sonuc='" + Sonuc.Text + "', Sinav1='" + textBox12.Text + "', Sinav2='" + textBox11.Text + "' where Numarası ='" + textBox16.Text + "'", connect);

                            güncelle.ExecuteNonQuery();
                        }

                    }
                    if (s > 0 && s < 50)
                    {
                        MessageBox.Show("Başarılı Bir Şekilde Güncellendi");

                    }
                    else if (s == 0)
                    {
                        MessageBox.Show("Güncellenecek Yerlerin Başına Tik Koymalısınız");
                    }

                    listeyiyenile();
                    yenile();
                }
            }
            catch
            {
               
            }
            connect.Close();
        }
        private void checkBox11_Click(object sender, EventArgs e)
        {
            try
            {

                checkBox12.Checked = false;
                checkBox.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
                checkBox9.Checked = true;
                checkBox10.Checked = true;
            }

            catch
            {
                MessageBox.Show("Hata Oluştu");
            }
        }

        private void checkBox12_Click(object sender, EventArgs e)
        {
            try
            {
                checkBox11.Checked = false;
                checkBox.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
            }
            catch
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }

       
        private void button6_Click(object sender, EventArgs e)
        {
            connect.Open();
            listeyiyenile();
            connect.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {


          
        }

        private void button12_Click(object sender, EventArgs e)

        {
        }

  
        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Adı.Text = "";
            Soyadı.Text = "";
            Sınıfı.Text = "";
            Soyadı.Text = "";
            Numarası.Text = "";
            Sınıfı.Text = "";
            Bölümü.Text = "";
            Ders.Text = "";
            Konu.Text = "";
            VerilişTarihi.Text = "";
            TeslimTarihi.Text = "";
            Sonuc.Text = "";
            connect.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Ögrenciler", connect);

            try
            {


                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (textBox7.Text.ToUpper() == dataGridView1.Rows[i].Cells[1].Value.ToString().ToUpper() || textBox7.Text.ToUpper() == dataGridView1.Rows[i].Cells[1].Value.ToString().ToUpper() + " " + dataGridView1.Rows[i].Cells[2].Value.ToString().ToUpper())
                    {
                        Adı.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        Soyadı.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        Sınıfı.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        Numarası.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        Bölümü.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        Ders.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        Konu.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                        dateTimePicker1.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                        dateTimePicker1.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
                        Sonuc.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
                        textBox16.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    }

                }
                Ara(listBox1, textBox7.Text);
                OleDbDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                if (rdr.HasRows)
                {

                   
                }
            }

            catch
            {
                MessageBox.Show("Hata");

            }
            connect.Close();
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {

            Adı.Text = "";
            Soyadı.Text = "";
            Sınıfı.Text = "";
            Soyadı.Text = "";
            Numarası.Text = "";
            Sınıfı.Text = "";
            Bölümü.Text = "";
            Ders.Text = "";
            Konu.Text = "";
            VerilişTarihi.Text = "";
            TeslimTarihi.Text = "";
            Sonuc.Text = "";
            if (e.KeyData.ToString() == "Return")
            {
                connect.Open();
                OleDbCommand cmd = new OleDbCommand("select * from Ögrenciler", connect);
                try
                {

                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        if (textBox7.Text.ToUpper() == dataGridView1.Rows[i].Cells[1].Value.ToString().ToUpper() || textBox7.Text.ToUpper() == dataGridView1.Rows[i].Cells[1].Value.ToString().ToUpper() + " " + dataGridView1.Rows[i].Cells[2].Value.ToString().ToUpper())
                        {
                            Adı.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            Soyadı.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            Sınıfı.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            Numarası.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            Bölümü.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                            Ders.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
                            Konu.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
                            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
                            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
                            Sonuc.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
                            textBox16.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();

                        }

                    }
                    Ara(listBox1, textBox7.Text);
                    OleDbDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    if (rdr.HasRows)
                    {
                    }
                }

                catch
                {
                    MessageBox.Show("Hata");

                }
                connect.Close();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            if (timer1.Interval < 51)
            {
                label27.Text = "Hoş Geldiniz";
                if (timer1.Interval > 1)
                {
                    timer1.Interval--;
                }
                else if (timer1.Interval > 0)
                {
                    label27.Text = "";
                }
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Ders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            AnaSayfa dp = new AnaSayfa();
            dp.Show();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            AnaSayfa dp = new AnaSayfa();
            dp.Show();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {

            AnaSayfa dp = new AnaSayfa();
            dp.Show();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

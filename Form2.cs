using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kgm1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            listView1.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into kisiselbilgiler (evrak_numarasi,ad,soyad,birimi,aciklama) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox5.Text.ToString() + "' )", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            textBox5.Clear();
            MessageBox.Show("Başarı ile kaydedildi.");
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-VFB28R1;Initial Catalog=kisiselbilgiler;Integrated Security=True");
        private void verilerigörüntüle()
        {

            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From kisiselbilgiler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["evrak_numarasi"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["birimi"].ToString());
                ekle.SubItems.Add(oku["aciklama"].ToString());

                listView1.Items.Add(ekle);


            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            verilerigörüntüle();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

 
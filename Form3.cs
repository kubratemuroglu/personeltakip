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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            listView1.Visible = false;
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

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        int evrak_numarasi = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete From kisiselbilgiler where evrak_numarasi =(" + evrak_numarasi + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
            MessageBox.Show("Silme işlemi başarı ile gerçekleştirildi.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            verilerigörüntüle();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From kisiselbilgiler where evrak_numarasi like '%" + textBox6.Text + "%' or ad like '%" + textBox6.Text + "%' or soyad like '%" + textBox6.Text + "%' or birimi like '%" + textBox6.Text + "%' or aciklama like '%" + textBox6.Text + "%' or evrak_numarasi like '%" + comboBox1.Text + "%' or ad like '%" + comboBox1.Text + "%' or soyad like '%" + comboBox1.Text + "%' or birimi like '%" + comboBox1.Text + "%' or aciklama like '%" + comboBox1.Text + "%'", baglan);
            //SqlCommand komut = new SqlCommand("Select *From kisiselbilgiler where sicilnumarasi like '%" + textBox6.Text + "%' or ad like '%" + textBox6.Text + "%' or soyad like '%" + textBox6.Text +"%' or aciklama like '%" + textBox6.Text + "%' or birimi like '%" + comboBox1.Text + "%' or birimi like '%"+ textBox6.Text +"%'" , baglan);

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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            evrak_numarasi = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

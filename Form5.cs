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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-VFB28R1;Initial Catalog=kisiselbilgiler;Integrated Security=True");
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            
            SqlCommand komut = new SqlCommand("select *from kullanici where kullaniciadi ='" + textBox1.Text + "'and sifre ='" + textBox2.Text + "'", baglantı);
            
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form yeni = new Form1();
                yeni.Show();
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre yanlış");
            }

            baglantı.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

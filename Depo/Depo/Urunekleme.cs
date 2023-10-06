using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Depo
{
    public partial class Urunekleme : Form
    {
        public Urunekleme()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection connection = new SqlConnection("Data Source=NB--EISIK\\MSSQLSERVER01;Initial Catalog=model;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand ekle = new SqlCommand("insert into Urun(barkodno,kategori,marka,urunadi,miktari,alisfiyati,satisfiyati,tarih) values(@barkodno,@kategori,@marka,@urunadi,@miktari,@alisfiyati,@satisfiyati,@tarih)", connection);
            ekle.Parameters.AddWithValue("@barkodno", textBox1.Text);
            ekle.Parameters.AddWithValue("@kategori", comboBox1.Text);
            ekle.Parameters.AddWithValue("@marka", comboBox2.Text);
            ekle.Parameters.AddWithValue("@urunadi", textBox2.Text);
            ekle.Parameters.AddWithValue("@miktari", int.Parse(textBox3.Text));
            ekle.Parameters.AddWithValue("alisfiyati",double.Parse(textBox4.Text));
            ekle.Parameters.AddWithValue("satisfiyati", double.Parse(textBox5.Text));
            ekle.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            ekle.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ürün Eklendi");
            comboBox2.Items.Clear();
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                    
                }
            }
        }
        private void getir()
        {
            connection.Open();
            SqlCommand kmt = new SqlCommand("select * from kategori", connection);
            SqlDataReader read = kmt.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["kategori"].ToString());
            }
            connection.Close();
        }
        private void Urunekleme_Load(object sender, EventArgs e)
        {
            getir();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            connection.Open();
            SqlCommand kmt = new SqlCommand("select * from marka where kategori='"+comboBox1.SelectedItem+"'", connection);
            SqlDataReader read = kmt.ExecuteReader();
            while (read.Read())
            {
                comboBox2.Items.Add(read["marka"].ToString());
            }
            connection.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

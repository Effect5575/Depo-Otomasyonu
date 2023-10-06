using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Security.Policy;

namespace Depo
{
    public partial class UrunListeleme : Form
    {
        public UrunListeleme()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=NB--EISIK\\MSSQLSERVER01;Initial Catalog=model;Integrated Security=True");
        DataSet dt = new DataSet();
        
        private void UrunListeleme_Load(object sender, EventArgs e)
        {
            göster();
            getir();
        }

        private void göster()
        {
            connection.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Urun", connection);
            adtr.Fill(dt, "Urun");
            dataGridView1.DataSource = dt.Tables["Urun"];
            connection.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            //comboBox1.Text = "";
            
        }
        private void getir()
        {
  
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox8.Text = "";
                foreach (Control item in groupBox1.Controls)
                {
                   
                }
            }
            connection.Open();
            SqlCommand ekle = new SqlCommand("select * from Urun where barkodno like'" + textBox1.Text + "'", connection);
            SqlDataReader read = ekle.ExecuteReader();
            while (read.Read())
            {
               textBox1.Text = read["kategori"].ToString();
               textBox2.Text = read["marka"].ToString();
                textBox9.Text = read["urunadi"].ToString();
                textBox8.Text = read["miktari"].ToString();
                textBox7.Text = read["alisfiyati"].ToString();
                textBox6.Text = read["satisfiyati"].ToString();
            }
            connection.Close();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            string barkodno = textBox1.Text;

            connection.Open();
            SqlCommand güncel = new SqlCommand("update Urun set urunadi=@urunadi,miktari=@miktari,alisfiyati=@alisfiyati,satisfiyati=@satisfiyati where barkodno=@barkodno", connection);
            güncel.Parameters.AddWithValue("@barkodno",int.Parse(textBox1.Text));
            güncel.Parameters.AddWithValue("@urunadi", textBox9.Text);
            güncel.Parameters.AddWithValue("@miktari", int.Parse(textBox8.Text));
            güncel.Parameters.AddWithValue("@alisfiyati",double.Parse(textBox7.Text));
            güncel.Parameters.AddWithValue("@satisfiyati", double.Parse(textBox6.Text));
            güncel.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            güncel.ExecuteNonQuery();
            connection.Close();
            dt.Tables["Urun"].Clear();
            göster();
            MessageBox.Show("Güncelleme Yapılmıştır !");
            foreach (Control item in this.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    item.Text = "";
                }
            }

            textBox1.Text = barkodno;
            göster();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["kategori"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["marka"].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells["urunadi"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["miktari"].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells["alisfiyati"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["satisfiyati"].Value.ToString();

        }

        private void barkodno_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Urun where barkodno like '%" + textBox1.Text + "%'", connection);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                connection.Open();
                SqlCommand güncel = new SqlCommand("update Urun set kategori=@kategori,marka=@marka where barkodno=@barkodno", connection);
                güncel.Parameters.AddWithValue("@barkodno", int.Parse(textBox1.Text));
                güncel.Parameters.AddWithValue("@kategori", textBox9.Text);
                güncel.Parameters.AddWithValue("@marka", int.Parse(textBox8.Text));

                güncel.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Güncelleme Yapılmıştır !");
            }
            else
            {
                MessageBox.Show("Barkod girili değildir");
            }
            foreach (Control item in this.Controls)
            {
                if (item is System.Windows.Forms.ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            //comboBox1.Text = "";
         

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sil = new SqlCommand("delete from Urun where barkodno='" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString()+"'",connection);
            sil.ExecuteNonQuery();
            connection.Close();
            dt.Tables["Urun"].Clear();
            göster();
            MessageBox.Show("Kayıt silindi !");
        }
    }
}

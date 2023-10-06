using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Depo
{
    public partial class Depo : Form
    {
        public Depo()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=NB--EISIK\\MSSQLSERVER01;Initial Catalog=model;Integrated Security=True");
        DataSet dt = new DataSet();
        private void listele()
        {
            connection.Open();
            SqlDataAdapter göster = new SqlDataAdapter("select * from gelengiden", connection);
            göster.Fill(dt, "gelengiden");
            dataGridView1.DataSource = dt.Tables["gelengiden"];
            connection.Close();

        }
        private void Depo_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tıklama");
        }

        private void müsteriekleme_Click(object sender, EventArgs e)
        {
            FirmaEkleme müsteri = new FirmaEkleme();
            müsteri.ShowDialog();
            
        }

        private void müsterilisteleme_Click(object sender, EventArgs e)
        {
            FirmaListe liste = new FirmaListe();
            liste.ShowDialog();
        }

        private void urunekleme_Click(object sender, EventArgs e)
        {
            Urunekleme urunekleme = new Urunekleme();
            urunekleme.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kategori kategori = new Kategori();
            kategori.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Marka marka = new Marka();
            marka.ShowDialog();
        }

        private void ürünlisteleme_Click(object sender, EventArgs e)
        {
            UrunListeleme urunListeleme = new UrunListeleme();
            urunListeleme.ShowDialog();
        }
        bool durum;
       private void barkodkontrol()
        {
            durum = true;
            connection.Open();
            SqlCommand kmt = new SqlCommand("select * from gelengiden", connection);
            SqlDataReader reader = kmt.ExecuteReader();
            while (reader.Read())
            {
                if (textBox4.Text == reader["barkodno"].ToString())
                {
                    durum = false;
                }
            }
            connection.Close();
        }

        private void ekle_Click(object sender, EventArgs e)
        {
                connection.Open();
                SqlCommand ekle = new SqlCommand("insert into gelengiden(barkodno,urunadi,miktari,alisfiyati,satisfiyati,firmakodu,firmaadi) values(@barkodno,@urunadi,@miktari,@alisfiyati,@satisfiyati,@firmakodu,@firmaadi)", connection);
                ekle.Parameters.AddWithValue("@barkodno", int.Parse(textBox4.Text));
                ekle.Parameters.AddWithValue("@urunadi", textBox5.Text);
                ekle.Parameters.AddWithValue("@miktari", int.Parse(textBox6.Text));
                ekle.Parameters.AddWithValue("@alisfiyati", double.Parse(textBox7.Text));
                ekle.Parameters.AddWithValue("@satisfiyati", double.Parse(textBox8.Text));
                ekle.Parameters.AddWithValue("@firmakodu", int.Parse(textBox1.Text));
                ekle.Parameters.AddWithValue("@firmaadi", textBox2.Text);
                ekle.Parameters.AddWithValue("toplamfiyat",int.Parse(textBox8.Text));
                ekle.ExecuteNonQuery();
                connection.Close();
                dt.Tables["gelengiden"].Clear();
                MessageBox.Show("Ürün Eklendi");
            listele();
                yenile();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                textBox2.Text = "";
                

            }
            connection.Open();
            SqlCommand kmt = new SqlCommand("select * from firma where FirmaKodu like '" + textBox1.Text + "'", connection);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr["firmaadi"].ToString();
               

            }
            connection.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
                yenile();
                connection.Open();
                SqlCommand kmt = new SqlCommand("select * from Urun where barkodno like '" + textBox4.Text + "'", connection);
                SqlDataReader dr = kmt.ExecuteReader();
                while (dr.Read())
                {
                    textBox5.Text = dr["urunadi"].ToString();
                    textBox6.Text = dr["miktari"].ToString();
                    textBox7.Text = dr["satisfiyati"].ToString();
                    textBox1.Text = dr["firmakodu"].ToString();
                    textBox2.Text = dr["firmaadi"].ToString();
                }
                connection.Close();
            
          
         
        }

        private void yenile()
        {
            if (textBox4.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != textBox6)
                        {
                            item.Text = "";
                        }
                    }
                }

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox8.Text = (double.Parse(textBox6.Text) * double.Parse(textBox7.Text)).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void sil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sil = new SqlCommand("delete from gelengiden where barkodno = '" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "'", connection);
            sil.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ürün Silindi");
            dt.Tables["gelengiden"].Clear();
            listele();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sil = new SqlCommand("delete from gelengiden",connection);
            sil.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ürün gönderildi");
            dt.Tables["gelengiden"].Clear();
            listele();

        }

        private void satisiptal_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sil = new SqlCommand("delete from gelengiden where barkodno = '" + dataGridView1.CurrentRow.Cells["barkodno"].ToString()+"'", connection);
            sil.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ürün İptal Edildi");
            dt.Tables["gelengiden"].Clear();
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

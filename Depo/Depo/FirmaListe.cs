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
using System.Data.Sql;

namespace Depo
{
    public partial class FirmaListe : Form
    {
        public FirmaListe()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        SqlConnection connection = new SqlConnection("Data Source=NB--EISIK\\MSSQLSERVER01;Initial Catalog=model;Integrated Security=True");
        private void mstrlisteleme_Load(object sender, EventArgs e)
        {
            KayitGöster();

        }

        private void KayitGöster()
        {
            connection.Open();
            SqlDataAdapter göster = new SqlDataAdapter("select * from firma", connection);
            göster.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }


        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["FirmaKodu"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["firmaadi"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["yer"].Value.ToString();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand gücel = new SqlCommand("update firma set firmaadi=@firmaadi,email=@email,yer=@yer where FirmaKodu=@firmakodu", connection);
            gücel.Parameters.AddWithValue("@firmakodu", int.Parse(textBox1.Text));
            gücel.Parameters.AddWithValue("@firmaadi", textBox2.Text);
            gücel.Parameters.AddWithValue("@email", textBox3.Text);
            gücel.Parameters.AddWithValue("@yer", textBox4.Text); 
            gücel.ExecuteNonQuery();
            connection.Close();
            ds.Tables[0].Clear();
            KayitGöster();
            MessageBox.Show("Firma Kaydı Başarıyla Güncellenmiştir");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void sil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sil = new SqlCommand("delete from firma where FirmaKodu='"+dataGridView1.CurrentRow.Cells["FirmaKodu"].Value.ToString()+"'", connection);
            sil.ExecuteNonQuery();
            connection.Close();
            ds.Tables[0].Clear();
            KayitGöster();
            MessageBox.Show("Kayıt Başarı ile Silinmiştir");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            connection.Open();
            SqlDataAdapter kmt = new SqlDataAdapter("select * from firma where FirmaKodu like '%" + textBox6.Text + "%'", connection);
            kmt.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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

namespace Depo
{
    public partial class Marka : Form
    {
        public Marka()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=NB--EISIK\\MSSQLSERVER01;Initial Catalog=model;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand kmt = new SqlCommand("insert into marka(kategori,marka) values('"+comboBox1.Text+"','"+textBox1.Text +"')", connection);
            kmt.ExecuteNonQuery();     
            connection.Close();
            comboBox1.Text = "";
            textBox1.Text = "";
            MessageBox.Show("Marka Eklenmiştir");
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
        private void Marka_Load(object sender, EventArgs e)
        {
            getir();
        }
    }
}

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
using System.Data.Sql;
namespace Depo
{
    public partial class Kategori : Form
    {
        public Kategori()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=NB--EISIK\\MSSQLSERVER01;Initial Catalog=model;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand kmt = new SqlCommand("insert into kategori(kategori) values('"+textBox1.Text+"')", connection);
            kmt.ExecuteNonQuery();
            connection.Close();
            textBox1.Text = "";
            MessageBox.Show("Kategori Eklenmiştir");
        }

        private void Kategori_Load(object sender, EventArgs e)
        {

        }
    }
}

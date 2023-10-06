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
using Depo;

namespace Depo
{
    public partial class FirmaEkleme : Form
    {
        public FirmaEkleme()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=NB--EISIK\\MSSQLSERVER01;Initial Catalog=model;Integrated Security=True");
        Depo dp = new Depo();
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand ele = new SqlCommand("insert into firma(FirmaKodu,firmaadi,email,yer) values(@FirmaKodu,@firmaadi,@email,@yer)",connection);
            ele.Parameters.AddWithValue("@FirmaKodu", int.Parse(textBox1.Text));
            ele.Parameters.AddWithValue("@firmaadi",textBox2.Text);
            ele.Parameters.AddWithValue("@email", textBox3.Text);
            ele.Parameters.AddWithValue("@yer", textBox4.Text);
            ele.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Firma Eklenmiştir!");
            foreach (Control item in this.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    item.Text = "";
                }
            }

        }

        private void MüsteriEkleme_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Seçtğiniz Firma , gün sonu yapılan veya gönderilen ürünleri götürcektir bilginize");
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Depo depo = new Depo();
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

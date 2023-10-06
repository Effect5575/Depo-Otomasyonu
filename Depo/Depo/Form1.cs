using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace Depo
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
       
        SqlConnection connection = new SqlConnection("Data Source=NB--EISIK;Initial Catalog=model;Integrated Security=True");
      

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == "admin" && textBox4.Text == "admin123")
            {
                Depo dp = new Depo();
                this.Hide();
                dp.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Tespit edilmiştir");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Depo dp = new Depo();
            this.Hide();
            dp.Show();
        }
    }
}

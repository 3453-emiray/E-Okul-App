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

namespace E_Okul_App
{

    public partial class FormOgretmenler : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-U7T53TEL\SQLEXPRESS01;Initial Catalog=Okul;Integrated Security=True;TrustServerCertificate=True");
        public FormOgretmenler()
        {
            InitializeComponent();
        }

        private void FormOgretmenler_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLOGRETMENLER", baglanti);            
            //komut.Parameters.AddWithValue("@P1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form_Ogretmen fr = new Form_Ogretmen();
            fr.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

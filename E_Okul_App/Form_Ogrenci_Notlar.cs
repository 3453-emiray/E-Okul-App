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

namespace E_Okul_App
{
    public partial class Form_Ogrenci_Notlar : Form
    {
        public Form_Ogrenci_Notlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-U7T53TEL\SQLEXPRESS01;Initial Catalog=Okul;Integrated Security=True;TrustServerCertificate=True");
        public string numara;
        private void Form_Ogrenci_Notlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3, PROJENOT,ORTALAMA,DURUM FROM TBLNOTLAR INNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID WHERE OGRID = @P1", baglanti);
            komut.Parameters.AddWithValue("@P1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

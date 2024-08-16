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
    public partial class FormKulup : Form
    {
        public FormKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-U7T53TEL\SQLEXPRESS01;Initial Catalog=Okul;Integrated Security=True;TrustServerCertificate=True");
        void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLKULUP", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FormKulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLKULUP (KULUPAD) VALUES (@P1)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtkulupad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.White;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulupad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete FROM TBLKULUP WHERE KULUPID = @P1", baglanti);
            komut.Parameters.AddWithValue("@P1", txtkulupID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Silme İşelmi Gerçekleşti");
            liste();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update TBLKULUP SET KULUPAD = @P1 WHERE KULUPID =@P2", baglanti);
            komut.Parameters.AddWithValue("@P1", txtkulupad.Text);
            komut.Parameters.AddWithValue("@P2", txtkulupID.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp Güncelleme İşlemi Gerçekleşti");
            liste();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form_Ogretmen fr = new Form_Ogretmen();
            fr.Show();
            this.Hide();
        }
    }
}

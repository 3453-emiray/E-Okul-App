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
    public partial class FormOgrenci : Form
    {
        public FormOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-U7T53TEL\SQLEXPRESS01;Initial Catalog=Okul;Integrated Security=True;TrustServerCertificate=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        public void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormOgrenci_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLKULUP", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KULUPAD";  //DisplayMember = kulupad bana görünsün
            comboBox1.ValueMember = "KULUPID";    //ValueMember = kulupadın arkaplandaki değeri kulupıd 
            comboBox1.DataSource = dt;            //combobox1'in değeri dt den gelen değer olucak
            baglanti.Close();                     //Dataadapter kullanılınca bağlantıyı açıp kapamasakda oluyor
        }

        string c = " ";  //cinsiyet = c

        private void btnEkle_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                c = "ERKEK";
            }
            if (radioButton2.Checked == true)
            {
                c = "KIZ";
            }
            ds.OgrenciEkle(txtAd.Text, txtSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Ekleme Yapıldı");

        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtID.Text = comboBox1_SelectedIndex.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtID.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Ee")
            {
                radioButton2.Checked = true;
            }
            if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "KADIN")
            {
                radioButton1.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(txtAra.Text);
        }
    }
}
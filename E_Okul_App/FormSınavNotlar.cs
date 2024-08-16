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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace E_Okul_App
{
    public partial class FormSınavNotlar : Form
    {
        public FormSınavNotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtID.Text));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-U7T53TEL\SQLEXPRESS01;Initial Catalog=Okul;Integrated Security=True;TrustServerCertificate=True");
        private void FormSınavNotlar_Load(object sender, EventArgs e)
        {            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLDERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "DERSAD";  //DisplayMember = kulupad bana görünsün
            comboBox1.ValueMember = "DERSID";    //ValueMember = kulupadın arkaplandaki değeri kulupıd 
            comboBox1.DataSource = dt;            //combobox1'in değeri dt den gelen değer olucak
            baglanti.Close();                     //Dataadapter kullanılınca bağlantıyı açıp kapamasakda oluyor
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            

            sinav1 = Convert.ToInt16(txtSınav1.Text);
            sinav2 = Convert.ToInt16(txtSınav2.Text);
            sinav3 = Convert.ToInt16(txtSınav3.Text);
            proje = Convert.ToInt16(txtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4.00;
            txtOrtalama.Text = ortalama.ToString();

            if (ortalama > 50)
            {
                txtDurum.Text = "True";
            }
            else 
            {
                txtDurum.Text = "False";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {            
            ds.NotGuncelle(byte.Parse(comboBox1.SelectedValue.ToString()), int.Parse(txtID.Text), byte.Parse(txtSınav1.Text), byte.Parse(txtSınav2.Text), byte.Parse(txtSınav3.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrtalama.Text), bool.Parse(txtDurum.Text),notid);
        }
    }
    }


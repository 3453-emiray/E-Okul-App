using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Okul_App
{
    public partial class FormDersler : Form
    {
        public FormDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();
        private void FormDersler_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ds.DersListesi();
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

        private void button2_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtDersAd.Text);
            MessageBox.Show("Ders Ekleme İşlemi Yapılmıştır");
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtDersID.Text));
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //ds.DersGüncelle(txtDersAd.Text,byte.Parse(txtDersID.Text));

            if (byte.TryParse(txtDersID.Text, out byte dersID))
            {
                ds.DersGüncelle(txtDersAd.Text, dersID);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Ders ID girin (0-255 arası bir sayı).");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDersID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}

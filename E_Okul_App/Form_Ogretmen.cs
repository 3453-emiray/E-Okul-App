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
    public partial class Form_Ogretmen : Form
    {
        public Form_Ogretmen()
        {
            InitializeComponent();
        }

        private void Form_Ogretmen_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormKulup fr =new FormKulup();
            fr.Show();
            this.Hide();
        }

        private void btnDers_Click(object sender, EventArgs e)
        {
            FormDersler fr = new FormDersler();
            fr.Show();
            this.Hide();
        }

        private void btnOgrenciİslemleri_Click(object sender, EventArgs e)
        {
            FormOgrenci fr = new FormOgrenci();
            fr.Show();
        }

        private void BtnSınavNotlar_Click(object sender, EventArgs e)
        {
            FormSınavNotlar fr = new FormSınavNotlar();
            fr.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           FormOgretmenler fr = new FormOgretmenler();
           fr.Show();
           this.Hide();
        }
    }
}

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Öğrenci ID Giriniz");
            }
            else
            {
                Form_Ogrenci_Notlar fr = new Form_Ogrenci_Notlar();
                fr.numara = textBox1.Text;
                fr.Show();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form_Ogretmen fr = new Form_Ogretmen();
            fr.Show();
            this.Hide();
        }
    }
}

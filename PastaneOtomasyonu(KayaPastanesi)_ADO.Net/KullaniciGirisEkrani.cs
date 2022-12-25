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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PastaneOtomasyonu_KayaPastanesi__ADO.Net
{
    public partial class KullaniciGirisEkrani : Form
    {
        public KullaniciGirisEkrani()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Server=MSI;Database=KayaPastanesi;Integrated Security=true");

        private void KullaniciGirisEkrani_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
       

            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from KullaniciBilgilleri where KullaniciAdi= '" + textBox1.Text + "'and Sifre='" + textBox2.Text + "'", baglan);

            SqlDataReader oku;
            oku = komut.ExecuteReader();

            if (oku.Read())
            {
                MessageBox.Show("Tebrikler! başarılı bir şekilde giriş yaptınız");
                MusterilerEkrani git = new MusterilerEkrani();
                git.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ve şifre hatalı tekrar deneyiniz");
                textBox1.Clear();
                textBox2.Clear();
            }
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into KullaniciBilgilleri (KullaniciAdi,Sifre,Email,Telefon) values (@KullaniciAdi,@Sifre,@Email,@Telefon) ", baglan);

            komut.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
            komut.Parameters.AddWithValue("@Sifre", textBox2.Text);
            komut.Parameters.AddWithValue("@Email", textBox3.Text);
            komut.Parameters.AddWithValue("@Telefon", textBox4.Text);
            komut.ExecuteNonQuery();
       
            baglan.Close();
        }
    }
}

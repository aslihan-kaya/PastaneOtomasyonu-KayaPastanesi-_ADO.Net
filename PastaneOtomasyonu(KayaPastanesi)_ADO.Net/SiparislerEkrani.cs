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
    public partial class SiparislerEkrani : Form
    {
        public SiparislerEkrani()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Server=MSI;Database=KayaPastanesi;Integrated Security=true");

        public void method(string scode)
        {
            SqlDataAdapter dp = new SqlDataAdapter(scode, baglan);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void polikliniklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusterilerEkrani git = new MusterilerEkrani();
            git.Show();
            this.Hide();
        }

        private void doktorlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunlerEkrani git = new UrunlerEkrani();
            git.Show();
            this.Hide();
        }

        private void hastalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiparislerEkrani git = new SiparislerEkrani();
            git.Show();
            this.Hide();
        }

        private void SiparislerEkrani_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            method("select*from SiparisBilgileri");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into SiparisBilgileri (SiparisAdi,SiparisAdres,SiparisAdet,SiparisFiyat) values (@SiparisAdi,@SiparisAdres,@SiparisAdet,@SiparisFiyat) ", baglan);


            komut.Parameters.AddWithValue("@SiparisAdi", textBox2.Text);
            komut.Parameters.AddWithValue("@SiparisAdres", textBox3.Text);
            komut.Parameters.AddWithValue("@SiparisAdet", textBox4.Text);
            komut.Parameters.AddWithValue("@SiparisFiyat", textBox5.Text);
            komut.ExecuteNonQuery();
            method("select * from SiparisBilgileri");
            baglan.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir =
              dataGridView1.CurrentRow;
            textBox2.Text = satir.Cells["SiparisAdi"].Value.ToString();
            textBox3.Text = satir.Cells["SiparisAdres"].Value.ToString();
            textBox4.Text = satir.Cells["SiparisAdet"].Value.ToString();
            textBox5.Text = satir.Cells["SiparisFiyat"].Value.ToString();
            
        }
    }
}

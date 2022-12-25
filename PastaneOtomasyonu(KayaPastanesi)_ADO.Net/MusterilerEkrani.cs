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

namespace PastaneOtomasyonu_KayaPastanesi__ADO.Net
{
    public partial class MusterilerEkrani : Form
    {
        public MusterilerEkrani()
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

        private void MusterilerEkrani_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            method("select*from SaticiBilgileri");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into SaticiBilgileri (SaticiAdiSoyadi,SaticiAdres,Saticiil,Saticiilce) values (@SaticiAdiSoyadi,@SaticiAdres,@Saticiil,@Saticiilce) ", baglan);


           
            komut.Parameters.AddWithValue("@SaticiAdiSoyadi", textBox2.Text);
            komut.Parameters.AddWithValue("@SaticiAdres", textBox3.Text);
            komut.Parameters.AddWithValue("@Saticiil", textBox4.Text);
            komut.Parameters.AddWithValue("@Saticiilce", textBox5.Text);
            komut.ExecuteNonQuery();
            method("select * from SaticiBilgileri");
            baglan.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir =
               dataGridView1.CurrentRow;
          
            textBox2.Text = satir.Cells["SaticiAdiSoyadi"].Value.ToString();
            textBox3.Text = satir.Cells["SaticiAdres"].Value.ToString();
            textBox4.Text = satir.Cells["Saticiil"].Value.ToString();
            textBox5.Text = satir.Cells["Saticiilce"].Value.ToString(); 
        }

        private void doktorlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunlerEkrani git = new UrunlerEkrani();
            git.Show();
            this.Hide();
        }

        private void polikliniklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusterilerEkrani git = new MusterilerEkrani();
            git.Show();
            this.Hide();
        }

        private void hastalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiparislerEkrani git = new SiparislerEkrani();
            git.Show();
            this.Hide();
        }
    }
}

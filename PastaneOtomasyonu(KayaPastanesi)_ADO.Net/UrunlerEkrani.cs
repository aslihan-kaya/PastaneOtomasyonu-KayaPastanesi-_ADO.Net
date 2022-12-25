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
    public partial class UrunlerEkrani : Form
    {
        public UrunlerEkrani()
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

        private void UrunlerEkrani_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            method("select*from UrunBilgilerii");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into UrunBilgilerii(UrunAdi,UrunFiyati,KullanimTarihi,UrunTarihi,SaticiNo) values (@UrunAdi,@UrunFiyati,@KullanimTarihi,@UrunTarihi,@SaticiNo) ", baglan);

            komut.Parameters.AddWithValue("@UrunAdi", textBox2.Text);
            komut.Parameters.AddWithValue("@UrunFiyati", textBox3.Text);
            komut.Parameters.AddWithValue("@KullanimTarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@UrunTarihi", dateTimePicker2.Text);
            komut.Parameters.AddWithValue("@SaticiNo", comboBox1.Text);
            komut.ExecuteNonQuery();
            method("select * from UrunBilgilerii");
            baglan.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir =
               dataGridView1.CurrentRow;

            textBox2.Text = satir.Cells["UrunAdi"].Value.ToString();
            textBox3.Text = satir.Cells["UrunFiyati"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["KullanimTarihi"].Value.ToString();
            dateTimePicker2.Text = satir.Cells["UrunTarihi"].Value.ToString();
            comboBox1.Text = satir.Cells["SaticiNo"].Value.ToString();
        }

    }
    }


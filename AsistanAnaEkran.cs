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

namespace VeriTabaniProje
{
    public partial class AsistanAnaEkran : Form
    {
        public AsistanAnaEkran()
        {
            InitializeComponent();
        }

        private void GeriDonButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cagrilar cagrilar = new Cagrilar();
            cagrilar.Show();
            Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            İtirazListesi itirazListesi = new İtirazListesi();
            itirazListesi.Show();
            Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AsistanPrimListesiniGoster();
            PrimListesi primListesi = new PrimListesi();
            primListesi.Show();
            Hide();
        }
        private void AsistanPrimListesiniGoster()
        {
            int ay = DateTime.Now.Month;
            PrimHesapla primHesapla = new PrimHesapla();
            primHesapla.Hesapla(ay);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.LightSeaGreen;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.MediumTurquoise;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.LightSeaGreen;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.MediumTurquoise;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightSeaGreen;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.MediumTurquoise;
        }

        private void AsistanAnaEkran_Load(object sender, EventArgs e)
        {
            HosgeldinizMesaji();
            Label lbl = label1;
            Panel pnl = panel1;
            lbl.Location = new Point((pnl.Width - lbl.Width) / 2, lbl.Location.Y);
        }
        private void HosgeldinizMesaji()
        {
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = "SELECT AsistanAd, AsistanSoyad FROM Asistanlar WHERE AsistanID=@ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", LoginForm.ID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string Adi = reader["AsistanAd"].ToString();
                        string Soyadi = reader["AsistanSoyad"].ToString();
                        label1.Text = "Hoş geldiniz, " + Adi + " " + Soyadi;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                connection.Close();
            }
        }
    }
}
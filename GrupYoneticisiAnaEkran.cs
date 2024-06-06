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
    public partial class GrupYoneticisiAnaEkran : Form
    {
        public GrupYoneticisiAnaEkran()
        {
            InitializeComponent();
        }

        private void GrupYoneticisiAnaEkran_Load(object sender, EventArgs e)
        {
            HosgeldinizMesaji();
            Label lbl = label1;
            Panel pnl = panel1;
            lbl.Location = new Point((pnl.Width - lbl.Width) / 2, lbl.Location.Y);
        }
        private void HosgeldinizMesaji()
        {
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = "SELECT GrupYoneticiAd, GrupYoneticiSoyad FROM GrupYoneticileri WHERE GrupYoneticisiID=@ID";

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
                        string Adi = reader["GrupYoneticiAd"].ToString();
                        string Soyadi = reader["GrupYoneticiSoyad"].ToString();
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

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightSeaGreen;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.MediumTurquoise;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ItirazListesiYonetici itirazListesiYonetici = new ItirazListesiYonetici();
            itirazListesiYonetici.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Hide();
        }
    }
}

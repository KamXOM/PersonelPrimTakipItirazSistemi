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
    public partial class YeniCagri : Form
    {
        public YeniCagri()
        {
            InitializeComponent();
        }

        private void YeniCagri_Load(object sender, EventArgs e)
        {

        }
        private void KaydetButton_Click(object sender, EventArgs e)
        {
            
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string storedProcedure = "yeniCagriEkle";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@asistanID", LoginForm.ID);
                TimeSpan sure = (dateTimePicker2.Value.TimeOfDay) - (dateTimePicker1.Value.TimeOfDay);
                command.Parameters.AddWithValue("@konuID", comboBox1.SelectedIndex + 1);
                command.Parameters.AddWithValue("@tarih", dateTimePicker.Value);
                command.Parameters.AddWithValue("@durumID", comboBox1.SelectedIndex + 1);
                command.Parameters.AddWithValue("@gorusmeSuresi", sure);
                command.Parameters.AddWithValue("@musteriAd", MusteriAdTextBox.Text);
                command.Parameters.AddWithValue("@musteriSoyad", MusteriSoyadTextBox.Text);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Yeni çağrı başarıyla eklendi.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                connection.Close();
            }
            GorusmeSayisiGuncelleme();
        }
        private void GorusmeSayisiGuncelleme()
        {
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string updateQuery = @"
                UPDATE Primler
                SET ToplamGorusmeSayisi = (SELECT COUNT(*) FROM Gorusmeler WHERE AsistanID = @asistanID)
                WHERE AsistanID = @asistanID AND Ay = @ay";
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(updateQuery, connection2))
            {
                command.Parameters.AddWithValue("@asistanID", LoginForm.ID);
                command.Parameters.AddWithValue("@ay", 5);
                try
                {
                    connection2.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                connection2.Close();
            }
        }
    }
}

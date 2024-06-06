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
    public partial class ItirazFormu : Form
    {
        public ItirazFormu()
        {
            InitializeComponent();
        }
        private int primID;
        public ItirazFormu(int primID)
        {
            InitializeComponent();
            this.primID = primID;
        }
        private void ItirazFormu_Load(object sender, EventArgs e)
        {

        }
        private void Gonder()
        {
            string itirazAciklama = richTextBox1.Text;
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = "INSERT INTO İtirazlar (AsistanID, Ay, Aciklama, İtirazDurumID, PrimID) VALUES (@asistanID, @ay, @aciklama, @itirazDurumID, @primID)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@asistanID", LoginForm.ID);
                command.Parameters.AddWithValue("@ay", DateTime.Now.Month);
                command.Parameters.AddWithValue("@aciklama", itirazAciklama);
                command.Parameters.AddWithValue("@itirazDurumID", 1);
                command.Parameters.AddWithValue("@primID", this.primID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            MessageBox.Show("İtirazınız başarıyla kaydedildi.");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gonder();
        }
    }
}

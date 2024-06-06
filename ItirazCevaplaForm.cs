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
    public partial class ItirazCevaplaForm : Form
    {
        public ItirazCevaplaForm()
        {
            InitializeComponent();
        }
        public ItirazCevaplaForm(int itirazID)
        {
            InitializeComponent();
            ItirazID = itirazID;
        }
        private int ItirazID;
        private void ItirazCevaplaForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ItirazDurumunuGuncelle("Onaylandı");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ItirazDurumunuGuncelle("Reddedildi");
        }
        private void ItirazDurumunuGuncelle(string cevap)
        {
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = "UPDATE İtirazlar SET Cevap = @cevap WHERE İtirazID = @itirazID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@cevap", cevap);
                command.Parameters.AddWithValue("@itirazID", ItirazID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            MessageBox.Show($"Grup yöneticisine e-posta gönderildi: İtiraz {cevap}");
            this.Close();
        }
    }
}

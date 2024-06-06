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
    public partial class Cagrilar : Form
    {
        public Cagrilar()
        {
            InitializeComponent();
        }

        private void YeniCagri_Load(object sender, EventArgs e)
        {
            LoadCallList();
        }
        private void LoadCallList()
        {
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = "SELECT AsistanID, Tarih, GorusmeSuresi, MusteriAd, MusteriSoyad FROM dbo.Gorusmeler WHERE AsistanID=@p1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@p1", LoginForm.ID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }

        private void yeniCagriButton_Click(object sender, EventArgs e)
        {
            YeniCagri yeniCagriForm = new YeniCagri();
            if (yeniCagriForm.ShowDialog() == DialogResult.OK)
            {
                LoadCallList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsistanAnaEkran asistanAnaEkran = new AsistanAnaEkran();
            asistanAnaEkran.Show();
            Hide();
        }
    }
}

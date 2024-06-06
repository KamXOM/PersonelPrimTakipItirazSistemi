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
    public partial class PrimListesi : Form
    {
        public PrimListesi()
        {
            InitializeComponent();
        }

        private void PrimListesi_Load(object sender, EventArgs e)
        {
            LoadPrimList();
        }
        private void LoadPrimList()
        {
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = "SELECT * FROM dbo.Primler WHERE AsistanId = @AsistanId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@AsistanId", LoginForm.ID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }
        private void itirazEtButton_Click(object sender, EventArgs e)
        {
            int sonAy = DateTime.Now.Month;
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = "SELECT PrimID FROM Primler WHERE AsistanID = @asistanID AND Ay = @sonAy";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@asistanID", LoginForm.ID);
                command.Parameters.AddWithValue("@sonAy", sonAy);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    int primID = Convert.ToInt32(result);
                    ItirazFormu itirazFormu = new ItirazFormu(primID);
                    itirazFormu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Son aya ait prim kaydı bulunamadı.");
                }
                connection.Close();
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
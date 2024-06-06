using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VeriTabaniProje
{
    public partial class ›tirazListesi : Form
    {
        public ›tirazListesi()
        {
            InitializeComponent();
        }

        private void ›tirazListesi_Load(object sender, EventArgs e)
        {
            Load›tirazList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Load›tirazList()
        {
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = "SELECT Ay, Aciklama, Cevap, ›tirazDurumID FROM dbo.›tirazlar WHERE AsistanId = @AsistanID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@AsistanID", LoginForm.ID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AsistanAnaEkran asistanAnaEkran = new AsistanAnaEkran();
            asistanAnaEkran.Show();
            Hide();
        }
    }
}

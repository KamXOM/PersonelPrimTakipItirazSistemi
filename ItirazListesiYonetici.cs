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
    public partial class ItirazListesiYonetici : Form
    {
        public ItirazListesiYonetici()
        {
            InitializeComponent();
        }

        private void ItirazListesiYonetici_Load(object sender, EventArgs e)
        {
            ItirazlariGetir();
        }
        private void ItirazlariGetir()
        {
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = "";
            if (LoginForm.ID == 1)
            {
                query = "SELECT * FROM vw_GrupYoneticisiListeleme1";
            }
            else if (LoginForm.ID == 2)
            {
                query = "SELECT * FROM vw_GrupYoneticisiListeleme2";
            }
            else
            {
                query = @"SELECT a.SicilNo, a.AsistanAd, a.AsistanSoyad, i.Aciklama, i.Cevap, i.Ay
                FROM İtirazDurum id INNER JOIN İtirazlar i ON id.İtirazID = i.İtirazDurumID
                INNER JOIN Asistanlar a ON a.AsistanID = i.AsistanID
                INNER JOIN TakimLiderleri tl ON tl.TakimLideriID = a.TakimLideriID
                INNER JOIN GrupYoneticileri gy ON gy.GrupYoneticisiID = tl.GrupYoneticisiID
                WHERE gy.GrupYoneticisiID = @grupYoneticisiID";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter;
                if (LoginForm.ID == 1 || LoginForm.ID == 2)
                {
                    adapter = new SqlDataAdapter(query, connection);
                }
                else
                {
                    adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@grupYoneticisiID", LoginForm.ID);
                }
                adapter.SelectCommand.Parameters.AddWithValue("@grupYoneticisiID", LoginForm.ID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GrupYoneticisiAnaEkran grupYoneticisiAnaEkran = new GrupYoneticisiAnaEkran();
            grupYoneticisiAnaEkran.Show();
            Hide();
        }
    }
}

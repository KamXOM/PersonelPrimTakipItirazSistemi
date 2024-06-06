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
    public partial class PrimItirazlari : Form
    {
        public PrimItirazlari()
        {
            InitializeComponent();
        }

        private void PrimItirazlari_Load(object sender, EventArgs e)
        {
            ItirazlariGetir();
        }
        private void ItirazlariGetir()
        {
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = @"SELECT a.SicilNo, a.AsistanAd, a.AsistanSoyad, i.Aciklama, i.Ay, i.İtirazID
                FROM İtirazlar i INNER JOIN Asistanlar a ON i.AsistanID = a.AsistanID
                INNER JOIN TakimLiderleri tl ON a.TakimLideriID = tl.TakimLideriID
                WHERE tl.TakimLideriID = @takimLideriID AND i.Cevap IS NULL";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@takimLideriID", LoginForm.ID);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                if (!dataGridView1.Columns.Contains("ItirazCevapla"))
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "ItirazCevapla";
                    buttonColumn.HeaderText = "İtiraz Cevapla";
                    buttonColumn.Text = "Cevapla";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(buttonColumn);
                }
                if (dataGridView1.Columns.Contains("İtirazID"))
                {
                    dataGridView1.Columns["İtirazID"].Visible = false;
                }
                connection.Close();
            }
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ItirazCevapla")
            {
                int itirazID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["İtirazID"].Value);
                ItirazCevaplaForm itirazCevaplaForm = new ItirazCevaplaForm(itirazID);
                itirazCevaplaForm.ShowDialog();
                ItirazlariGetir();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TakimLideriAnaSayfa takimLideriAnaSayfa = new TakimLideriAnaSayfa();
            takimLideriAnaSayfa.Show();
            Hide();
        }
    }
}

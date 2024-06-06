using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabaniProje
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        static public int ID;
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void GirisButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string adSoyad = textBox2.Text;
                string sicilNo = textBox1.Text;
                string[] ayrilmis;
                string isim = string.Empty, soyisim = string.Empty;
                bool isValidInput = true;
                try
                {
                    adSoyad = Regex.Replace(adSoyad, @"\s+", " ").Trim();
                    ayrilmis = adSoyad.Split(" ");
                    if (ayrilmis.Length < 2)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    isim = ayrilmis[0];
                    soyisim = ayrilmis[1];
                }
                catch (IndexOutOfRangeException)
                {
                    isValidInput = false;
                    MessageBox.Show("Lütfen adınızı ve soyadınızı boşluk bırakarak girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (isValidInput)
                {
                    if (LoginUser(connection, "Asistanlar", sicilNo, isim, soyisim,1, out int asistanID))
                    {
                        MessageBox.Show("Asistan olarak giriş yapıldı.");
                        ID = asistanID;
                        MessageBox.Show(string.Format("ID: {0}", ID));
                        AsistanAnaEkran asistanAnaEkran = new AsistanAnaEkran();
                        asistanAnaEkran.Show();
                        this.Hide();
                        return;
                    }

                    if (LoginUser(connection, "TakimLiderleri", sicilNo, isim, soyisim,2, out int takimLideriID))
                    {
                        MessageBox.Show("Takım Lideri olarak giriş yapıldı.");
                        ID = takimLideriID;
                        MessageBox.Show(string.Format("ID: {0}", ID));
                        TakimLideriAnaSayfa takimLideriForm = new TakimLideriAnaSayfa();
                        takimLideriForm.Show();
                        this.Hide();
                        return;
                    }

                    if (LoginUser(connection, "GrupYoneticileri", sicilNo, isim, soyisim,3, out int grupYoneticiID))
                    {
                        MessageBox.Show("Grup Yöneticisi olarak giriş yapıldı.");
                        ID = grupYoneticiID;
                        MessageBox.Show(string.Format("ID: {0}", ID));
                        GrupYoneticisiAnaEkran grupYoneticisiForm = new GrupYoneticisiAnaEkran();
                        grupYoneticisiForm.Show();
                        this.Hide();
                        return;
                    }
                    MessageBox.Show("Giriş başarısız! Sicil numarası veya ad soyad bilgisi yanlış.");
                }
                connection.Close();
            }
        }
        private bool LoginUser(SqlConnection connection, string tableName, string sicilNo, string isim, string soyisim,int yetki, out int userID)
        {
            userID = 0;
            string query = string.Empty;
            switch (yetki)
            {
                case 1:
                    try
                    {
                        query = "SELECT AsistanID FROM Asistanlar WHERE SicilNo = @SicilNo";
                        using (SqlCommand checkCommand = new SqlCommand(query, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@SicilNo", sicilNo);
                            object result1 = checkCommand.ExecuteScalar();
                            if (result1 == null)
                            {
                                break;
                            }
                            else
                            {
                                userID = Convert.ToInt32(result1);
                            }
                        }
                        using (SqlCommand command = new SqlCommand("sp_AsistanGiris", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@SicilNo", sicilNo);
                            command.Parameters.AddWithValue("@AsistanAd", isim);
                            command.Parameters.AddWithValue("@AsistanSoyad", soyisim);
                            int userCount = (int)command.ExecuteScalar();
                            return userCount > 0;
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Veritabanı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;
                case 2:
                    try
                    {
                        query = "SELECT TakimLideriID FROM TakimLiderleri WHERE SicilNo = @SicilNo";
                        using (SqlCommand checkCommand = new SqlCommand(query, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@SicilNo", sicilNo);
                            object result2 = checkCommand.ExecuteScalar();
                            if (result2 == null)
                            {
                                break;
                            }
                            else
                            {
                                userID = Convert.ToInt32(result2);
                            }
                        }
                        using (SqlCommand command = new SqlCommand("sp_TakimLideriGiris", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@SicilNo", sicilNo);
                            command.Parameters.AddWithValue("@TakimLideriAd", isim);
                            command.Parameters.AddWithValue("@TakimLideriSoyad", soyisim);
                            int userCount = (int)command.ExecuteScalar();
                            return userCount > 0;
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Veritabanı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;
                case 3:
                    try
                    {
                        query = "SELECT GrupYoneticisiID FROM GrupYoneticileri WHERE SicilNo = @SicilNo";
                        using (SqlCommand checkCommand = new SqlCommand(query, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@SicilNo", sicilNo);
                            object result3 = checkCommand.ExecuteScalar();
                            if (result3 == null)
                            {
                                break;
                            }
                            else
                            {
                                userID = Convert.ToInt32(result3);
                            }
                        }
                        using (SqlCommand command = new SqlCommand("sp_GrupYoneticisiGiris", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@SicilNo", sicilNo);
                            command.Parameters.AddWithValue("@GrupYoneticiAd", isim);
                            command.Parameters.AddWithValue("@GrupYoneticiSoyad", soyisim);
                            int userCount = (int)command.ExecuteScalar();
                            return userCount > 0;
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Veritabanı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;
                default:
                    MessageBox.Show("Yetki Hatası!");
                    return false;
            }
            return false;
        }
    }
}

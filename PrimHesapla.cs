using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriTabaniProje
{
    public class PrimHesapla
    {
        private string connectionString = "Data Source=KAMX;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
        private decimal aylikTabanPrim = 5000;
        public decimal Hesapla(int ay)
        {
            decimal toplamPrim;
            int toplamGorusmeSayisi = 0;
            int kisaGorusmeSayisi = 0;
            string query = @"SELECT 
                                COUNT(*) AS ToplamGorusmeSayisi,
                                SUM(CASE WHEN DATEDIFF(MINUTE, '00:00:00', GorusmeSuresi) <= 5 THEN 1 ELSE 0 END) AS KisaGorusmeSayisi
                            FROM Gorusmeler
                            WHERE AsistanID = @asistanID AND MONTH(Tarih) = @ay";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@asistanID", LoginForm.ID);
                command.Parameters.AddWithValue("@ay", ay);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        toplamGorusmeSayisi = reader.GetInt32(0);
                        kisaGorusmeSayisi = reader.GetInt32(1);
                    }
                }
                connection.Close();
            }
            if (toplamGorusmeSayisi < 100)
            {
                toplamPrim = 0;
            }
            else if (toplamGorusmeSayisi < 200)
            {
                toplamPrim = kisaGorusmeSayisi * 1.25M + aylikTabanPrim + ((toplamGorusmeSayisi - kisaGorusmeSayisi) * 2M);
            }
            else
            {
                toplamPrim = toplamGorusmeSayisi * 2M + aylikTabanPrim;
            }
            string mergeQuery = @"
                IF EXISTS (SELECT 1 FROM Primler WHERE AsistanID = @asistanID AND Ay = @ay)
                BEGIN
                    UPDATE Primler
                    SET ToplamPrimMiktari = @toplamPrim
                    WHERE AsistanID = @asistanID AND Ay = @ay
                END
                ELSE
                BEGIN
                    INSERT INTO Primler (AsistanID, Ay, ToplamGorusmeSayisi, ToplamPrimMiktari)
                    VALUES (@asistanID, @ay, @toplamGorusmeSayisi, @toplamPrim)
                END";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(mergeQuery, connection))
            {
                command.Parameters.AddWithValue("@asistanID", LoginForm.ID);
                command.Parameters.AddWithValue("@ay", ay);
                command.Parameters.AddWithValue("@toplamGorusmeSayisi", toplamGorusmeSayisi);
                command.Parameters.AddWithValue("@toplamPrim", toplamPrim);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return toplamPrim;
        }
    }
}

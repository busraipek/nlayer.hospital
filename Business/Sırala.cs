using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Business
{
    public class Sırala
    {
        private DataAccess.Baglanti baglanti = new Baglanti();

        public void DoktorSırala(string brans,ref string kimlik, List<string> list)
        {
            OleDbConnection connection = baglanti.BaglantiAc();

            string query = "SELECT ad,soyad,kimlikno FROM Doktor WHERE brans = @brans";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@brans", brans);
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        Doktor li = new Doktor()
                        {
                            ad = (string)reader["ad"],
                            soyad = (string)reader["soyad"],
                            kimlikno = (string)reader["kimlikno"],
                        };
                        list.Add(li.ad +" "+ li.soyad);
                        kimlik = li.kimlikno.ToString();
                        i = i + 1;
                    }
                }
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public void HastaSırala(string kimlik, List<string> liste)
        {
            OleDbConnection connection = baglanti.BaglantiAc();
            try
            {
            string query = "SELECT ad,soyad FROM Hasta WHERE kimlikno = @kimlikno";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@kimlikno", kimlik);
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        Hasta li = new Hasta()
                        {
                            ad = (string)reader["ad"],
                            soyad = (string)reader["soyad"],
                        };
                        liste.Add(li.ad.ToString() + " " + li.soyad.ToString()) ;
                        i = i + 1;
                    }
                }
                command.ExecuteNonQuery();
            }
            }
            catch
            {
                throw;
            }

            connection.Close();
        }
    }
}

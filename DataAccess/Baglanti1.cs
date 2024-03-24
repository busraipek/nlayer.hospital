using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class Baglanti
    {
        public OleDbConnection BaglantiAc()
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\90505\\Desktop\\Hastane\\hastane.accdb");
            connection.Open();
            return connection;
        }
        public OleDbCommand SorguOlustur(string sorgu)
        {
            OleDbCommand cmd = new OleDbCommand(sorgu, BaglantiAc());
            return cmd;
        }
    }
}

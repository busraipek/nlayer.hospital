﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data.OleDb;
using ZedGraph;
using System.Collections;

namespace Business
{
   public  class HatalıkBölümleri_Zed_Graph
    {
        private DataAccess.Baglanti baglanti = new DataAccess.Baglanti();

        //public PointPairList LoadGraphData()
        //{
            //OleDbConnection connection = baglanti.BaglantiAc();
            //PointPairList list = new PointPairList();

            //string query = "SELECT hg.doktor_kimlik,COUNT(h.kimlikno) AS hastaSayisi FROM HastaGecmisi hg LEFT JOIN Hasta h ON hg.kimlikno = h.kimlikno GROUP BY hg.doktor_kimlik;";
            //;

            //using (OleDbCommand command = new OleDbCommand(query, connection))
            //{
            //    using (OleDbDataReader reader = command.ExecuteReader())
            //    {
            //        int indis = 1;

            //        while (reader.Read())
            //        {
            //            string doktor_kimlik = reader["doktor_kimlik"].ToString();
            //            int hastaSayisi = Convert.ToInt32(reader["hastaSayisi"]);

            //            list.Add(indis, hastaSayisi, doktor_kimlik);
            //            indis++;
            //        }
            //    }
            //}

            //return list;
     
    }
}


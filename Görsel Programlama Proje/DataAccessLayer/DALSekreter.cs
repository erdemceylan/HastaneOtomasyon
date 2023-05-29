 using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using EntityLayer;
using System.Data;
using System.Data.Sql;

namespace DataAccessLayer
{
    public class DALSekreter
    {
        //Sekreter Listesi
        public static List<EntitySekreter> SekreterListesi()
        {
            List<EntitySekreter> degerler = new List<EntitySekreter>();
            SqlCommand komut1 = new SqlCommand("Select* from TblSekreter", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntitySekreter ent = new EntitySekreter();
                ent.SekreterTC1= dr["SekreterTC"].ToString();
                ent.SekreterAdi1 = dr["SekreterAdi"].ToString();
                ent.SekreterSoyadi1= dr["SekreterSoyadi"].ToString();
                ent.SekreterSifre1 = dr["SekreterSifre"].ToString();
                

                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }

        //Sekreter Ekleme Sql Kodu
        public static int SekreterEkle(EntitySekreter s)
        {
            SqlCommand komut2 = new SqlCommand("insert into TblSekreter(SekreterTC,SekreterAdi,SekreterSoyadi,SekreterSifre) values (@P1,@P2,@P3,@P4)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", s.SekreterTC1);
            komut2.Parameters.AddWithValue("@P2", s.SekreterAdi1);
            komut2.Parameters.AddWithValue("@P3", s.SekreterSoyadi1);
            
            komut2.Parameters.AddWithValue("@P4", s.SekreterSifre1);
           


            return komut2.ExecuteNonQuery();

        }

        //Sekreter Güncelleme Sql Kodu
        public static bool SekreterGuncelle(EntitySekreter ent)
        {
            SqlCommand komut4 = new SqlCommand("Update TblSekreter set  SekreterAdi=@P2, SekreterSoyadi=@P3,SekreterSifre=@P4 where SekreterTC=@P1", Baglanti.bgl
                );

            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", ent.SekreterTC1);
            komut4.Parameters.AddWithValue("@P2", ent.SekreterAdi1);
            komut4.Parameters.AddWithValue("@P3", ent.SekreterSoyadi1);
            komut4.Parameters.AddWithValue("@P4", ent.SekreterSifre1);

            return komut4.ExecuteNonQuery() > 0;


        }

        //Sekreter Silme Sql Kodu
        public static bool SekreterSil(string s)
        {
            SqlCommand komut3 = new SqlCommand("Delete from TblSekreter where SekreterTC=@P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", s);
            return komut3.ExecuteNonQuery() > 0;
        }

        //Sekreter giriş kontrolü
        public static int SekreterGiris(EntitySekreter es)
        {
            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            SqlCommand sekreterBaglanti = new SqlCommand("Select * from TblSekreter where SekreterTC='" + es.SekreterTC1 + "' AND SekreterSifre='" + es.SekreterSifre1 + "'", Baglanti.bgl);
            SqlDataReader dr = sekreterBaglanti.ExecuteReader();

            if (dr.Read())
            {
                EntitySekreter sekreter = new EntitySekreter();
                es.SekreterTC1 = dr["SekreterTC"].ToString();
                es.SekreterAdi1 = dr["SekreterAdi"].ToString();
                es.SekreterSoyadi1 = dr["SekreterSoyadi"].ToString();
                es.SekreterSifre1 = dr["SekreterSifre"].ToString();

                dr.Close();
                return 1;
            }
            else
            {
                dr.Close();
                return 2;
            }
        }

        //Sekreter bilgi tutma
        public static EntitySekreter SekreterBilgiTut(EntitySekreter p)
        {
            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            EntitySekreter sekreter= new EntitySekreter();
            SqlCommand sekreterBaglanti = new SqlCommand("Select * from TblSekreter where SekreterTC='" + p.SekreterTC1 + "'AND SekreterSifre='" + p.SekreterSifre1+ "'", Baglanti.bgl);
            SqlDataReader dr = sekreterBaglanti.ExecuteReader();

            if (dr.Read())
            {
                sekreter.SekreterTC1 = Convert.ToString(dr["SekreterTC"]);
                sekreter.SekreterAdi1 = Convert.ToString(dr["SekreterAdi"]);
                sekreter.SekreterSoyadi1 = Convert.ToString(dr["SekreterSoyadi"]);
                sekreter.SekreterSifre1 = Convert.ToString(dr["SekreterSifre"]);
                
            }
            dr.Close();
            return sekreter;
        }
    }
}

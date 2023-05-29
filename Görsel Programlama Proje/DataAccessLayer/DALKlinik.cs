using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using EntityLayer;
using System.Data;
using System.Data.Sql;

namespace DataAccessLayer
{
   public  class DALKlinik
    {
        //Klinikleri Listeler
        public static List<EntityKlinik> KlinikListesi()
        {
            List<EntityKlinik> degerler = new List<EntityKlinik>();
            SqlCommand komut1 = new SqlCommand("Select * from TblKlinik", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityKlinik ent = new EntityKlinik();
                
                ent.KlinikID1 = Convert.ToInt16(dr["KlinikID"]);
                ent.KlinikAdi1 = Convert.ToString(dr["KlinikAdi"]);
                
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }

        //Grafikler için oluşturulan Kliniklistesi Klinik Adlarını getirir
        public static List<string> KlinikListesiGrafik()
        {
            List<string> degerler = new List<string>();
            SqlCommand komut1 = new SqlCommand("Select * from TblKlinik", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                

                degerler.Add(Convert.ToString(dr["KlinikAdi"].ToString()));

            }
            dr.Close();
            return degerler;
        }

        
        //TblKlinik tablosundan KlinikID listelemek için oluşturuldu
        public static EntityKlinik KlinikIDListele(EntityKlinik p)
        {
            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            EntityKlinik klinik = new EntityKlinik();
            SqlCommand klinikBaglanti = new SqlCommand("select KlinikID from TblKlinik where KlinikAdi = @KlinikAdi",Baglanti.bgl);
            if(klinikBaglanti.Connection.State != ConnectionState.Open) { klinikBaglanti.Connection.Open(); }
            klinikBaglanti.Parameters.AddWithValue("@KlinikAdi", p.KlinikAdi1);
            SqlDataReader dr = klinikBaglanti.ExecuteReader();

            if (dr.Read())
            {
                klinik.KlinikID1 = Convert.ToInt32(dr["KlinikID"]);
                
            }
            dr.Close();
            return klinik;
        }

        //TblKlinik tablosundan KlinikAdini getirme
        public static EntityKlinik IlgiliKlinikAdiGetir(int p)
        {
            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            EntityKlinik klinik = new EntityKlinik();
            SqlCommand klinikBaglanti = new SqlCommand("select KlinikAdi from TblKlinik where KlinikID=@KlinikID", Baglanti.bgl);
            klinikBaglanti.Parameters.AddWithValue("@KlinikID", p);
            SqlDataReader dr = klinikBaglanti.ExecuteReader();

            if (dr.Read())
            {
                klinik.KlinikAdi1 = Convert.ToString(dr["KlinikAdi"]);
            }
            dr.Close();
            return klinik;
        }

        //Branşlara göre doktor listeleme
        public static List<EntityDoktor> IlgiliBranchDoctorListele(int p)
        {
            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            List<EntityDoktor> doctorList = new List<EntityDoktor>();
            SqlCommand branchBaglanti = new SqlCommand("Select DoktorAdi from TblDoktor where klinikID = @klinikID", Baglanti.bgl);
            if (branchBaglanti.Connection.State != ConnectionState.Open) { branchBaglanti.Connection.Open(); }
            branchBaglanti.Parameters.AddWithValue("@klinikID", p);
            SqlDataReader dr = branchBaglanti.ExecuteReader();

            while (dr.Read())
            {
                EntityDoktor doctor = new EntityDoktor();
                doctor.DoktorAdi1 = Convert.ToString(dr["DoktorAdi"]);
                doctorList.Add(doctor);
            }
            dr.Close();
            return doctorList;
            
        }

        //Klinik Ekleme
        public static int KlinikEkle(EntityKlinik d)
        {
            SqlCommand komut2 = new SqlCommand("insert into TblKlinik(KlinikID,KlinikAdi) values (@P1,@P2)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", d.KlinikID1);
            komut2.Parameters.AddWithValue("@P2", d.KlinikAdi1);
           
            return komut2.ExecuteNonQuery();

        }

        //Klinik Silme
        public static bool KlinikSil(int d)
        {
            SqlCommand komut3 = new SqlCommand("Delete from TblKlinik where KlinikID=@P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", d);
            return komut3.ExecuteNonQuery() > 0;
        }

        //Klinik Güncelleme
        public static bool KlinikGuncelle(EntityKlinik ent)
        {
            SqlCommand komut4 = new SqlCommand("Update TblKlinik set  KlinikAdi=@P2 where KlinikID=@P1", Baglanti.bgl);

            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", ent.KlinikID1);
            komut4.Parameters.AddWithValue("@P2", ent.KlinikAdi1);
          
            return komut4.ExecuteNonQuery() > 0;


        }
    }
}

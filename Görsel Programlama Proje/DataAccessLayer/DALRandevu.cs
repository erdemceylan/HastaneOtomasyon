using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using EntityLayer;
using System.Data;
using System.Data.Sql;

namespace DataAccessLayer
{
    public class DALRandevu
    {
        //vt randevu oluşturma
        public static int RandevuOlustur(EntityRandevu p)
        {
            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            SqlCommand randevuBaglanti = new SqlCommand("insert into TblRandevu (DoktorTC,KlinikID,HastaTC,tarih,HastaAdi,HastaSoyadi,eposta) values (@DoktorTC,@KlinikID,@HastaTC,@tarih,@HastaAdi,@HastaSoyadi,@eposta)", Baglanti.bgl);

            randevuBaglanti.Parameters.AddWithValue("@DoktorTC", p.DoktorTC1);
            randevuBaglanti.Parameters.AddWithValue("@KlinikID", p.KlinikID1);
            randevuBaglanti.Parameters.AddWithValue("@HastaTC", p.HastaTC1);
            randevuBaglanti.Parameters.AddWithValue("@tarih", p.Date);
            randevuBaglanti.Parameters.AddWithValue("@HastaAdi", p.HastaAdi1);
            randevuBaglanti.Parameters.AddWithValue("@HastaSoyadi", p.HastaSoyadi1);
            randevuBaglanti.Parameters.AddWithValue("@eposta", p.Eposta);
            return randevuBaglanti.ExecuteNonQuery();
        }

        public static List<EntityRandevu> RandevuListesi()
        {
            List<EntityRandevu> degerler = new List<EntityRandevu>();
            SqlCommand komut1 = new SqlCommand("Select* from TblRandevu", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityRandevu ent = new EntityRandevu();
                ent.RandevuID1 = Convert.ToInt32(dr["RandevuID"].ToString());
                ent.DoktorTC1 = dr["DoktorTC"].ToString();
                ent.KlinikID1 = Convert.ToInt32(dr["KlinikID"].ToString());
                ent.HastaTC1 = dr["HastaTC"].ToString();
                ent.Date = Convert.ToDateTime(dr["tarih"]);
                ent.HastaAdi1 = dr["HastaAdi"].ToString();
                ent.HastaSoyadi1 = dr["HastaSoyadi"].ToString();
                ent.Eposta = dr["eposta"].ToString();
             

                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }
        //Randevu Silme
        public static bool RandevuSil(string s)
        {
            SqlCommand komut3 = new SqlCommand("Delete from TblRandevu where RandevuID=@P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", s);
            return komut3.ExecuteNonQuery() > 0;
        }

        //Randevu Güncelleme Sql Kodu
        public static bool RandevuGuncelle(EntityRandevu ent)
        {
            SqlCommand komut4 = new SqlCommand("Update TblRandevu set  DoktorTC=@P2, KlinikID=@P3,HastaTC=@P4,tarih=@P5,HastaAdi=@P6,HastaSoyadi=@P7,eposta=@P8 where RandevuID=@P1", Baglanti.bgl
                );

            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", ent.RandevuID1);
            komut4.Parameters.AddWithValue("@P2", ent.DoktorTC1);
            komut4.Parameters.AddWithValue("@P3", ent.KlinikID1);
            komut4.Parameters.AddWithValue("@P4", ent.HastaTC1);
            komut4.Parameters.AddWithValue("@P5", ent.Date);
            komut4.Parameters.AddWithValue("@P6", ent.HastaAdi1);
            komut4.Parameters.AddWithValue("@P7", ent.HastaSoyadi1);
            komut4.Parameters.AddWithValue("@P8", ent.Eposta);
            return komut4.ExecuteNonQuery() > 0;

        }

    }
}

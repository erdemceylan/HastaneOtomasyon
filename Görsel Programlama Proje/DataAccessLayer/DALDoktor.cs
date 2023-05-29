using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using EntityLayer;
using System.Data;
using System.Data.Sql;

namespace DataAccessLayer
{
    public class DALDoktor
    {
        //Doktorları listeleme
        //Doktorları listelemek için list oluşturup veri tabanında bulunan doktorları "Select* from TblDoktor"sorgusu ile alırız
        //Veritabanı bağlantıları açılır ve read komutu ile verileri alırız.
        //dr.Close() komutu ile bağlantı komutları kapatılır.
        //Daha sonra DoktorListesi() fonksiyonumuz degerleri return eder.
        public static List<EntityDoktor> DoktorListesi()
        {
            List<EntityDoktor> degerler = new List<EntityDoktor>();
            SqlCommand komut1 = new SqlCommand("Select* from TblDoktor", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityDoktor ent = new EntityDoktor();
                ent.DoktorTC1 = dr["DoktorTC"].ToString();
                ent.DoktorAdi1 = dr["DoktorAdi"].ToString();
                ent.DoktorSoyadi1 = dr["DoktorSoyadi"].ToString();
                //KlinikID int türünde olduğu için int.Parse ile tür dönüşümü yaparız.
                ent.KlinikID = int.Parse(dr["klinikID"].ToString());
                ent.DoktorSifre1 = dr["DoktorSifre"].ToString();
           
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }

        //Doktor Ekleme
        //Veritabanına doktorları eklemek için "insert into TblDoktor values.. sorgusu yazılarak ekleme işlemleri gerçekleştirilir.
        public static int DoktorEkle(EntityDoktor d)
        {
            SqlCommand komut2 = new SqlCommand("insert into TblDoktor(DoktorTC,DoktorAdi,DoktorSoyadi,klinikID,DoktorSifre) values (@P1,@P2,@P3,@P4,@P5)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", d.DoktorTC1);
            komut2.Parameters.AddWithValue("@P2", d.DoktorAdi1);
            komut2.Parameters.AddWithValue("@P3", d.DoktorSoyadi1);
            komut2.Parameters.AddWithValue("@P4", d.KlinikID);
            komut2.Parameters.AddWithValue("@P5", d.DoktorSifre1);
            
            return komut2.ExecuteNonQuery();

        }


        //Doktor Silme
        //Doktorları veritabanından silmek için de "Delete from TblDoktor where DoktorTC=@P1" TC'ye göre silme işlemi
        public static bool DoktorSil(string d)
        {
            SqlCommand komut3 = new SqlCommand("Delete from TblDoktor where DoktorTC=@P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", d);
            return komut3.ExecuteNonQuery() > 0;
        }

        //Doktor Güncelleme
        //Seçilen ID ye sahip doktorun bilgilerini sql update komutu ile günceller
        public static bool DoktorGuncelle(EntityDoktor ent)
        {
            SqlCommand komut4 = new SqlCommand("Update TblDoktor set  DoktorAdi=@P2, DoktorSoyadi=@P3,klinikID=@P4, DoktorSifre=@P5 where DoktorTC=@P1", Baglanti.bgl);

            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", ent.DoktorTC1);
            komut4.Parameters.AddWithValue("@P2", ent.DoktorAdi1);
            komut4.Parameters.AddWithValue("@P3", ent.DoktorSoyadi1);
            komut4.Parameters.AddWithValue("@P4", ent.KlinikID);
            komut4.Parameters.AddWithValue("@P5", ent.DoktorSifre1);
            
            return komut4.ExecuteNonQuery() > 0;


        }

        //Kullanıcıdan gelen DoktorTC bilgisi ile TBLDoktor tablosundan DoktorAdi'ni getirir.
        public static EntityDoktor DoktorIDListele(EntityDoktor p)
        {
            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            EntityDoktor doktor = new EntityDoktor();
            SqlCommand doktorBaglanti = new SqlCommand("select DoktorTC from TblDoktor where DoktorAdi = @DoktorAdi", Baglanti.bgl);
            if (doktorBaglanti.Connection.State != ConnectionState.Open) { doktorBaglanti.Connection.Open(); }
            doktorBaglanti.Parameters.AddWithValue("@DoktorAdi", p.DoktorAdi1);
            SqlDataReader dr = doktorBaglanti.ExecuteReader();

            if (dr.Read())
            {
                doktor.DoktorTC1 = Convert.ToString(dr["DoktorTC"]);
            }
            dr.Close();
            return doktor;
        }


        public static int DoktorGiris(EntityDoktor es)
        {

            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            SqlCommand doktorBaglanti = new SqlCommand("Select *from TblDoktor where DoktorTC='" + es.DoktorTC1 + "' AND DoktorSifre='" + es.DoktorSifre1+ "'", Baglanti.bgl);
            SqlDataReader dr = doktorBaglanti.ExecuteReader();

            if (dr.Read())
            {
                EntityDoktor doktor = new EntityDoktor();
                es.DoktorTC1 = dr["DoktorTC"].ToString();
                es.DoktorAdi1 = dr["DoktorAdi"].ToString();
                es.DoktorSoyadi1 = dr["DoktorSoyadi"].ToString();
                es.DoktorSifre1 = dr["DoktorSifre"].ToString();

                dr.Close();
                return 1;
            }
            else
            {
                dr.Close();
                return 2;
            }
        }

        //Doktor bilgilerini tutar
        //Doktor sayfa değiştirdiğinde çıkış yapmadığı sürece bilgilerin kaybolmaması gerekir sayfalar arası bilgileri tutar
        public static EntityDoktor DoktorBilgiTut(EntityDoktor p)
        {
            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            EntityDoktor doktor = new EntityDoktor();
            SqlCommand doktorBaglanti = new SqlCommand("Select * from TblDoktor where DoktorTC=" + p.DoktorTC1 + "AND DoktorSifre=" + p.DoktorSifre1, Baglanti.bgl);
            SqlDataReader dr = doktorBaglanti.ExecuteReader();

            if (dr.Read())
            {
                doktor.DoktorTC1 = Convert.ToString(dr["DoktorTC"]);
                doktor.DoktorAdi1 = Convert.ToString(dr["DoktorAdi"]);
                doktor.KlinikID = int.Parse(dr["klinikID"].ToString());
                doktor.DoktorSoyadi1 = Convert.ToString(dr["DoktorSoyadi"]);
                doktor.DoktorSifre1 = Convert.ToString(dr["DoktorSifre"]);

            }
            dr.Close();
            return doktor;
        }
      
        //Seçilen KlinikID'ye göre Doktor adını TblDoktor tablosundan getirir.
        public static EntityDoktor IlgiliDoktorAdiGetir(int p)
        {
            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            EntityDoktor doktor = new EntityDoktor();
            SqlCommand doktorbaglanti = new SqlCommand("Select* from TblDoktor where klinikID=@klinikID", Baglanti.bgl);
            doktorbaglanti.Parameters.AddWithValue("@KlinikID", p);
            SqlDataReader dr = doktorbaglanti.ExecuteReader();

            if (dr.Read())
            {
                doktor.DoktorAdi1 = Convert.ToString(dr["DoktorAdi"]);
            }
            dr.Close();
            return doktor;
        }
    }
}

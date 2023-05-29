using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using EntityLayer;
using System.Data;
using System.Data.Sql;

namespace DataAccessLayer
{
    public class DALHasta
    {
        //Grafikler için oluşturulan değişkenler
        public static int hastasayisiKlinik;
        public static int hastasayisiDoktor;


        //Hastaları Listeleme TblHasta tablosundan hastaları listeler
        public static List<EntityHasta> HastaListesi()
        {
            List<EntityHasta> degerler = new List<EntityHasta>();
            SqlCommand komut1 = new SqlCommand("Select* from TblHasta", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityHasta ent = new EntityHasta();
                ent.HastaTc = dr["HastaTC"].ToString();
                ent.HastaAdi = dr["HastaAdi"].ToString();
                ent.HastaSoyadi = dr["HastaSoyadi"].ToString();
                ent.DogumTarihi = dr["dogumTarihi"].ToString();
                ent.Cinsiyeti = dr["cinsiyeti"].ToString();
                ent.Ceptel = dr["cepTel"].ToString();
                ent.EPosta = dr["ePosta"].ToString();
                ent.Teshis1 = dr["Teshis"].ToString();
                ent.DoktorNotu1 = dr["DoktorNotu"].ToString();
                ent.KlinikID1 = int.Parse(dr["KlinikID"].ToString());
                ent.KanTahlil1= dr["KanTahlil"].ToString();
                ent.Rontgen1 = dr["Rontgen"].ToString();
                ent.DoktorTC1= dr["DoktorTC"].ToString();

                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }
        //Hasta Ekleme SQL kodları
        //TblHasta tablosuna "insert into TblHasta values.. komutu ile kullanıcıdan gelen bilgiler vt'ye eklenir.
        public static int HastaEkle(EntityHasta h)
        {
            SqlCommand komut2 = new SqlCommand("insert into TblHasta(HastaTC,HastaAdi,HastaSoyadi,dogumTarihi,cinsiyeti,ceptel,ePosta,KlinikID,Teshis,DoktorNotu,DoktorTC,KanTahlil,Rontgen) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", h.HastaTc);
            komut2.Parameters.AddWithValue("@P2", h.HastaAdi);
            komut2.Parameters.AddWithValue("@P3", h.HastaSoyadi);
            komut2.Parameters.AddWithValue("@P4", h.DogumTarihi);
            komut2.Parameters.AddWithValue("@P5", h.Cinsiyeti);
            komut2.Parameters.AddWithValue("@P6", h.Ceptel);
            komut2.Parameters.AddWithValue("@P7", h.EPosta);
            komut2.Parameters.AddWithValue("@P8", h.KlinikID1);
            komut2.Parameters.AddWithValue("@P9", h.Teshis1);
            komut2.Parameters.AddWithValue("@P10", h.DoktorNotu1);
            komut2.Parameters.AddWithValue("@P11", h.DoktorTC1);
            komut2.Parameters.AddWithValue("@P12", h.KanTahlil1);
            komut2.Parameters.AddWithValue("@P13", h.Rontgen1);

            return komut2.ExecuteNonQuery();

        }

        //Hasta Silme Sql Kodları
        public static bool HastaSil(string h)
        {
            SqlCommand komut3 = new SqlCommand("Delete from TblHasta where HastaTC=@P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", h);
            return komut3.ExecuteNonQuery() > 0;
        }

        //Hasta güncelleme Sql kodları
        public static bool HastaGuncelle(EntityHasta ent)
        {
            SqlCommand komut4 = new SqlCommand("Update TblHasta set HastaAdi=@P2, HastaSoyadi=@P3,dogumTarihi=@P4,cinsiyeti=@P5,ceptel=@P6,ePosta=@P7,KlinikID=@P8, Teshis=@P9, DoktorNotu=@P10,DoktorTC=@P11,KanTahlil=@P12,Rontgen=@P13 where HastaTC=@P1", Baglanti.bgl
                );

            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", ent.HastaTc);
            komut4.Parameters.AddWithValue("@P2", ent.HastaAdi);
            komut4.Parameters.AddWithValue("@P3", ent.HastaSoyadi);
            komut4.Parameters.AddWithValue("@P4", ent.DogumTarihi);
            komut4.Parameters.AddWithValue("@P5", ent.Cinsiyeti);
            komut4.Parameters.AddWithValue("@P6", ent.Ceptel);
            komut4.Parameters.AddWithValue("@P7", ent.EPosta);
            komut4.Parameters.AddWithValue("@P8", ent.KlinikID1);
            komut4.Parameters.AddWithValue("@P9", ent.Teshis1);
            komut4.Parameters.AddWithValue("@P10", ent.DoktorNotu1);
            komut4.Parameters.AddWithValue("@P11", ent.DoktorTC1);
            komut4.Parameters.AddWithValue("@P12", ent.KanTahlil1);
            komut4.Parameters.AddWithValue("@P13", ent.Rontgen1);
            return komut4.ExecuteNonQuery() > 0;


        }

        //Doktorun sadece kendi hastalarını görebilmesi için oluşturulmuştur.
        //İlgili doktora göre hastaları listeler
        public static List<EntityHasta> IlgiliHastaListesi(string p)
        {
            List<EntityHasta> degerler = new List<EntityHasta>();
            SqlCommand komut1 = new SqlCommand("Select* from TblHasta where DoktorTC=@DoktorTC", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            komut1.Parameters.AddWithValue("@DoktorTC", p);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityHasta ent = new EntityHasta();
                ent.HastaTc = dr["HastaTC"].ToString();
                ent.HastaAdi = dr["HastaAdi"].ToString();
                ent.HastaSoyadi = dr["HastaSoyadi"].ToString();
                ent.DogumTarihi = dr["dogumTarihi"].ToString();
                ent.Cinsiyeti = dr["cinsiyeti"].ToString();
                ent.Ceptel = dr["cepTel"].ToString();
                ent.EPosta = dr["ePosta"].ToString();
                ent.KlinikID1 = int.Parse(dr["KlinikID"].ToString());
                ent.Teshis1 = dr["Teshis"].ToString();
                ent.DoktorNotu1 = dr["DoktorNotu"].ToString();
                ent.DoktorTC1 = dr["DoktorTC"].ToString();
                ent.KanTahlil1 = dr["KanTahlil"].ToString();
                ent.Rontgen1 = dr["Rontgen"].ToString();
                ent.DoktorTC1 = dr["DoktorTC"].ToString();

                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }


        //Veri tabanında kayıtlı olan hastaların bağlı olduğu kliniklere göre TblHasta tablosudan hasta sayısını getirir.
        public static int HastaSayisinaGoreKlinik(int klinik_id)
        {

            SqlCommand komut1 = new SqlCommand("Select count(distinct HastaTc) as Sayi from TblHasta where KlinikID=@KlinikID", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }

            komut1.Parameters.AddWithValue("@KlinikID", klinik_id);
            SqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read())
            {
                hastasayisiKlinik = Convert.ToInt32(dr["Sayi"].ToString());
                dr.Close();
                return hastasayisiKlinik;
            }
            else
            {
                return 0;
            }
        }

        //Veri tabanında kayıtlı olan hastaların bağlı olduğu doktorlara göre TblHasta tablosudan hasta sayısını getirir.
        public static int HastaSayisinaGoreDoktor(string doktor_TC)
        {

            SqlCommand komut1 = new SqlCommand("Select count(distinct HastaTc) as Sayi from TblHasta where DoktorTC=@DoktorTC", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }

            komut1.Parameters.AddWithValue("@DoktorTC", doktor_TC);
            SqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read())
            {
                hastasayisiKlinik = Convert.ToInt32(dr["Sayi"].ToString());
                dr.Close();
                return hastasayisiKlinik;
            }
            else
            {
                return 0;
            }
        }


    }
}

    


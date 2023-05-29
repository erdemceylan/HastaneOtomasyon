using System;
using EntityLayer;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicLayer
{
    public class LogicHasta
    {
        //Hastaları listeler
        public static List<EntityHasta> LLHastaLİstesi()
        {
            return DALHasta.HastaListesi();
        }

        //Hastaları Vt'ye ekleme
        //Kullanıcıdan girilen değerlerin dolu olup olmadığını kontrol eder.
        public static int LLHastaEkle(EntityHasta h)
        {
            //ekleme işlemi için gerekli olan kodalr
            if (h.HastaAdi!="" && h.HastaSoyadi !="" )
            {
                return DALHasta.HastaEkle(h);
            }
            else
            {
                return -1;

            }
        }
        public static bool LLHastaSil(string hasta)
        {
            return DALHasta.HastaSil(hasta);
            
        }

        //Hasta bilgileri güncelleme işlemleri hasta adi 3'den büyük ve boş değilse güncelleme işlemi yapar
        public static bool LLHastaGuncelle(EntityHasta ent)
        {
            if(ent.HastaAdi.Length>=3 && ent.HastaAdi != "")
            {
                return DALHasta.HastaGuncelle(ent);
            }
            else
            {
                return false;
            }
        }
        //Doktora göre hasta listesi
        public static List<EntityHasta> IlgiliHastaListesi(string p)
        {
            return DALHasta.IlgiliHastaListesi(p);
        }

        public static int LLHastaSayisinaGoreDoktor(string doktor_TC)
        {
            return DALHasta.HastaSayisinaGoreDoktor(doktor_TC);
        }

        public static int LLHastaSayisinaGoreKlinik(int klinik_id)
        {
            return DALHasta.HastaSayisinaGoreKlinik(klinik_id);
        }
    }
}

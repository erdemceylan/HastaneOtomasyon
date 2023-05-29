using System;
using EntityLayer;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LogicLayer
{
    public class LogicKlinik
    {
        //Klinikleri Listeler
       public static List<EntityKlinik> LLEntityKlinik()
        {
            return DALKlinik.KlinikListesi();
        }

        //KlinikID' ye göre sıralar
        public static EntityKlinik LLKlinikIDListele(EntityKlinik p)
        {
            return DALKlinik.KlinikIDListele(p);
        }

        public static List<EntityKlinik> KlinikListesi()
        {
            return DALKlinik.KlinikListesi();
        }

        //TblKlinik tablosundan Klinik adlarını getirir.
        public static EntityKlinik IlgiliKlinikAdiGetir(int p)
        {
            return DALKlinik.IlgiliKlinikAdiGetir(p);
        }
        public static List<EntityDoktor> IlgiliBranchDoctorListele(int p)
        {
            return DALKlinik.IlgiliBranchDoctorListele(p);
        }
        //Grafikler için oluşturldu
        public static List<string> KlinikListesiGrafik()
        {
            return DALKlinik.KlinikListesiGrafik();
        }


       
 

        //Klinik Ekleme
        public static int LLKlinikEkle(EntityKlinik h)
        {
            //ekleme işlemi için gerekli olan kodalr
            if (h.KlinikAdi1 != "" )
            {
                return DALKlinik.KlinikEkle(h);
            }
            else
            {
                return -1;

            }
        }
        //Klinik Silme 
        public static bool LLKlinikSil(int klinik)
        {
            return DALKlinik.KlinikSil(klinik);

        }

        //Klinik Güncelleme
        public static bool LLKlinikGuncelle(EntityKlinik ent)
        {
            if (  ent.KlinikAdi1 != "")
            {
                return DALKlinik.KlinikGuncelle(ent);
            }
            else
            {
                return false;
            }
        }
    }
}

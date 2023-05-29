using System;
using EntityLayer;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicDoktor
    {

        //Doktorları listeler
        public static List<EntityDoktor> LLDoktorLİstesi()
        {
            return DALDoktor.DoktorListesi();
        }

        //doktor ekle
        public static int LLDoktorEkle(EntityDoktor d)
        {
            //ekleme işlemi için gerekli olan kodalr
            if (d.DoktorAdi1 != "" && d.DoktorTC1 != "")
            {
                return DALDoktor.DoktorEkle(d);
            }
            else
            {
                return -1;

            }
        }

        public static EntityDoktor LLDoktorIDListele(EntityDoktor p)
        {
            return DALDoktor.DoktorIDListele(p);
        }

        //Doktor Silme 
        public static bool LLDoktorSil(string doktor)
        {
            return DALDoktor.DoktorSil(doktor);
      
        }

        //Doktor Güncelleme
        //Kullanıcıdan girilen değerler tc ve ad kısmı boş değilse güncelleme işlemini gerçekleştirir
        public static bool LLDoktorGuncelle(EntityDoktor ent)
        {
            if ( ent.DoktorTC1!="" && ent.DoktorAdi1 != "")
            {
                return DALDoktor.DoktorGuncelle(ent);
            }
            else
            {
                return false;
            }
        }

        //Doktor Giriş Kontrolü
        public static int LLDoktorGiris(EntityDoktor es)
        {
            return DALDoktor.DoktorGiris(es);
        }

        //Doktor bilgileri tutma
        public static EntityDoktor LLDoktorBilgiTut(EntityDoktor p)
        {
            return DALDoktor.DoktorBilgiTut(p);
        }


        //İlgili doktor adlarını seçilen ıd ye göre getirir
        public static EntityDoktor IlgiliDoktorAdiGetir(int p)
        {
            return DALDoktor.IlgiliDoktorAdiGetir(p);
        }

        
    }
}

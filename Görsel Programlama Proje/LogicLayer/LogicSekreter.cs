using System;
using EntityLayer;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicSekreter
    {
        //Sekreter Listesi
        public static List<EntitySekreter> LLSekreterLİstesi()
        {
            return DALSekreter.SekreterListesi();
        }
        //Sekreter Ekleme
        public static int LLSekreterEkle(EntitySekreter s)
        {
            //ekleme işlemi için gerekli olan kodalr
            if (s.SekreterAdi1 != "" && s.SekreterSoyadi1 != "")
            {
                return DALSekreter.SekreterEkle(s);
            }
            else
            {
                return -1;

            }
        }
        //Sekreter güncelleme
        public static bool LLSekreterGuncelle(EntitySekreter ent)
        {
            if (ent.SekreterSifre1.Length >= 1 && ent.SekreterAdi1 != "")
            {
                return DALSekreter.SekreterGuncelle(ent);
            }
            else
            {
                return false;
            }
        }

        //Sekreter Silme
        public static bool LLSekreterSil(string sekreter)
        {
            return DALSekreter.SekreterSil(sekreter);
           
        }

        //Sekreter Giriş Kontrolü
        public static int LLSekreterGiris(EntitySekreter es)
        {
            return DALSekreter.SekreterGiris(es);
        }

        public static EntitySekreter LLSekreterBilgiTut(EntitySekreter p)
        {
            return DALSekreter.SekreterBilgiTut(p);
        }
    }
}

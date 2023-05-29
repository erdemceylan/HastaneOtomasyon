using System;
using EntityLayer;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LogicRandevu
    {
        //Randevu Ekleme
        public static int LLRandevuOlustur(EntityRandevu p)
        {
            return DALRandevu.RandevuOlustur(p);
        }
        //randevu listesi
        public static List<EntityRandevu> LLRandevuİstesi()
        {
            return DALRandevu.RandevuListesi();
        }
        //Randevu Silme
        public static bool LLRandevuSil(string randevu)
        {
            return DALRandevu.RandevuSil(randevu);

        }

        //Randevu güncelleme
        public static bool LLRandevuGuncelle(EntityRandevu ent)
        {
            if (ent.HastaTC1.Length >= 1 && ent.DoktorTC1 != "")
            {
                return DALRandevu.RandevuGuncelle(ent);
            }
            else
            {
                return false;
            }
        }

    }
}

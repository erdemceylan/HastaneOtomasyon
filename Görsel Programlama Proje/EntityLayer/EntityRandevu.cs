using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class EntityRandevu
    {
        private int RandevuID;
        private string HastaTC;
        private string DoktorTC;
        private int KlinikID;
        private DateTime date;
        private string HastaAdi;
        private string HastaSoyadi;
        private string eposta;

        public int RandevuID1 { get => RandevuID; set => RandevuID = value; }
        public string DoktorTC1 { get => DoktorTC; set => DoktorTC = value; }
        public int KlinikID1 { get => KlinikID; set => KlinikID = value; }
        public string HastaTC1 { get => HastaTC; set => HastaTC = value; }
        public DateTime Date { get => date; set => date = value; }
        public string HastaSoyadi1 { get => HastaSoyadi; set => HastaSoyadi = value; }
        public string HastaAdi1 { get => HastaAdi; set => HastaAdi = value; }
        public string Eposta { get => eposta; set => eposta = value; }
    }
}

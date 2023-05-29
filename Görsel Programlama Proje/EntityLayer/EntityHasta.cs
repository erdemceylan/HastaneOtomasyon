using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
    public class EntityHasta
    {
        private string hastaTc;
        
        private string hastaAdi;
        private string hastaSoyadi;
        private string dogumTarihi;
        private string cinsiyeti;
        private string ceptel;
        private string ePosta;
        private string Teshis;
        private string DoktorNotu;
        private string DoktorTC;
        private string KanTahlil;
        private string Rontgen;
        private int KlinikID;
        

        public string HastaTc { get => hastaTc; set => hastaTc = value; }
        public string HastaAdi { get => hastaAdi; set => hastaAdi = value; }
        public string HastaSoyadi { get => hastaSoyadi; set => hastaSoyadi = value; }
        public string DogumTarihi { get => dogumTarihi; set => dogumTarihi = value; }
        public string Cinsiyeti { get => cinsiyeti; set => cinsiyeti = value; }
        public string Ceptel { get => ceptel; set => ceptel = value; }
        public string EPosta { get => ePosta; set => ePosta = value; }
        
        public string Teshis1 { get => Teshis; set => Teshis = value; }
        public string DoktorNotu1 { get => DoktorNotu; set => DoktorNotu = value; }
        public string DoktorTC1 { get => DoktorTC; set => DoktorTC = value; }
        public string KanTahlil1 { get => KanTahlil; set => KanTahlil = value; }
        public string Rontgen1 { get => Rontgen; set => Rontgen = value; }
        public int KlinikID1 { get => KlinikID; set => KlinikID = value; }
    }
}

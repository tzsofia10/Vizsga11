using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga11
{
    class eredmenyek
    {
        public string Nev { get; set; }
        public double ItHalozatIrasbeli { get; set; }
        public double ProgramozasIrasbeli { get; set; }
        public double HalozatokAModul { get; set; }
        public double HalozatokBModul { get; set; }
        public double HalozatokCModul { get; set; }
        public double HalozatokDModul { get; set; }
        public double SzobeliAngol { get; set; }
        public double SzobeliIT { get; set; }

        public eredmenyek(string sor)
        {
            var s=sor.Split(';');
            Nev = s[0];
            ItHalozatIrasbeli=Convert.ToDouble(s[1]);
            ProgramozasIrasbeli = Convert.ToDouble(s[2]);
            HalozatokAModul = Convert.ToDouble(s[3]);
            HalozatokBModul = Convert.ToDouble(s[4]);   
            HalozatokCModul = Convert.ToDouble(s[5]);
            HalozatokDModul = Convert.ToDouble(s[6]);
            SzobeliAngol = Convert.ToDouble(s[7]);
            SzobeliIT = Convert.ToDouble(s[8]);
        }

        public double vegeredmeny(double szam)
        {
            return szam*100;
        }
        public string erdemjegy(double jegy)
        {
            jegy = jegy * 100;
            string szoveg = string.Empty;
            if (jegy >= 81)
            {
                szoveg = "jeles";
            }
            else if (jegy >= 71 && jegy <= 80)
            {
                szoveg = "jó";
            }
            else if (jegy >= 61 && jegy <= 70)
            {
                szoveg = "közepes";
            }
            else if (jegy >= 51 && jegy <= 60)
            {
                szoveg = "elégséges";
            }
            else
            {
                szoveg = "elégtelen";
            }


            return szoveg;
        }
        public double LegjobbEredmeny()
        {
            return new List<double>
        {
            ItHalozatIrasbeli,
            ProgramozasIrasbeli,
            HalozatokAModul,
            HalozatokBModul,
            HalozatokCModul,
            HalozatokDModul,
            SzobeliAngol,
            SzobeliIT
        }.Max()*100;
        }
        public double LeggyengebbEredmeny()
        {
            return new List<double>
        {
            ItHalozatIrasbeli,
            ProgramozasIrasbeli,
            HalozatokAModul,
            HalozatokBModul,
            HalozatokCModul,
            HalozatokDModul,
            SzobeliAngol,
            SzobeliIT
        }.Min()*100;
        }
        public bool VizsgaSikeres()
        {
            return ItHalozatIrasbeli > 0.50 &&
                   ProgramozasIrasbeli > 0.50 &&
                   HalozatokAModul > 0.50 &&
                   HalozatokBModul > 0.50 &&
                   HalozatokCModul > 0.50 &&
                   HalozatokDModul > 0.50 &&
                   SzobeliAngol > 0.50 &&
                   SzobeliIT > 0.50;
        }
    }
}

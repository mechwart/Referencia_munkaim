using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Feladat: https://progcont.hu/progcont/100244/?pid=201196
namespace _201196_Repülőterek
{
    class Repuloter
    {
        public String Név { get; set; }
        public String Város { get; set; }
        public int KifutopalyakSzama { get; set; }
        public int ÁtszállásHossz { get; set; }

        public Repuloter(string név, string város, int kifutopalyakSzama, int átszállásHossz)
        {
            Név = név;
            Város = város;
            KifutopalyakSzama = kifutopalyakSzama;
            ÁtszállásHossz = átszállásHossz;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String sor;
            String[] token;
            List<Repuloter> repuloterek = new List<Repuloter>();
            int n = int.Parse(Console.ReadLine());
            
            for(int i=0; i<n; i++)
            {
                token = (sor = Console.ReadLine()).Split(';');
                repuloterek.Add(new Repuloter(token[0], token[1], int.Parse(token[2]), int.Parse(token[3])));
            }

            repuloterek.Sort((x, y) =>
            {
                int res = y.KifutopalyakSzama - x.KifutopalyakSzama;
                if (res != 0) return res;
                res = y.ÁtszállásHossz - x.ÁtszállásHossz;
                if (res != 0) return res;
                return x.Név.CompareTo(y.Név);
            });

            foreach(Repuloter r in repuloterek)
            {
                Console.WriteLine(r.Név+" ("+r.Város+"): "+r.ÁtszállásHossz);
            }

            
        }
    }
}

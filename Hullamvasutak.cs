using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Feladat: https://progcont.hu/progcont/100243/?pid=201192

namespace _201192_Hullámvasutak
{
    class Hullamvasut
    {
        public string Név { get; set; }
        public string Világ { get; set; }
        public int Magasság { get; set; }
        public int Idő { get; set; }

        public Hullamvasut(string név, string világ, int magasság, int idő)
        {
            Név = név;
            Világ = világ;
            Magasság = magasság;
            Idő = idő;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String sor;
            String[] token;
            List<Hullamvasut> vasutak = new List<Hullamvasut>();
            int N = int.Parse(Console.ReadLine());

            for(int i=0; i<N; i++)
            {
                sor = Console.ReadLine();
                token = sor.Split(';');
                vasutak.Add(new Hullamvasut(token[0], token[1], int.Parse(token[2]), int.Parse(token[3])));
            }

            vasutak.Sort((x, y) => {
                int res = x.Idő - y.Idő;
                if (res != 0) return res;
                res = y.Magasság - x.Magasság;
                if (res != 0) return res;
                return x.Név.CompareTo(y.Név);
            });


            foreach(Hullamvasut v in vasutak)
            {
                Console.WriteLine(v.Név + " (" + v.Világ + "): " + v.Idő);
            }
            

        }
    }
}

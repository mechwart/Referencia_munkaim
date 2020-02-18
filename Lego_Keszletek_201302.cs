using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Feladat: https://progcont.hu/progcont/100282/?pid=201302

namespace _201302_Lego_készletek
{
    class Lego
    {
        public int Kód { get; set; }
        public String Név { get; set; }
        public String Téma { get; set; }
        public int Elemszám { get; set; }

        public Lego(int kód, string név, string téma, int elemszám)
        {
            Kód = kód;
            Név = név;
            Téma = téma;
            Elemszám = elemszám;
        }
    }

    class Lego_Keszletek_201302
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
      
            String sor;
            String[] token;

            List<Lego> legok = new List<Lego>();

            for(int i=0; i<n; i++)
            {
                sor = Console.ReadLine();
                token = sor.Split(';');
                //Ahhoz, hogy így tudjunk listához adni konstruktor szükséges!
                legok.Add(new Lego(
                    int.Parse(token[0]),
                    token[1],
                    token[2],
                    int.Parse(token[3])
                ));
                
            }

            //Ez a fajta rendezés tömb esetében nem működik
            //1. Rendezés
            legok.Sort((x,y) => {
                if (y.Elemszám.CompareTo(x.Elemszám) != 0) return y.Elemszám.CompareTo(x.Elemszám); //elemszám csökkenő
                else if (x.Téma.CompareTo(y.Téma) != 0) return x.Téma.CompareTo(y.Téma); // ha elemszám egyenlő volt akkor téma név növekvő
                else if (x.Név.CompareTo(y.Név) != 0) return x.Név.CompareTo(y.Név); // ha téma név is egyenlő volt akkor név szerint növekvő
                else return x.Kód.CompareTo(y.Kód); // ha név is egyenlő volt akkor kód szerint növekvő

            });

            foreach(Lego elem in legok)
            {
                Console.WriteLine(elem.Név +" ("+elem.Kód+"): "+elem.Elemszám+" - "+elem.Téma);
            }

            //Egy sor kihagyás
            Console.WriteLine();

            //2. Rendezés
            legok.Sort((x, y) => {
                if (x.Téma.CompareTo(y.Téma) != 0) return x.Téma.CompareTo(y.Téma); //téma szerint növekvő
                else if (x.Név.CompareTo(y.Név) != 0) return x.Név.CompareTo(y.Név); //ha téma egyenlő akkor név szerint növekvő
                else return x.Kód.CompareTo(y.Kód); //ha név is egyenlő volt akkor kód szerint növekvő

            });

            foreach (Lego elem in legok)
            {
                Console.WriteLine(elem.Név + " (" + elem.Kód + "): " + elem.Elemszám + " - " + elem.Téma);
            }

            

        }
    }
}

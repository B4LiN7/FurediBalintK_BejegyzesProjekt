using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BejegyzesProjekt
{
    internal class Feladatok
    {
        Random rnd = new Random();
        public List<Bejegyzes> bejegyzesek1;
        public List<Bejegyzes> bejegyzesek2;

        public Feladatok()
        {
            this.bejegyzesek1 = new List<Bejegyzes>();
            this.bejegyzesek2 = new List<Bejegyzes>();

            Beolvas(true);
            LikeokOsztasa(20);
            Kiir(bejegyzesek1);
        }

        public void BejegyzesFelvetel()
        {
            /*do
            {
                Console.Write("Új bejegyzések száma: ");
            } while (!int.TryParse(Console.ReadLine(), out int szam) && szam > 0);*/

            int ujBejegy = 0;

            bool run = true;
            while (run)
            {
                Console.Write("Új bejegyzések száma: ");
                try
                {
                    ujBejegy = Convert.ToInt32(Console.ReadLine());
                    run = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hiba:\n{ex}");
                    throw;
                }
            }

            for (int i = 0; i < ujBejegy; i++)
            {
                bejegyzesek1.Add(new Bejegyzes("", ""));
            }
        }

        public void Beolvas(bool kiir)
        {
            using (StreamReader sr = new StreamReader("bejegyzesek.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(';');
                    bejegyzesek1.Add(new Bejegyzes(sor[0], sor[1]));
                }
            }         
            if (kiir)
            {
                Kiir(bejegyzesek1);
            }
        }

        public void Kiir(List<Bejegyzes> lista)
        {
                foreach (var item in lista)
                {
                    Console.WriteLine(item);
                }
        }

        public void LikeokOsztasa(int szorzo)
        {
            for (int i = 0; i < szorzo; i++)
            {
                for (int j = 0; j < bejegyzesek1.Count; j++)
                {
                    bejegyzesek1[rnd.Next(0, bejegyzesek1.Count)].Like();
                }
            }
        }
    }
}

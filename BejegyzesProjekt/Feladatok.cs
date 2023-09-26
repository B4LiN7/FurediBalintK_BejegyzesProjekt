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

            BejegyzesFelvetel();
            Beolvas(false);
            LikeokOsztasa(20);
            FelhaszSzoveg();
            Kiir(bejegyzesek1);
            Legnepszerubb();
            Console.WriteLine(Van35LikenalTobb());
            Console.WriteLine(Kevesebb15());
            Rendezes();
            Kiir(bejegyzesek1);
            FajlKiir();
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
                    if (ujBejegy > 0)
                    {
                        run = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hiba:\n{ex}");
                    throw;
                }
            }

            for (int i = 0; i < ujBejegy; i++)
            {
                bejegyzesek1.Add(new Bejegyzes());
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

        public void FelhaszSzoveg()
        {
            Console.Write("Adjon megy egy szöveget: ");
            string szoveg = Console.ReadLine();
            bejegyzesek1[1].Tartalom = szoveg;
        }

        public void Legnepszerubb()
        {
            int legtobbLike = int.MinValue;

            foreach (var item in bejegyzesek1)
            {
                if (item.Likeok > legtobbLike)
                {
                    legtobbLike = item.Likeok;
                }
            }

            Console.WriteLine($"A legnépszerübb bejegyzésnek ennyi likeja van: {legtobbLike}");
        }

        public bool Van35LikenalTobb()
        {
            int LegtobbLike = int.MinValue;
            int index = 0;
            do
            {
                if (bejegyzesek1[index].Likeok > LegtobbLike)
                {
                    LegtobbLike = bejegyzesek1[index].Likeok;
                }
                index++;
            } while (LegtobbLike <= 35 && index < bejegyzesek1.Count);

            if (LegtobbLike >= 35)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Kevesebb15()
        {
            int kevessebb = 0;
            foreach (var item in bejegyzesek1)
            {
                if (item.Likeok < 15)
                {
                    kevessebb++;
                }
            }
            return kevessebb;
        }

        public void Rendezes()
        {
            for (int i = 0; i < bejegyzesek1.Count; i++)
            {
                for (int j = 0; j < bejegyzesek1.Count; j++)
                {
                    if (bejegyzesek1[i].Likeok > bejegyzesek1[j].Likeok)
                    {
                        Bejegyzes bejegyzes = bejegyzesek1[i];
                        bejegyzesek1[i] = bejegyzesek1[j];
                        bejegyzesek1[j] = bejegyzes;
                    }
                }
            }
        }

        public void FajlKiir()
        {
            using (StreamWriter sw = new StreamWriter("bejegyzesek_rendezett.txt"))
            {
                for (int i = 0; i < bejegyzesek1.Count; i++)
                {
                    sw.WriteLine($"{bejegyzesek1[i].Szerzo};{bejegyzesek1[i].Tartalom}");
                }
            }       
        }
    }
}

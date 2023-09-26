using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    internal class Bejegyzes
    {
        private string szerzo;
        private string tartalom;
        private int likeok;
        private DateTime letrejott;
        private DateTime szerkesztve;

        public Bejegyzes(string szerzo, string tartalom)
        {
            this.szerzo = szerzo;
            this.tartalom = tartalom;
            this.likeok = 0;
            DateTime most = DateTime.Now;
            this.letrejott = most;
            this.szerkesztve = most;
        }

        public string Szerzo { get => szerzo; set => szerzo = value; }
        public string Tartalom { get => tartalom; set => tartalom = value; }
        public int Likeok { get => likeok; set => likeok = value; }
        public DateTime Letrejott { get => letrejott; set => letrejott = value; }
        public DateTime Szerkesztve { get => szerkesztve; set => szerkesztve = value; }

        public void Like()
        {
            likeok++;
        }

        public override string ToString()
        {
            string kimenet = "";

            kimenet += $"{szerzo,-30} | Like: {likeok,-10} | Létrehozva: {letrejott}\n";
            if (letrejott != szerkesztve)
            {
                kimenet += $"Szerkesztve: {szerkesztve}\n";
            }
            kimenet += tartalom + "\n";

            return kimenet;
        }
    }
}

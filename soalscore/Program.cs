using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soalscore
{
    class Klasemen
    {
        private Dictionary<string, int> poinKlub;
        private List<string> klub;

        public Klasemen(List<string> klub)
        {
            this.klub = klub;
            InisialisasiPoin();
        }

        public void catatPermainan(string klubKandang, string klubTandang, string skor)
        {
            int golKandang = int.Parse(skor.Split(':')[0]);
            int golTandang = int.Parse(skor.Split(':')[1]);

            if (golKandang > golTandang)
            {
                TambahPoin(klubKandang, 3);
            }
            else if (golKandang < golTandang)
            {
                TambahPoin(klubTandang, 3);
            }
            else
            {
                TambahPoin(klubKandang, 1);
                TambahPoin(klubTandang, 1);
            }
        }

        public Dictionary<string, int> cetakKlasemen()
        {
            return poinKlub.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public string ambilPeringkat(int nomorPeringkat)
        {
            var klasemen = cetakKlasemen();
            if (nomorPeringkat > 0 && nomorPeringkat <= klasemen.Count)
            {
                return klasemen.Keys.ElementAt(nomorPeringkat - 1);
            }
            else
            {
                return "Peringkat tidak valid";
            }
        }

        private void InisialisasiPoin()
        {
            poinKlub = new Dictionary<string, int>();
            foreach (var team in klub)
            {
                poinKlub.Add(team, 0);
            }
        }

        private void TambahPoin(string klub, int jumlah)
        {
            if (poinKlub.ContainsKey(klub))
            {
                poinKlub[klub] += jumlah;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Klasemen klasemen = new Klasemen(new List<string> { "Liverpool", "Chelsea", "Arsenal" });

            klasemen.catatPermainan("Arsenal", "Liverpool", "2:1");
            klasemen.catatPermainan("Arsenal", "Chelsea", "1:1");
            klasemen.catatPermainan("Chelsea", "Arsenal", "0:3");
            klasemen.catatPermainan("Chelsea", "Liverpool", "3:2");
            klasemen.catatPermainan("Liverpool", "Arsenal", "2:2");
            klasemen.catatPermainan("Liverpool", "Chelsea", "0:0");

            Dictionary<string, int> hasilKlasemen = klasemen.cetakKlasemen();
            Console.WriteLine("Hasil Klasemen:");
            foreach (var entry in hasilKlasemen)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} poin");
            }

            Console.WriteLine("Peringkat ke-2: " + klasemen.ambilPeringkat(2));
        }
    }
}

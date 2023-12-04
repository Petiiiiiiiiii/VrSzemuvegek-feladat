using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA231204
{
    class VrSzemuveg
    {
        public int Kod { get; set; }
        public string Felbontas { get; set; }
        public int Latomezo { get; set; }
        public double Suly { get; set; }
        public int Hz { get; set; }
        public string KapcsolatTipus { get; set; }
        public string ErzekelokString { get; set; }
        public List<string> Erzekelok { get; set; }

        public VrSzemuveg(string sor)
        {
            var atmeneti = sor.Split(';');
            this.Kod = Convert.ToInt32(atmeneti[0]);
            this.Felbontas = atmeneti[1];
            this.Latomezo = Convert.ToInt32(atmeneti[2]);
            this.Suly = Convert.ToDouble(atmeneti[3]);
            this.Hz = Convert.ToInt32(atmeneti[4]);
            this.KapcsolatTipus = atmeneti[5];
            this.ErzekelokString = atmeneti[6];
            this.Erzekelok = new List<string>();
            var erzekelok = atmeneti[6].Split(',');
            for (int i = 0; i < erzekelok.Length; i++) Erzekelok.Add(erzekelok[i]);

        }

        public override string ToString()
        {
            return $"Kód: {this.Kod}\nFelbontás: {this.Felbontas}\nLátómező: {this.Latomezo} fok\nSúlya: {this.Suly} g\nFrissítési ráta: {this.Hz} Hz\nKapcsolat típusa: {this.KapcsolatTipus}\nÉrzékelők: {this.ErzekelokString}\n"; 
        }

        public double LathatoPixelek() 
        {
            var szetszedve = this.Felbontas.Split('x');
            return Convert.ToDouble(szetszedve[0]) * Convert.ToDouble(szetszedve[1]);
        }

    }
}

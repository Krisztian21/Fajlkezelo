using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fuvar
{
    class FuvarInfo
    {
        public int Azonosíto { get; set; }
        public string IdoBelyegzo { get; set; }
        public int IdoTartam { get; set; }
        public double Tavolsag { get; set; }
        public double Viteldij { get; set; }
        public double Borravalo { get; set; }
        public string FizetesModja { get; set; }

        public FuvarInfo (int az, string ib, int it, double at, double vd, double bv, string fv)
        {
            this.Azonosíto = az;
            this.IdoBelyegzo = ib;
            this.IdoTartam = it;
            this.Tavolsag = at;
            this.Viteldij = vd;
            this.Borravalo = bv;
            this.FizetesModja = fv;
        }
        public FuvarInfo()
        {

        }
        public FuvarInfo(string ib)
        {
            this.IdoBelyegzo = ib;
        }
        public string KiirString()
        {
            return $"{this.Azonosíto};{this.IdoBelyegzo};{this.IdoTartam};{this.Tavolsag};{this.Borravalo};{this.Viteldij};{this.FizetesModja}";
        }
    }
}

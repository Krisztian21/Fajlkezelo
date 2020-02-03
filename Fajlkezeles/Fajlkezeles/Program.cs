using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fajlkezeles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> szovegLista = new List<string>();

            using (StreamReader sr = new StreamReader(@"C:\Users\pasztor.krisztian.j\Desktop\proba.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    string beiras = sr.ReadLine();
                    szovegLista.Add(beiras);
                }
            }

            for (int i = 0; i < szovegLista.Count ; i++)
            {
                Console.WriteLine(szovegLista[i]);
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Users\pasztor.krisztian.j\Desktop\proba.txt", true, Encoding.UTF8))
            {
                string beir = "Ez már a 3-dik sor.";
                sw.WriteLine(beir);
            }
                Console.ReadLine();

        }
    }
}

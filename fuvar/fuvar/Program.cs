using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            string elsosor = "";
            List<FuvarInfo> lista = new List<FuvarInfo>();

            using (StreamReader fuvar = new StreamReader("fuvar.csv", Encoding.UTF8))
            {
                elsosor = fuvar.ReadLine();

                while (!fuvar.EndOfStream)
                {
                    string sor = fuvar.ReadLine();
                    int id = Int32.Parse(sor.Split(';')[0]);
                    string ib = sor.Split(';')[1];
                    int it = Int32.Parse(sor.Split(';')[2]);
                    double mt = Double.Parse(sor.Split(';')[3]);
                    double bv = Double.Parse(sor.Split(';')[4]);
                    double vt = Double.Parse(sor.Split(';')[5]);
                    string fm = sor.Split(';')[6];
                    FuvarInfo fi = new FuvarInfo(id, ib, it, mt, bv, vt, fm);
                    lista.Add(fi);
                }
            }

            Console.WriteLine($"3. feladat: {lista.Count} fuvar");

            double osszViteldij = 0.0d;
            int fuvarszam = 0;
            foreach (var item in lista)
            {
                if (item.Azonosíto == 6185)
                {
                    fuvarszam++;
                    osszViteldij += item.Viteldij;
                }
            }
            Console.WriteLine($"4. feladat: {fuvarszam} fuvar alatt: {osszViteldij}$");

            Dictionary<string, int> mivelHanyszor = new Dictionary<string, int>();
            foreach(var item in lista)
            {
                string fizetesiMod = item.FizetesModja;
                int darabszam = 0;
                foreach(KeyValuePair<string, int> elem in mivelHanyszor)
                {
                    if(elem.Key==fizetesiMod)
                    {
                        darabszam = elem.Value;
                        mivelHanyszor.Remove(fizetesiMod);
                        break;
                    }
                }
                mivelHanyszor.Add(fizetesiMod, ++darabszam);
            }
            Console.WriteLine("5. feladat: ");
            foreach(KeyValuePair<string, int> item in mivelHanyszor)
            {
                Console.WriteLine($"\t{item.Key}: {item.Value} fuvar");
            }

            double osszFutotMerfold = 0.0d;
            foreach(var item in lista)
            {
                osszFutotMerfold += item.Tavolsag;
            }
            Console.WriteLine($"6. feladat: {osszFutotMerfold * 1.6:F2}km");

            FuvarInfo leghosszabb = new FuvarInfo();
            foreach(var item in lista)
            {
                if(item.IdoTartam>=leghosszabb.IdoTartam)
                {
                    leghosszabb = item;
                }
            }
            Console.WriteLine($"7. feladat: Leghosszabb fuvar: ");
            Console.WriteLine($"\t Fuvar Hossza: {leghosszabb.IdoTartam} másodperc");
            Console.WriteLine($"\t Taxi azonosítója: {leghosszabb.Azonosíto}");
            Console.WriteLine($"\t Megtett távolság: {leghosszabb.Tavolsag}km");
            Console.WriteLine($"\t Viteldíja: {leghosszabb.Viteldij}$");

            Console.WriteLine("8. Feladat: hibák.txt");
            List<FuvarInfo> nullasok = new List<FuvarInfo>();
            FuvarInfo fiNullas = new FuvarInfo("3");
            nullasok.Add(fiNullas);
            for(int i=0; i<lista.Count; i++)
            {
                if (lista[i].IdoTartam != 0 && lista[i].Viteldij != 0 && lista[i].Tavolsag != 0)
                {
                    for (int j = 0; j < nullasok.Count; j++)
                    {
                        if (String.Compare(lista[i].IdoBelyegzo,nullasok[j].IdoBelyegzo)<0)
                        {
                            nullasok.Insert(j, lista[i]);
                            break;
                        }
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter("hibák.txt", false, Encoding.UTF8))
            {
               
                sw.WriteLine(elsosor);
                foreach(var item in nullasok)
                {
                    sw.WriteLine(item.KiirString());
                }
            }
            Console.ReadKey();
        }
    }
}

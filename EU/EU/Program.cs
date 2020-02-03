using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EU
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> TagAllamok = new List<string[]>();
            using (StreamReader Eu = new StreamReader("EUcsatlakozas.txt", Encoding.UTF8))
            {
                while (!Eu.EndOfStream)
                {
                    string sor = Eu.ReadLine();
                    string[] tomb = sor.Split(';');
                    TagAllamok.Add(tomb);
                }
            }
            Console.WriteLine($"3. Feladat: Eu tagallamainak száma: {TagAllamok.Count}");
            //Console.ReadLine();//Enterrel jelenísd meg a kövi feladatot

            int db = 0;

            for (int i = 0; i < TagAllamok.Count; i++)
            {
                if(TagAllamok[i][1].Substring(0, 4)=="2007")
                {
                    db++;
                }
                
            }
            Console.WriteLine($"4. Feladat: 2007-ben {db} ország csatlakozott.");
            //Console.ReadLine();

            for (int i = 0; i < TagAllamok.Count; i++)
            {
                if (TagAllamok[i][0] == "Magyarország")
                {
                    Console.WriteLine($"5. Feladat: Magyarország csatlakozási dátuma: {TagAllamok[i][1]}");
                }
            }

            foreach(var item in TagAllamok)
            {
                if(item[1].Contains(".05."))
                {
                    Console.WriteLine($"6. Feladat: Májusban volt csatlakozás.");
                    break;
                }
            }

            string utolsoBelepo = "";
            DateTime alap = new DateTime(1900, 01, 01);
            for (int i = 0; i < TagAllamok.Count; i++)
            {
                int ev = Int32.Parse(TagAllamok[i][1].Substring(0, 4));
                int honap = Int32.Parse(TagAllamok[i][1].Substring(5, 2));
                int nap = Int32.Parse(TagAllamok[i][1].Substring(8));
                DateTime aktualis = new DateTime(ev, honap, nap);
                if(alap<aktualis)
                {
                    alap = aktualis;
                    utolsoBelepo = TagAllamok[i][0];
                }
            }
            Console.WriteLine($"7. Feladat: Legutoljára csatlakozott ország: {utolsoBelepo}");

            /*List<int[][]> evenketibelepok = new List<int[][]>();
            for(int i=0; i<TagAllamok.Count; i++)
            {
                for(int j=0; j<evenketibelepok[i].Length; j++)
                {
                    if(TagAllamok[i][1].Substring(0, 4)==evenketibelepok[][])
                    {

                    }
                }
            }*/
            Dictionary<int, int> evenketibelepok = new Dictionary<int, int>();
            for (int i = 0; i < TagAllamok.Count; i++)
            {
                int ev = Int32.Parse(TagAllamok[i][1].Substring(0, 4));
                foreach (var item in evenketibelepok)
                {
                    int darab = item.Value;
                    if(item.Key==ev)
                    {
                        db = item.Value;
                        evenketibelepok.Remove(ev);
                        break;
                    }
                }
                evenketibelepok.Add(ev, ++db);
            }

            using (StreamWriter sw = new StreamWriter("kiiratas.txt", false, Encoding.UTF8))
            {
                Console.WriteLine("8. Feladat: Statisztika");
                sw.WriteLine("8. Feladat: Statisztika");
                foreach (KeyValuePair<int, int> item in evenketibelepok)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value} orszag");
                    sw.WriteLine($"\t{item.Key} - {item.Value} orszag");
                }
            }
            Console.ReadLine();
        }
    }
}
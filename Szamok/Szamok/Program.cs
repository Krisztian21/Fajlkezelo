using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Szamok
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tomb = new int[30];
            int osszeg = 0;
            List<int> Paratlanok = new List<int>();
            List<int> Ketjegyü = new List<int>();
            using (StreamReader szam = new StreamReader("szamok30.txt", Encoding.UTF8))
            {
                for(int i=0; i<30; i++)
                {
                    tomb[i] = Int32.Parse(szam.ReadLine());
                    osszeg += tomb[i];
                }
            }
            Console.WriteLine($"A számok összege: {osszeg}");

            int db = 0;
            for (int i = 0; i < 30; i++)
            {
                if(tomb[i]<0)
                {
                    db++;
                }
                if(tomb[i]%2!=0)
                {
                    Paratlanok.Add(tomb[i]);
                }
            }
            Console.WriteLine($"Ennyi negatív szám van a txt-ben: {db}");
            foreach(var item in Paratlanok)
            {
                Console.Write($" {item} ");
            }
            Console.WriteLine("\n");
            for(int i = 0; i < 30; i++)
            {
                if(tomb[i]>=10 && tomb[i]<100)
                {
                    Ketjegyü.Add(tomb[i]);
                    Console.Write($" {tomb[i]} ");
                }
            }
            Console.WriteLine("\nKérek egy számot 50 - 100 között.");
            int eddig = Convert.ToInt32(Console.ReadLine());
            int szamlal = 0;
            string kiir = "";
            for (int i = 0; i < tomb.Length; i++)
            {
                szamlal += tomb[i];
                if(szamlal<eddig)
                {
                    kiir = $"({tomb[i]}) +";
                }
                else
                {
                    kiir = $"({tomb[i]}) >=({eddig})";
                    break;
                }
            }
            Console.WriteLine(kiir);
            Console.ReadLine();
        }
    }
}

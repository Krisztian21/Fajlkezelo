using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Doga1
{
    class Program
    {
        static void Main(string[] args)
        {
            string elso = "";
            string sor = "";
            int min = 100;
            int min_hely = 0;
            int db = 0;
            List<int> lista = new List<int>();
            
            using (StreamReader SW = new StreamReader("szamokfejlec.txt", Encoding.UTF8))
            {
                elso = SW.ReadLine();;
                sor = SW.ReadLine();
                while (!SW.EndOfStream)
                {
                    lista.Add(Int32.Parse(SW.ReadLine()));
                    //Console.WriteLine(SW.ReadLine());
                }
                
            }
            Console.WriteLine(lista.Count);
            for (int i = 1; i < lista.Count - 1; i++)
            {

                if (lista[i - 1] == lista[i])
                {
                    Console.WriteLine($"A számok között egymás után jött a {lista[i - 1]} és a  {lista[i]}");
                }
                if (lista[i] < min)
                {
                    min_hely = i;
                    min = lista[i];
                }
                if (lista[i] == Math.Abs(lista[i - 1]))
                {
                    Console.WriteLine($"{lista[i - 1]} && {lista[i]} ");
                }
                else
                {
                    Console.WriteLine("Nincs");
                }
            }
            Console.WriteLine($"A legkisseb szám a(z) {min} a {min_hely}-(dik) helyen.");
            Console.WriteLine(db);
            Console.ReadLine();
        }
    }
}

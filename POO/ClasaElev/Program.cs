using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasaElev
{
        class Program
        {
            public class Persoana
            {
                public Persoana(string n, string p, double mediaaritm)
                {
                    Nume = n;
                    Prenume = p;
                    Mediaaritmetica = mediaaritm;
                }
                public override string ToString()
                {
                    return Nume + " " + Prenume + " " + Mediaaritmetica.ToString();
                }

                public string Nume { get; }
                public string Prenume { get; }
                public double Mediaaritmetica { get; }

            }
            public class SortByName : IComparer<Persoana>
            {
                public int Compare(Persoana p1, Persoana p2)
                {
                    return string.Compare(p2.Nume, p1.Nume);

                }
            }

            public class SortByMediearitmetica : IComparer<Persoana>
            {
                public int Compare(Persoana p1, Persoana p2)
                {
                    if (p1.Mediaaritmetica > p2.Mediaaritmetica)
                        return -1;
                    if (p1.Mediaaritmetica < p2.Mediaaritmetica)
                        return 1;
                    return 0;
                }
            }
            public class Class
            {
                public static void print(List<Persoana> a)
                {
                    foreach (object o in a)
                        Console.WriteLine(o);
                }
                public static void Main()
                {
                    /* / Tonu / Patricia /    // 6 //      9 / 8 / 9 / 10 / 10 / 10 ---media aritmetica: 9.3
                       / Lupan / Cristian /  // 6 //       6 / 10 / 8 / 7 / 8 / 7 ---media aritmetica: 7.6
                       / Sadovoi / Maria /   // 6 //      10 / 8 / 10 / 9 / 7 / 10 ---media aritmetica: 9
                       / Moisei / Rut /      // 6 //      7 / 9 / 9 / 8 / 8 / 9 ---media aritmetica: 8.3
                       / Turcanu / Ion /     // 6 //      6 / 8 / 9 / 6 / 10 / 9 ---media aritmetica: 8 */
                    List<Persoana> pers = new List<Persoana>();
                    pers.Add(new Persoana("Tonu", "Patricia", 9.3));
                    pers.Add(new Persoana("Lupan", "Cristian", 7.6));
                    pers.Add(new Persoana("Sadovoi", "Maria", 9));
                    pers.Add(new Persoana("Moisei", "Rut", 8.3));
                    pers.Add(new Persoana("Turcanu", "Ion", 8));

                   pers.Sort(new SortByMediearitmetica());
                   Console.Write("\n\nSortarea descrescatoare in functie de media aritmetica:\n");
                   print(pers);

                    pers.Sort(new SortByName());
                    Console.Write("\n\nSortarea descrescatoare in functie de  nume si prenume:\n");
                    print(pers);
                   
                   
                }
            }
        }
    
}

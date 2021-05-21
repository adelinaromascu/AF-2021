using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasa_Stars
{
        class Clasa_Stars
        {
            public Clasa_Stars(int n)
            {
                this.n = n;
            }
            int n;
            public static void afisare(int n)
            {

            }
            ~Clasa_Stars()
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= i; j++)
                        Console.Write("*");
                    Console.WriteLine();
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Clasa_Stars s = new Clasa_Stars(10);
            }
        }
    }

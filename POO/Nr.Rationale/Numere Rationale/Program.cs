using System;

namespace NumereRationale
{
    class Program
    {
        static void Main(string[] args)
        {
            NumarRational fractie1 = new NumarRational(1, 3);
            NumarRational fractie2 = new NumarRational(2, 4);

            Console.WriteLine("Fractie1: " + fractie1);
            Console.WriteLine("Fractie2: " + fractie2);
            Console.WriteLine("Adunare: " + (fractie1 + fractie2));
            Console.WriteLine("Scadere: " + (fractie1 - fractie2));
            Console.WriteLine("Inmultire: " + (fractie1 * fractie2));
            Console.WriteLine("Impartire: " + (fractie1 / fractie2));

            Console.Write("Ridicarea la puterea 2-a : " + fractie1 + " = ");
            Console.WriteLine(NumarRational.ridicareLaPutere(fractie1, 2));
            Console.Write("Ridicarea la puterea 2-a: " + fractie2 + " = ");
            Console.WriteLine(NumarRational.ridicareLaPutere(fractie2, 2));

            Console.Write("Comparatia (<,>) : ");
            if (fractie1 < fractie2)
            {
                Console.WriteLine(fractie1 + " < " + fractie2);
            }
            else
            {
                Console.WriteLine(fractie1 + " > " + fractie2);
            }

            Console.Write("Comparatia (<=,=>) : ");
            if (fractie1 <= fractie2)
            {
                Console.WriteLine(fractie1 + " <= " + fractie2);
            }
            else
            {
                Console.WriteLine(fractie1 + " >= " + fractie2);
            }

            Console.Write("Comparatia (== , !=) : ");
            if (fractie1 == fractie2)
            {
                Console.WriteLine(fractie1 + " == " + fractie2);
            }
            else
            {
                Console.WriteLine(fractie1 + " != " + fractie2);
            }
            Console.WriteLine();
        }

        internal class NumarRational
        {
            private int numarator;
            private int numitor;

            public NumarRational()
            {

            }
            public NumarRational(int numarator)
            {
                this.Numarator = numarator;
            }
            public NumarRational(int numarator, int numitor)
            {
                this.Numarator = numarator;
                this.Numitor = numitor;
            }

            public int Numarator { get => numarator; set => numarator = value; }
            public int Numitor { get => numitor; set => numitor = value; }

            public static NumarRational operator +(NumarRational x, NumarRational y)
            {
                if (x.numitor == y.numitor)
                {
                    NumarRational suma = new NumarRational(x.numarator + y.numarator, x.numitor);
                    return suma;
                }
                else
                {
                    int factorComun = cmmmc(x.numitor, y.numitor);
                    int t1 = factorComun / x.numitor;
                    int t2 = factorComun / y.numitor;
                    int p1 = t1 * x.numarator;
                    int p2 = t2 * y.numarator;
                    NumarRational suma = new NumarRational(p1 + p2, factorComun);

                    return suma;
                }
            }

            public static NumarRational operator -(NumarRational x, NumarRational y)
            {
                if (x.numitor == y.numitor)
                {
                    NumarRational suma = new NumarRational(x.numarator - y.numarator, x.numitor);
                    return suma;
                }
                else
                {
                    int factorComun = cmmmc(x.numitor, y.numitor);
                    int t1 = factorComun / x.numitor;
                    int t2 = factorComun / y.numitor;
                    int p1 = t1 * x.numarator;
                    int p2 = t2 * y.numarator;
                    NumarRational suma = new NumarRational(p1 - p2, factorComun);

                    return suma;
                }
            }
            public static NumarRational operator *(NumarRational x, NumarRational y)
            {
                NumarRational produs = new NumarRational(x.numarator * y.numarator, x.numitor * y.numitor);

                return produs;
            }
         
            public static NumarRational operator /(NumarRational x, NumarRational y)
            {
                NumarRational p2 = new NumarRational(y.numitor, y.numarator);

                NumarRational rezultat = x * p2;

                return rezultat;

            }

            public static NumarRational ridicareLaPutere(NumarRational x, int n)
            {
                NumarRational rezultat = x;

                for (int i = 2; i <= n; i++)
                    rezultat = x * rezultat;



                return rezultat;
            }
            
            public static bool operator >(NumarRational x, NumarRational y)
            {
                return x.numarator * y.numitor > y.numarator * x.numitor;
            }

            public static bool operator <(NumarRational x, NumarRational y)
            {
                return x.numarator * y.numitor < y.numarator * x.numitor;
            }

            public static bool operator >=(NumarRational x, NumarRational y)
            {
                return (x > y) || (x == y);
            }

            public static bool operator <=(NumarRational x, NumarRational y)
            {
                return (x < y) || (x == y);
            }

            public static bool operator ==(NumarRational x, NumarRational y)
            {
                return (x.numarator == y.numarator) && (x.numitor == y.numitor);
            }

            public static bool operator !=(NumarRational x, NumarRational y)
            {
                return (x.numarator != y.numarator) && (x.numitor != y.numitor);
            }

            public static NumarRational simplificare(NumarRational x)
            {
                int divizor = cmmdc(x.numarator, x.numitor);
                NumarRational simplifacata = new NumarRational(x.numarator / divizor, x.numitor / divizor);

                return simplifacata;
            }


            public static int cmmdc(int a, int b)
            {
                while (a > b)
                {
                    if (a > b)

                        a = a - b;
                    else
                        b = b - a;

                }
                return (a * b) / a;
            }
            public static int cmmmc(int a, int b)
            {
                if (a % b == 0)
                    return a;

                else if (b % a == 0)
                    return b;

                else return a * b;

            }

            public override string ToString()
            {
                return this.Numarator + "/" + this.Numitor;
            }



        }


    }
}


using System;
using System.Globalization;

namespace NumereRationale
{
    class Program
    {
        static void Main(string[] args)
        {
            NumarComplex x = new NumarComplex(1, 3);
            NumarComplex y = new NumarComplex(2, 4);
            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);

            NumarComplex z = new NumarComplex();
            z = x + y;
            Console.WriteLine("x + y =  " + z);
            z = x - y;
            Console.WriteLine("x - y = " + z);
            z = x * y;
            Console.WriteLine("x * y = " + z);
            z = NumarComplex.ridicareLaPutere(x, 2);
            Console.WriteLine("x ^ 2 = " + z);

            Console.WriteLine("Forma trigonometrica a lui x este:  " + NumarComplex.formaTrigonometrica(x));
        }
    }

    internal class NumarComplex
    {
        private int parteIntreaga;
        private int parteImaginara;



        public NumarComplex()
        {

        }
        public NumarComplex(int parteIntreaga, int parteImaginara)
        {
            this.ParteIntreaga = parteIntreaga;
            this.ParteImaginara = parteImaginara;
        }

        public static NumarComplex operator +(NumarComplex x, NumarComplex y)
        {
            NumarComplex s = new NumarComplex(x.ParteIntreaga + y.ParteIntreaga, x.ParteImaginara + y.ParteImaginara);

            return s;
        }

        public static NumarComplex operator -(NumarComplex x, NumarComplex y)
        {
            NumarComplex d = new NumarComplex(x.ParteIntreaga - y.ParteIntreaga, x.ParteImaginara - y.ParteImaginara);

            return d;
        }

        public static NumarComplex operator *(NumarComplex x, NumarComplex y)
        {
            NumarComplex p = new NumarComplex((x.ParteIntreaga * y.ParteIntreaga) - (x.ParteImaginara * y.ParteImaginara), (x.ParteIntreaga * y.ParteImaginara) + (x.ParteImaginara * y.ParteIntreaga));

            return p;
        }

        public static NumarComplex ridicareLaPutere(NumarComplex x, int n)
        {
            NumarComplex ridicareLaPutere = new NumarComplex();
            for (int i = 0; i < n; i++)
                ridicareLaPutere = x * x;

            return ridicareLaPutere;
        }

        public int ParteIntreaga { get => parteIntreaga; set => parteIntreaga = value; }
        public int ParteImaginara { get => parteImaginara; set => parteImaginara = value; }

        public static String formaTrigonometrica(NumarComplex x)
        {
            double teta = Math.Atan(x.ParteImaginara / x.ParteIntreaga);
            double r = Math.Abs(Math.Sqrt(x.ParteIntreaga * x.ParteIntreaga + x.ParteImaginara * x.ParteImaginara));


            NumberFormatInfo setPrecision = new NumberFormatInfo();
            setPrecision.NumberDecimalDigits = 2;

            return r.ToString("N", setPrecision) + " * (" + "cos(" + teta.ToString("N", setPrecision) + ")" + " + i*" + "sin(" + teta.ToString("N", setPrecision) + "))";
        }


        public override string ToString()
        {
            return this.ParteIntreaga + " + " + this.ParteImaginara + "*i";
        }

    }
}

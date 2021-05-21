using System;

namespace ClasaTime
{
    class Program
    {

        static void Main(string[] args)
        {
            Time t1 = new Time(10, 30, 25, 75);
            Time t2 = new Time(47, 50, 40, 60);

            Time adunare = t1 + t2;
            Time scadere = t1 - t2;
            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine();
            Console.WriteLine("Rezultatul adunarii este " + adunare);
            Console.WriteLine("Rezultatul scaderii este " + scadere);
            Console.WriteLine();

            if (t1 > t2)
            {
                Console.WriteLine("Ora " + t1 + " este mai mare ca " + t2);
            }
            else
            {
                Console.WriteLine("Ora " + t2 + " este mai mare ca " + t1);
            }
        }
    }

    internal class Time
    {
        private String ora;
        private int ore;
        private int minute;
        private int secunde;
        private int sutime;

        public Time()
        { }
        public Time(String ora)
        {
            this.Ora = ora;
        }
        public Time(int ore, int minute)
        {
            this.Ore = ore;
            this.Minute = minute;
        }
        public Time(int ore, int minute, int secunde)
        {
            this.Ore = ore;
            this.Minute = minute;
            this.Secunde = secunde;
        }

        public Time(int ore, int minute, int secunde, int sutime)
        {
            this.Ore = ore;
            this.Minute = minute;
            this.Secunde = secunde;
            this.sutime = sutime;
        }

        public string Ora { get => ora; set => ora = value; }
        public int Ore { get => ore; set => ore = value; }
        public int Minute { get => minute; set => minute = value; }
        public int Secunde { get => secunde; set => secunde = value; }
        public int Sutime { get => sutime; set => sutime = value; }

        public override string ToString()
        {
            return this.ore + ":" + this.minute + ":" + this.secunde + ":" + this.sutime;
        }

        public static Time operator +(Time t1, Time t2)
        {
            Time t = new Time(0, 0, 0, 0);

            int k;

            t.Sutime = (t1.Sutime + t2.Sutime) % 100;

            k = (t1.Sutime + t2.Sutime) / 100;

            t.Secunde = (t1.Secunde + t2.Secunde + k) % 60;

            k = (t1.Secunde + t2.Secunde + k) / 60;

            t.Minute = (t1.Minute + t2.Minute + k) % 60;

            k = (t1.Minute + t2.Minute + k) / 60;

            t.Ore = t1.Ore + t2.Ore + k;

            return t;
        }

        public static Time operator -(Time t1, Time t2)
        {

            Time t = new Time(0, 0, 0, 0);

            int k;

            t.Sutime = Math.Abs((t1.Sutime - t2.Sutime) % 100);

            k = (t1.Sutime - t2.Sutime) / 100;

            t.Secunde = Math.Abs((t1.Secunde - t2.Secunde + k) % 60);

            k = (t1.Secunde - t2.Secunde + k) / 60;

            t.Minute = Math.Abs((t1.Minute - t2.Minute + k) % 60);

            k = (t1.Minute - t2.Minute + k) / 60;

            t.Ore = Math.Abs(t1.Ore - t2.Ore + k);

            return t;
        }


        public static bool operator <(Time t1, Time t2)
        {//&&
            if (t1.Ore < t2.Ore)
                return true;
            else
                if (t1.Ore == t2.Ore && t1.minute < t2.minute)
                return true;
            else
                if (t1.Ore == t2.Ore && t1.minute == t2.minute && t1.secunde < t2.secunde)
                return true;
            else
                if (t1.Ore == t2.Ore && t1.minute == t2.minute && t1.secunde == t2.secunde && t1.Sutime < t2.Sutime)
                return true;
            else
                return false;
        }

        public static bool operator >(Time t1, Time t2)
        {
            if (t1.Ore > t2.Ore)
                return true;
            else
              if (t1.Ore == t2.Ore && t1.minute > t2.minute)
                return true;
            else
              if (t1.Ore == t2.Ore && t1.minute == t2.minute && t1.secunde > t2.secunde)
                return true;
            else
              if (t1.Ore == t2.Ore && t1.minute == t2.minute && t1.secunde == t2.secunde && t1.Sutime > t2.Sutime)
                return true;
            else
                return false;
        }

        public static bool operator ==(Time t1, Time t2)
        {
            if (t1.Ore == t2.Ore && t1.minute == t2.minute && t1.secunde == t2.secunde && t1.Sutime == t2.Sutime)
                return true;
            else
                return false;
        }

        public static bool operator !=(Time t1, Time t2)
        {
            if (t1.Ore != t2.Ore && t1.minute != t2.minute && t1.secunde != t2.secunde && t1.Sutime != t2.Sutime)
                return true;
            else
                return false;
        }



    }
}
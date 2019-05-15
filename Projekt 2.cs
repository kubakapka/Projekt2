using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        const int NIter = 10;
        static long Licz;
        static void Main(string[] args)
        {

            
            Console.WriteLine("Liczba" + "\tCzas" + "\tInstrumentacja");
            
                //new BigInteger []{ 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };
            for (int i = 0; i < 7; i++)
            {
                Console.Write("Podaj liczbę: ");
                
                long liczba = long.Parse(Console.ReadLine());
                BigInteger Num = liczba;
                IsPrimeCzas(Num);
                IsPrimeInstrOut(Num);
                IsPrimeFasterCzas(Num);
                IsPrimeFasterInstrOut(Num);
            }
            Console.ReadKey();
        }
        static void IsPrimeCzas(BigInteger Num)
        {
            double elapsed;
            long elapsedTime = 0, MinTime = long.MaxValue, MaxTime = long.MinValue, czas;
            for (int n = 0; n < (NIter + 1 + 1); ++n)
            {
                
                long start = Stopwatch.GetTimestamp();
                IsPrime(Num);
                long end = Stopwatch.GetTimestamp();
                czas = end - start;
                elapsedTime += czas;

                if (czas < MinTime) MinTime = czas;
                if (czas > MaxTime) MaxTime = czas;
            }
            elapsedTime -= (MinTime + MaxTime);
            elapsed = elapsedTime * (1.0 / (NIter * Stopwatch.Frequency));
            Console.Write("\t" + elapsed.ToString("F10"));
            
        }
        static bool IsPrime(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
                for (BigInteger u = 3; u < Num / 2; u += 2)
                    if (Num % u == 0) return false;
            return true;
        }
        static bool IsPrimeInstr(BigInteger Num)
        {
            Licz = 1;
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
                for (BigInteger u = 3; u < Num / 2; u += 2)
                {
                    Licz++;

                    if (Num % u == 0)
                    {
                        

                        return false;
                    }
                }
            return true;
        }
        static void IsPrimeInstrOut(BigInteger Num)
        {
            
            bool result = IsPrimeInstr(Num);
            Console.WriteLine("\t" + Licz);

        }

        static bool IsPrimeFaster(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
                for (BigInteger u = 3; u * u <= Num; u += 2)

                    if (Num % u == 0) return false;

            return true;
        }
        static void IsPrimeFasterCzas(BigInteger Num)
        {
            double elapsed;
            long elapsedTime = 0, MinTime = long.MaxValue, MaxTime = long.MinValue, czas;
            for (int n = 0; n < (NIter + 1 + 1); ++n)
            {

                long start = Stopwatch.GetTimestamp();
                IsPrimeFaster(Num);
                long end = Stopwatch.GetTimestamp();
                czas = end - start;
                elapsedTime += czas;

                if (czas < MinTime) MinTime = czas;
                if (czas > MaxTime) MaxTime = czas;
            }
            elapsedTime -= (MinTime + MaxTime);
            elapsed = elapsedTime * (1.0 / (NIter * Stopwatch.Frequency));
            Console.Write("\t" + elapsed.ToString("F10"));

        }
        static bool IsPrimeFasterInstr(BigInteger Num)
        {
            Licz = 1;
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else
                for (BigInteger u = 3; u * u <= Num; u += 2)
                {
                    Licz++;
                    if (Num % u == 0) return false;
                }
            return true;
        }
        static void IsPrimeFasterInstrOut(BigInteger Num)
        {
            
            bool result = IsPrimeFasterInstr(Num);
            Console.WriteLine("\t" + Licz);

        }
    }
}

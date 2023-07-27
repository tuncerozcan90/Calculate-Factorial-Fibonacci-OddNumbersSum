using System;
using System.Numerics;

namespace Challenge3
{
    public class Program
    {
        public static void Main()
        {
            long input = GetPositiveNumber();
            GetInputKey(input);
        }

        public static void GetInputKey(long number)
        {
            DisplayScreen(number);
            ConsoleKeyInfo pressedKey = Console.ReadKey();

            switch (pressedKey.Key)
            {
                case ConsoleKey.F1:
                    BigInteger factorial = CalculateFactorial(number);
                    Console.WriteLine($"Faktöriyel: {factorial}");
                    break;

                case ConsoleKey.F2:
                    Console.WriteLine("Fibonacci serisi:");
                    for (int i = 0; i < number; i++)
                    {
                        Console.Write(CalculateFibonacci(i) + " ");
                    }
                    Console.WriteLine();
                    break;

                case ConsoleKey.F3:
                    long oddNumbersSum = CalculateOddNumbersSum(number);
                    Console.WriteLine($"Girilen Sayıya Kadar Tek Sayıların Toplamı: {oddNumbersSum}");
                    break;

                case ConsoleKey.F4:
                    number = GetPositiveNumber();
                    break;

                case ConsoleKey.E:
                    Console.WriteLine("Programdan çıkılıyor...");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen geçerli bir seçim yapın.");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            GetInputKey(number); // GetInputKey'i rekürsif olarak tekrar çağırıyoruz.
        }

        public static long GetPositiveNumber()
        {
            while (true)
            {
                Console.Write("Lütfen pozitif bir tamsayı girin: ");
                string input = Console.ReadLine();
                if (long.TryParse(input, out long num) && num > 0)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş. Lütfen bir pozitif sayı girin.");
                }
            }
        }

        public static void DisplayScreen(long number)
        {
            Console.WriteLine("\nGirilen sayı: " + number + "\n");
            Console.WriteLine("Aşağıdaki listeden işlem seçiniz\n" +
                              "F1 - Faktöriyel Hesaplama\n" +
                              "F2 - Fibonacci Serisi Hesaplama\n" +
                              "F3 - Girilen Sayıya Kadar Tek Sayıların Toplamı\n" +
                              "F4 - Yeni sayı gir\n" +
                              "e - Çıkış");
        }

        public static BigInteger CalculateFactorial(long n)
        {
            if (n == 0 || n == 1)
                return 1;

            BigInteger factorial = 1;
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        public static long CalculateFibonacci(long n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;

            long prev = 0;
            long current = 1;

            for (int i = 2; i <= n; i++)
            {
                long next = prev + current;
                prev = current;
                current = next;
            }

            return current;
        }

        public static long CalculateOddNumbersSum(long n)
        {
            if (n <= 0)
                return 0;
            else if (n % 2 == 1)
                return n + CalculateOddNumbersSum(n - 2);
            else
                return CalculateOddNumbersSum(n - 1);
        }

    }
}
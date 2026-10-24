using System;

namespace Zad1_PI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Task 1: approximating PI with the Leibniz series ===");
            Console.WriteLine("PI = 4 * (1 - 1/3 + 1/5 - 1/7 + 1/9 - ...)");
            Console.WriteLine();

            int iterations = ReadInt("Enter the number of iterations: ", 1, int.MaxValue);
            double pi = LeibnizPi(iterations);

            Console.WriteLine($"Leibniz PI: {pi:F10}");
            Console.WriteLine($"Math.PI:    {Math.PI:F10}");
            Console.WriteLine($"Error:      {Math.Abs(Math.PI - pi):F10}");
            Console.WriteLine();

            // The table shows how slowly the series converges:
            // 10x more iterations gives only about one more correct digit.
            Console.WriteLine($"{"Iterations",12} | {"Leibniz PI",14} | {"Error",14}");
            Console.WriteLine(new string('-', 46));
            for (int n = 10; n <= 10_000_000; n *= 10)
            {
                double approx = LeibnizPi(n);
                Console.WriteLine($"{n,12} | {approx,14:F10} | {Math.Abs(Math.PI - approx),14:F10}");
            }
        }

        // Leibniz series: PI/4 = 1 - 1/3 + 1/5 - 1/7 + ...
        // Term k is 1 / (2k + 1); even terms are added, odd terms are subtracted.
        static double LeibnizPi(int iterations)
        {
            double sum = 0;
            for (int k = 0; k < iterations; k++)
            {
                double term = 1.0 / (2.0 * k + 1);
                if (k % 2 == 0)
                    sum += term;
                else
                    sum -= term;
            }
            return 4 * sum;
        }

        static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Please enter a whole number from {min} to {max}.");
            }
        }
    }
}

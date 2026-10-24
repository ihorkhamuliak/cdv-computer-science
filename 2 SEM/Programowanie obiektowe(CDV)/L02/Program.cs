using System;

namespace L02
{

    enum CountryCode
    {
        USA = 1,
        France = 33,
        Spain = 34,
        Italy = 39,
        UnitedKingdom = 44,
        Poland = 48,
        Germany = 49,
        Ukraine = 380,
        Czechia = 420
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                if (!Console.IsOutputRedirected)
                    Console.Clear();

                Console.WriteLine("=== Lab 2: basic instructions ===");
                Console.WriteLine("1. PI by the Leibniz series");
                Console.WriteLine("2. Decimal -> binary");
                Console.WriteLine("3. Bit shift");
                Console.WriteLine("4. Bit rotation");
                Console.WriteLine("5. Enum: country dialing codes");
                Console.WriteLine("0. Exit");

                int choice = ReadInt("Choose a task: ", 0, 5);
                Console.WriteLine();

                switch (choice)
                {
                    case 1: Task1Pi(); break;
                    case 2: Task2Binary(); break;
                    case 3: Task3Shift(); break;
                    case 4: Task4Rotate(); break;
                    case 5: Task5Enum(); break;
                    case 0: return;
                }

                Console.WriteLine();
                Console.Write("Press Enter to return to the menu...");
                Console.ReadLine();
            }
        }

        //                                      Task 1 

        static void Task1Pi()
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

            Console.WriteLine($"{"Iterations",12} | {"Leibniz PI",14} | {"Error",14}");
            Console.WriteLine(new string('-', 46));
            for (int n = 10; n <= 10_000_000; n *= 10)
            {
                double approx = LeibnizPi(n);
                Console.WriteLine($"{n,12} | {approx,14:F10} | {Math.Abs(Math.PI - approx),14:F10}");
            }
        }

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

        //                                       Task 2 

        static void Task2Binary()
        {
            Console.WriteLine("=== Task 2: decimal -> binary ===");
            int number = ReadInt("Enter a non-negative whole number: ", 0, int.MaxValue);
            Console.WriteLine($"{number} in binary:                  {ToBinary(number)}");
            Console.WriteLine($"Check with Convert.ToString(n, 2): {Convert.ToString(number, 2)}");
        }

        static string ToBinary(int number, int width = 1)
        {
            string bits = "";
            do
            {
                bits = (number % 2) + bits;
                number /= 2;
            } while (number > 0);
            return bits.PadLeft(width, '0');
        }

        //                                   Task 3 

        static void Task3Shift()
        {
            Console.WriteLine("=== Task 3: bit shift (8 bits, byte) ===");
            byte value = (byte)ReadInt("Enter a number from 0 to 255: ", 0, 255);
            int positions = ReadInt("Enter how many positions to move (1-7): ", 1, 7);

            byte shiftedLeft = (byte)(value << positions);
            byte shiftedRight = (byte)(value >> positions);

            Console.WriteLine($"Number         {value,3} = {ToBinary(value, 8)}");
            Console.WriteLine($"Shift left  {positions}: {shiftedLeft,3} = {ToBinary(shiftedLeft, 8)}   (bits pushed out on the left are lost, zeros come in on the right)");
            Console.WriteLine($"Shift right {positions}: {shiftedRight,3} = {ToBinary(shiftedRight, 8)}   (bits pushed out on the right are lost, zeros come in on the left)");
        }

        //                                    Task 4 

        static void Task4Rotate()
        {
            Console.WriteLine("=== Task 4: bit rotation (8 bits, byte) ===");
            byte value = (byte)ReadInt("Enter a number from 0 to 255: ", 0, 255);
            int positions = ReadInt("Enter how many positions to rotate (1-7): ", 1, 7);

            byte rotatedLeft = RotateLeft(value, positions);
            byte rotatedRight = RotateRight(value, positions);

            Console.WriteLine($"Number          {value,3} = {ToBinary(value, 8)}");
            Console.WriteLine($"Rotate left  {positions}: {rotatedLeft,3} = {ToBinary(rotatedLeft, 8)}   (bits pushed out on the left come back on the right)");
            Console.WriteLine($"Rotate right {positions}: {rotatedRight,3} = {ToBinary(rotatedRight, 8)}   (bits pushed out on the right come back on the left)");
        }

        static byte RotateLeft(byte value, int positions)
        {
            return (byte)((value << positions) | (value >> (8 - positions)));
        }

        static byte RotateRight(byte value, int positions)
        {
            return (byte)((value >> positions) | (value << (8 - positions)));
        }

        //                                     Task 5 

        static void Task5Enum()
        {
            Console.WriteLine("=== Task 5: enum test, country dialing codes ===");
            Console.WriteLine();

            Console.WriteLine("All countries in the enum:");
            foreach (CountryCode c in Enum.GetValues<CountryCode>())
            {
                Console.WriteLine($"  {c,-14} +{(int)c}");
            }
            Console.WriteLine();

            CountryCode unknown = (CountryCode)999;
            Console.WriteLine($"(CountryCode)999 gives: {unknown}   <- just a number, no name");
            Console.WriteLine($"Enum.IsDefined for 999: {Enum.IsDefined(unknown)}");
            Console.WriteLine();

            string number = ReadFullNumber(out CountryCode country);
            Console.WriteLine();
            Console.WriteLine($"Country:     {country}");
            Console.WriteLine($"Code:        +{(int)country}");
            Console.WriteLine($"Number:      {GroupDigits(number)}");
            Console.WriteLine($"Full number: +{(int)country} {GroupDigits(number)}");
        }

        static string ReadFullNumber(out CountryCode country)
        {
            while (true)
            {
                Console.Write("Enter the full phone number with the country code: ");
                string digits = (Console.ReadLine() ?? "").Replace("+", "").Replace(" ", "").Replace("-", "");

                bool onlyDigits = digits.Length > 0;
                foreach (char ch in digits)
                {
                    if (!char.IsDigit(ch))
                        onlyDigits = false;
                }

                if (!onlyDigits)
                {
                    Console.WriteLine("  Please enter digits only (+, spaces and dashes are allowed).");
                }
                else if (!TryFindCountry(digits, out country))
                {
                    Console.WriteLine("  The number does not start with any country code from the enum.");
                }
                else
                {
                    string number = digits.Substring(((int)country).ToString().Length);
                    if (number.Length >= 6 && number.Length <= 12)
                        return number;
                    Console.WriteLine("  After the country code there must be 6 to 12 digits.");
                }
            }
        }

        static bool TryFindCountry(string digits, out CountryCode country)
        {
            foreach (CountryCode c in Enum.GetValues<CountryCode>())
            {
                if (digits.StartsWith(((int)c).ToString()))
                {
                    country = c;
                    return true;
                }
            }
            country = default;
            return false;
        }

        static string GroupDigits(string digits)
        {
            string result = "";
            for (int i = 0; i < digits.Length; i++)
            {
                if (i > 0 && i % 3 == 0)
                    result += " ";
                result += digits[i];
            }
            return result;
        }

        //Shared 

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

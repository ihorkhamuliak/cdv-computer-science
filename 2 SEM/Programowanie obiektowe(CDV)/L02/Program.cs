using System;

namespace L02
{
    // Each country gets its dialing code as an explicit value
    // (without "= 48" the values would be 0, 1, 2, ... by default)
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
                // Clear does not work when the output goes to a file instead of a window
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

        // ===== Task 1 =====

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

        // ===== Task 2 =====

        static void Task2Binary()
        {
            // Our own conversion, Convert.ToString is used only as a check
            Console.WriteLine("=== Task 2: decimal -> binary ===");
            int number = ReadInt("Enter a non-negative whole number: ", 0, int.MaxValue);
            Console.WriteLine($"{number} in binary:                  {ToBinary(number)}");
            Console.WriteLine($"Check with Convert.ToString(n, 2): {Convert.ToString(number, 2)}");
        }

        // Repeated division by 2: each remainder is the next bit, from right to left.
        // width pads the result with zeros on the left, e.g. 5 -> 00000101 for width 8.
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

        // ===== Task 3 =====

        // Tasks 3 and 4 work on 8 bits (byte), so every bit is visible
        static void Task3Shift()
        {
            Console.WriteLine("=== Task 3: bit shift (8 bits, byte) ===");
            byte value = (byte)ReadInt("Enter a number from 0 to 255: ", 0, 255);
            int positions = ReadInt("Enter how many positions to move (1-7): ", 1, 7);

            // The result of << is an int, so (byte) cuts it back to 8 bits
            byte shiftedLeft = (byte)(value << positions);
            byte shiftedRight = (byte)(value >> positions);

            Console.WriteLine($"Number         {value,3} = {ToBinary(value, 8)}");
            Console.WriteLine($"Shift left  {positions}: {shiftedLeft,3} = {ToBinary(shiftedLeft, 8)}   (bits pushed out on the left are lost, zeros come in on the right)");
            Console.WriteLine($"Shift right {positions}: {shiftedRight,3} = {ToBinary(shiftedRight, 8)}   (bits pushed out on the right are lost, zeros come in on the left)");
        }

        // ===== Task 4 =====

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

        // Rotation = shift + put the lost bits back on the other side
        static byte RotateLeft(byte value, int positions)
        {
            return (byte)((value << positions) | (value >> (8 - positions)));
        }

        static byte RotateRight(byte value, int positions)
        {
            return (byte)((value >> positions) | (value << (8 - positions)));
        }

        // ===== Task 5 =====

        static void Task5Enum()
        {
            Console.WriteLine("=== Task 5: enum test, country dialing codes ===");
            Console.WriteLine();

            // 1. All enum values: name and number
            Console.WriteLine("All countries in the enum:");
            foreach (CountryCode c in Enum.GetValues<CountryCode>())
            {
                Console.WriteLine($"  {c,-14} +{(int)c}");
            }
            Console.WriteLine();

            // 2. A cast does not check anything: 999 is not in the enum, but the cast still works
            CountryCode unknown = (CountryCode)999;
            Console.WriteLine($"(CountryCode)999 gives: {unknown}   <- just a number, no name");
            Console.WriteLine($"Enum.IsDefined for 999: {Enum.IsDefined(unknown)}");
            Console.WriteLine();

            // 3. Country (by name or by code) + local number -> full international number
            CountryCode country = ReadCountry();
            string phone = ReadPhone();
            Console.WriteLine();
            Console.WriteLine($"Country:     {country} (+{(int)country})");
            Console.WriteLine($"Full number: +{(int)country} {GroupDigits(phone)}");
        }

        static CountryCode ReadCountry()
        {
            while (true)
            {
                Console.Write("Enter a country name or a dialing code: ");
                string input = (Console.ReadLine() ?? "").Trim();

                // number -> name: check with IsDefined before the cast
                if (int.TryParse(input, out int code))
                {
                    if (Enum.IsDefined(typeof(CountryCode), code))
                        return (CountryCode)code;
                }
                // name -> number: Enum.TryParse turns text into an enum value
                // (IsDefined also here: TryParse accepts "Poland,Spain" and ORs the values together)
                else if (Enum.TryParse(input, ignoreCase: true, out CountryCode country) && Enum.IsDefined(country))
                {
                    return country;
                }
                Console.WriteLine($"  \"{input}\" is not in the enum, try again.");
            }
        }

        // Spaces and dashes are allowed and removed; only 6-12 digits are accepted
        static string ReadPhone()
        {
            while (true)
            {
                Console.Write("Enter the phone number without the country code: ");
                string digits = (Console.ReadLine() ?? "").Replace(" ", "").Replace("-", "");

                bool onlyDigits = digits.Length > 0;
                foreach (char ch in digits)
                {
                    if (!char.IsDigit(ch))
                        onlyDigits = false;
                }

                if (onlyDigits && digits.Length >= 6 && digits.Length <= 12)
                    return digits;
                Console.WriteLine("  Please enter 6 to 12 digits.");
            }
        }

        // "123456789" -> "123 456 789"
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

        // ===== Shared =====

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

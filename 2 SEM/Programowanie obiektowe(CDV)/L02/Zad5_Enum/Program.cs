using System;

namespace Zad5_Enum
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
            Console.WriteLine("=== Task 5: enum test, country dialing codes ===");
            Console.WriteLine();

            // 1. All enum values: name and number
            Console.WriteLine("All countries in the enum:");
            foreach (CountryCode country in Enum.GetValues<CountryCode>())
            {
                Console.WriteLine($"  {country,-14} +{(int)country}");
            }
            Console.WriteLine();

            // 2. A cast does not check anything: 999 is not in the enum, but the cast still works
            CountryCode unknown = (CountryCode)999;
            Console.WriteLine($"(CountryCode)999 gives: {unknown}   <- just a number, no name");
            Console.WriteLine($"Enum.IsDefined for 999: {Enum.IsDefined(unknown)}");
            Console.WriteLine();

            // 3. Interactive lookup in both directions
            while (true)
            {
                Console.Write("Enter a country name or a dialing code (empty line to exit): ");
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (int.TryParse(input, out int code))
                    FindByCode(code);
                else
                    FindByName(input);
            }
        }

        // number -> name: check with IsDefined before the cast
        static void FindByCode(int code)
        {
            if (Enum.IsDefined(typeof(CountryCode), code))
                Console.WriteLine($"  +{code} is {(CountryCode)code}");
            else
                Console.WriteLine($"  +{code} is not in the enum");
        }

        // name -> number: Enum.TryParse turns text into an enum value
        // (IsDefined also here: TryParse accepts "Poland,Spain" and ORs the values together)
        static void FindByName(string name)
        {
            if (Enum.TryParse(name.Trim(), ignoreCase: true, out CountryCode country) && Enum.IsDefined(country))
                Console.WriteLine($"  {country} has the code +{(int)country}");
            else
                Console.WriteLine($"  \"{name}\" is not in the enum");
        }
    }
}

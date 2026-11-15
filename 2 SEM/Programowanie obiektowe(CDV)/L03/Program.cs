using System.Globalization;

namespace L03
{
    class Program
    {
        //      Task 2

        static void Main(string[] args)
        {
            Operation[] operations =
            {
                new Addition(),
                new Subtraction(),
                new Multiplication(),
                new Division(),
                new Power(),
                new Root(),
                new AbsoluteValue()
            };

            int expressionOption = operations.Length + 1;
            int quadraticOption = operations.Length + 2;

            while (true)
            {
                if (!Console.IsOutputRedirected)
                    Console.Clear();

                Console.WriteLine("=== Lab 3: calculator ===");
                for (int i = 0; i < operations.Length; i++)
                    Console.WriteLine($"{i + 1}. {operations[i].Name}");
                Console.WriteLine($"{expressionOption}. Whole expression, e.g. 3 + (3/5)*4");
                Console.WriteLine($"{quadraticOption}. Quadratic equation ax^2 + bx + c = 0");
                Console.WriteLine("0. Exit");

                int choice = ReadInt("Choose an option: ", 0, quadraticOption);
                Console.WriteLine();

                if (choice == 0)
                    return;

                do
                {
                    // Task 3: one error message instead of a crash, whatever went wrong
                    try
                    {
                        if (choice <= operations.Length)
                            RunOperation(operations[choice - 1]);
                        else if (choice == expressionOption)
                            RunExpression();
                        else
                            RunQuadratic();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    Console.WriteLine();
                }
                while (ReadInt("1 - calculate again, 0 - back to the main menu: ", 0, 1) == 1);
            }
        }

        //      Task 1

        static void RunOperation(Operation operation)
        {
            Console.WriteLine($"--- {operation.Name} ---");

            double[] values = new double[operation.Arguments.Length];
            for (int i = 0; i < values.Length; i++)
                values[i] = ReadNumber($"{operation.Arguments[i]} = ");

            Console.WriteLine($"Result: {Format(operation.Calculate(values))}");
        }

        //      Task 4

        static void RunExpression()
        {
            Console.WriteLine("--- Whole expression ---");
            Console.WriteLine("Allowed: numbers, + - * / ^ and brackets ( )");
            Console.Write("Expression: ");

            double result = new ExpressionParser().Evaluate(ReadLine());
            Console.WriteLine($"Result: {Format(result)}");
        }

        //      Task 5

        static void RunQuadratic()
        {
            Console.WriteLine("--- Quadratic equation ax^2 + bx + c = 0 ---");
            double a = ReadNumber("a = ");
            double b = ReadNumber("b = ");
            double c = ReadNumber("c = ");

            Console.WriteLine(new QuadraticEquation().Solve(a, b, c));
        }

        //      Task 3

        static double ReadNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string text = ReadLine().Trim().Replace(',', '.');

                if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out double value)
                    && !double.IsInfinity(value) && !double.IsNaN(value))
                    return value;

                Console.WriteLine("  Please enter a number, e.g. 12 or -3.5");
            }
        }

        static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(ReadLine(), out int value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"  Please enter a whole number from {min} to {max}.");
            }
        }

        static string ReadLine()
        {
            // null = end of input (Ctrl+Z), without this the input loops would never end
            string? line = Console.ReadLine();
            if (line == null)
                Environment.Exit(0);
            return line;
        }

        public static string Format(double value)
        {
            // 0.1 + 0.2 is stored as 0.30000000000000004, 15 digits show 0.3; "== 0" turns -0 into 0
            if (value == 0)
                value = 0;
            return value.ToString("G15", CultureInfo.InvariantCulture);
        }
    }
}

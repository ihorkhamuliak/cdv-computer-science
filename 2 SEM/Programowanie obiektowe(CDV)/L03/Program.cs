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
                    // Task 3
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
            string? line = Console.ReadLine();
            if (line == null)
                Environment.Exit(0);
            return line;
        }

        public static string Format(double value)
        {
            if (value == 0)
                value = 0;
            return value.ToString("G15", CultureInfo.InvariantCulture);
        }
    }

    //      Task 1

    abstract class Operation
    {
        public abstract string Name { get; }
        public abstract string[] Arguments { get; }

        public double Calculate(params double[] args)
        {
            double result = Compute(args);

            // Task 3
            if (double.IsInfinity(result) || double.IsNaN(result))
                throw new OverflowException("The result is out of range.");

            return result;
        }

        protected abstract double Compute(double[] args);
    }

    class Addition : Operation
    {
        public override string Name => "Addition";
        public override string[] Arguments => new[] { "a", "b" };

        protected override double Compute(double[] args)
        {
            return args[0] + args[1];
        }
    }

    class Subtraction : Operation
    {
        public override string Name => "Subtraction";
        public override string[] Arguments => new[] { "a", "b" };

        protected override double Compute(double[] args)
        {
            return args[0] - args[1];
        }
    }

    class Multiplication : Operation
    {
        public override string Name => "Multiplication";
        public override string[] Arguments => new[] { "a", "b" };

        protected override double Compute(double[] args)
        {
            return args[0] * args[1];
        }
    }

    class Division : Operation
    {
        public override string Name => "Division";
        public override string[] Arguments => new[] { "a", "b" };

        protected override double Compute(double[] args)
        {
            if (args[1] == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            return args[0] / args[1];
        }
    }

    class Power : Operation
    {
        public override string Name => "Power";
        public override string[] Arguments => new[] { "base", "exponent" };

        protected override double Compute(double[] args)
        {
            double baseValue = args[0];
            double exponent = args[1];

            if (baseValue == 0 && exponent < 0)
                throw new DivideByZeroException("0 cannot be raised to a negative power.");

            if (baseValue < 0 && exponent != Math.Floor(exponent))
                throw new ArgumentException("A negative number can only be raised to a whole power.");

            return Math.Pow(baseValue, exponent);
        }
    }

    class Root : Operation
    {
        public override string Name => "Root";
        public override string[] Arguments => new[] { "x", "degree n" };

        protected override double Compute(double[] args)
        {
            double x = args[0];
            double n = args[1];

            if (n < 2 || n != Math.Floor(n))
                throw new ArgumentException("The degree must be a whole number, 2 or more.");

            if (x < 0 && n % 2 == 0)
                throw new ArgumentException("An even root of a negative number is not a real number.");

            if (n == 2)
                return Math.Sqrt(x);

            if (x < 0)
                return -Math.Pow(-x, 1.0 / n);

            return Math.Pow(x, 1.0 / n);
        }
    }

    class AbsoluteValue : Operation
    {
        public override string Name => "Absolute value";
        public override string[] Arguments => new[] { "x" };

        protected override double Compute(double[] args)
        {
            return Math.Abs(args[0]);
        }
    }

    //      Task 4

    class ExpressionParser
    {
        private readonly Addition addition = new Addition();
        private readonly Subtraction subtraction = new Subtraction();
        private readonly Multiplication multiplication = new Multiplication();
        private readonly Division division = new Division();
        private readonly Power power = new Power();

        private string text = "";
        private int pos;

        public double Evaluate(string expression)
        {
            text = expression.Replace(" ", "").Replace(',', '.');
            pos = 0;

            if (text.Length == 0)
                throw new FormatException("The expression is empty.");

            // Task 3
            if (text.Length > 200)
                throw new FormatException("The expression is too long (max 200 characters).");

            double result = ParseSum();

            if (pos < text.Length)
                throw new FormatException($"Unexpected character '{text[pos]}'.");

            return result;
        }

        private double ParseSum()
        {
            double result = ParseProduct();

            while (Next('+') || Next('-'))
            {
                char sign = text[pos];
                pos++;
                double right = ParseProduct();

                if (sign == '+')
                    result = addition.Calculate(result, right);
                else
                    result = subtraction.Calculate(result, right);
            }

            return result;
        }

        private double ParseProduct()
        {
            double result = ParseUnary();

            while (Next('*') || Next('/'))
            {
                char sign = text[pos];
                pos++;
                double right = ParseUnary();

                if (sign == '*')
                    result = multiplication.Calculate(result, right);
                else
                    result = division.Calculate(result, right);
            }

            return result;
        }

        private double ParseUnary()
        {
            if (Next('-'))
            {
                pos++;
                return subtraction.Calculate(0, ParseUnary());
            }

            return ParsePower();
        }

        private double ParsePower()
        {
            double baseValue = ParseNumberOrBrackets();

            if (Next('^'))
            {
                pos++;
                return power.Calculate(baseValue, ParseUnary());
            }

            return baseValue;
        }

        private double ParseNumberOrBrackets()
        {
            if (Next('('))
            {
                pos++;
                double value = ParseSum();

                if (!Next(')'))
                    throw new FormatException("Missing closing bracket ')'.");

                pos++;
                return value;
            }

            int start = pos;
            while (pos < text.Length && (char.IsDigit(text[pos]) || text[pos] == '.'))
                pos++;

            if (start == pos)
            {
                if (pos == text.Length)
                    throw new FormatException("The expression ends too early.");
                throw new FormatException($"Unexpected character '{text[pos]}'.");
            }

            string number = text.Substring(start, pos - start);

            if (!double.TryParse(number, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double result))
                throw new FormatException($"'{number}' is not a valid number.");

            return result;
        }

        private bool Next(char c)
        {
            return pos < text.Length && text[pos] == c;
        }
    }

    //      Task 5

    class QuadraticEquation
    {
        private readonly Root root = new Root();

        public string Solve(double a, double b, double c)
        {
            if (a == 0)
            {
                if (b == 0)
                    return c == 0 ? "a = 0 and b = 0: every x is a solution."
                                  : "a = 0 and b = 0: there is no solution.";

                double x = Check(-c / b);
                return "a = 0, so it is a linear equation bx + c = 0.\n"
                     + $"x = {Program.Format(x)}";
            }

            double delta = Check(b * b - 4 * a * c);
            string result = $"delta = b^2 - 4ac = {Program.Format(delta)}\n";

            if (delta < 0)
                return result + "delta < 0: no real roots.";

            if (delta == 0)
            {
                double x0 = Check(-b / (2 * a));
                return result + $"delta = 0: one root x0 = {Program.Format(x0)}";
            }

            double sqrtDelta = root.Calculate(delta, 2);
            double x1 = Check((-b - sqrtDelta) / (2 * a));
            double x2 = Check((-b + sqrtDelta) / (2 * a));

            return result + $"delta > 0: two roots\n"
                          + $"x1 = {Program.Format(x1)}\n"
                          + $"x2 = {Program.Format(x2)}";
        }

        private static double Check(double value)
        {
            if (double.IsInfinity(value) || double.IsNaN(value))
                throw new OverflowException("The numbers are too large.");
            return value;
        }
    }
}

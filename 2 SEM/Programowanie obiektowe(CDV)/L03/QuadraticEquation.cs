namespace L03
{
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

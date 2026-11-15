namespace L03
{
    //      Task 1

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

            // Math.Pow returns NaN for a negative base, so an odd root of a negative x is -root(-x)
            if (x < 0)
                return -Math.Pow(-x, 1.0 / n);

            return Math.Pow(x, 1.0 / n);
        }
    }
}

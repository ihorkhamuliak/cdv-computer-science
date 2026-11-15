namespace L03
{
    //      Task 1

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
}

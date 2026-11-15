namespace L03
{
    //      Task 1

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
}

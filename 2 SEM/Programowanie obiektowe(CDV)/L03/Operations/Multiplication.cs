namespace L03
{
    //      Task 1

    class Multiplication : Operation
    {
        public override string Name => "Multiplication";
        public override string[] Arguments => new[] { "a", "b" };

        protected override double Compute(double[] args)
        {
            return args[0] * args[1];
        }
    }
}

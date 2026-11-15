namespace L03
{
    //      Task 1

    class AbsoluteValue : Operation
    {
        public override string Name => "Absolute value";
        public override string[] Arguments => new[] { "x" };

        protected override double Compute(double[] args)
        {
            return Math.Abs(args[0]);
        }
    }
}

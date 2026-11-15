namespace L03
{
    //      Task 1

    abstract class Operation
    {
        public abstract string Name { get; }
        public abstract string[] Arguments { get; }

        public double Calculate(params double[] args)
        {
            double result = Compute(args);

            // Task 3: double does not throw on overflow, it silently becomes Infinity or NaN
            if (double.IsInfinity(result) || double.IsNaN(result))
                throw new OverflowException("The result is out of range.");

            return result;
        }

        protected abstract double Compute(double[] args);
    }
}

using System.Globalization;

namespace L03
{
    //      Task 4

    // Priority from lowest to highest: + -   then   * /   then   unary -   then   ^   then   ( )
    // Each level is one method, and it calls the method of the next, stronger level.
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

            // Task 3: every bracket is one more method call, a very long input could overflow the stack
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

            // ParseUnary, not ParsePower: so that 2^-1 works and 2^3^2 = 2^9
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
}

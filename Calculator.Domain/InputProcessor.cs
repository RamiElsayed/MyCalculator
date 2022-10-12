using System;

namespace Calculator.Domain
{
    public class InputProcessor
    {
        public ParseResult<decimal> ParseNumber(string input)
        {
            decimal number = 0;
            var succeeded = decimal.TryParse(input, out number);
            return succeeded ? ParseResult.Success(number) : ParseResult.Failure<decimal>();
        }

        public ParseResult<Operator> ParseOperator(string op)
        {
            switch (op)
            {
                case "+":
                    return ParseResult.Success(Operator.Add);
                case "-":
                    return ParseResult.Success(Operator.Subtract);
                case "*":
                    return ParseResult.Success(Operator.Multiply);
                case "/":
                    return ParseResult.Success(Operator.Divide);
            }
            return ParseResult.Failure<Operator>();
        }

        public decimal Calculate(Numbers numbers, Operator op)
        {
            decimal total;
            var calculator = new Calculator();
            switch (op)
            {
                case Operator.Add:
                    total = calculator.Add(numbers);
                    break;
                case Operator.Subtract:
                    total = calculator.Subtract(numbers);
                    break;
                case Operator.Multiply:
                    total = calculator.Multiply(numbers);
                    break;
                case Operator.Divide:
                    total = calculator.Divide(numbers);
                    break;
                default:
                    throw new Exception("Operator Invalid");
            }
            return total;
        }
    }
}

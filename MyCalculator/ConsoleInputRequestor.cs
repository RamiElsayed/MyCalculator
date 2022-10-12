using Calculator.Domain;
using System;

namespace MyCalculator
{
    public class ConsoleInputRequestor
    {
        public decimal RequestNumber(InputProcessor processor, bool isSecondNumber, bool isDivide)
        {
            var number = Request(processor.ParseNumber, "Enter a number");

            if (isSecondNumber && number == 0 && isDivide)
            {
                Console.WriteLine("Cannot divide by zero");
                return RequestNumber(processor, isSecondNumber, isDivide);
            }

            return number;
        }

        public Operator RequestOperator(InputProcessor processor)
        {
            return Request(processor.ParseOperator, "Enter an operator");
        }

        private T Request<T>(Func<string, ParseResult<T>> parse, string message) where T : struct
        {
            var result = parse(Console.ReadLine());
            if (result.Succeeded)
            {
                return result.Value;
            }
            Console.WriteLine(message);
            return Request(parse, message);
        }
    }
}

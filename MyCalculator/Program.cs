using Calculator.Domain;
using System;

namespace MyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var requestor = new ConsoleInputRequestor();
            var processor = new InputProcessor();
            var firstNumber = requestor.RequestNumber(processor, false, false);
            var op = requestor.RequestOperator(processor);
            

            while (true)
            {
                var secondNumber = requestor.RequestNumber(processor, true, op == Operator.Divide);
                var numbers = new Numbers(firstNumber, secondNumber);
                var calculation = processor.Calculate(numbers, op);
                Console.WriteLine(calculation);
                firstNumber = calculation;
                op = requestor.RequestOperator(processor);
            }
        }
    }
}

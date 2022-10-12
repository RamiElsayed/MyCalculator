using System;

namespace Calculator.Domain
{
    public class Calculator
    {
    
        public decimal Add(Numbers numbers)
        {
            var total = numbers.FirstNumber + numbers.SecondNumber;
            return total;
        }
        public decimal Subtract(Numbers numbers)
        {
            var total = numbers.FirstNumber - numbers.SecondNumber;
            return total;
        }
        public decimal Multiply(Numbers numbers)
        {
            var total = numbers.FirstNumber * numbers.SecondNumber;
            return total;
        }
        public decimal Divide(Numbers numbers)
        {
            var total = numbers.FirstNumber / numbers.SecondNumber;
            return total;
        }
    }

}

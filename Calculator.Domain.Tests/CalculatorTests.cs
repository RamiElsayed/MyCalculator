using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Domain.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(20, 60, 80)]
        [InlineData(-20, 60, 40)]
        [InlineData(-20, -60, -80)]
        [InlineData(20, 0, 20)]
        [InlineData(0, 0, 0)]
        public void AddReturnsSum(decimal firstNumber, decimal secondNumber, decimal expected)
        {
            // Arrange
            var calculator = new Calculator();
            var numbers = new Numbers(firstNumber, secondNumber);

            // Act
            var actual = calculator.Add(numbers);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(100, 30, 70)]
        [InlineData(-20, 60, -80)]
        [InlineData(20, -60, 80)]
        [InlineData(20, 0, 20)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 20, -20)]
        [InlineData(0, -40, 40)]
        public void SubtractReturnsDifference(decimal firstNumber, decimal secondNumber, decimal expected)
        {
            // Arrange
            var calculator = new Calculator();
            var numbers = new Numbers(firstNumber, secondNumber);

            // Act
            var actual = calculator.Subtract(numbers);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(100, 30, 3000)]
        [InlineData(-20, 60, -1200)]
        [InlineData(20, -60, -1200)]
        [InlineData(20, 0, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(0, -40, 0)]
        [InlineData(-10, -40, 400)]
        public void MultiplyReturnsProduct(decimal firstNumber, decimal secondNumber, decimal expected)
        {
            // Arrange
            var calculator = new Calculator();
            var numbers = new Numbers(firstNumber, secondNumber);

            // Act
            var actual = calculator.Multiply(numbers);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 2.5, 4)]
        [InlineData(-20, 10, -2)]
        [InlineData(20, -2, -10)]
        [InlineData(0, -40, 0)]
        [InlineData(-4, -2, 2)]
        public void DivideReturnsQuotient(decimal firstNumber, decimal secondNumber, decimal expected)
        {
            // Arrange
            var calculator = new Calculator();
            var numbers = new Numbers(firstNumber, secondNumber);

            // Act
            var actual = calculator.Divide(numbers);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivideWithZeroAsSecondNumberThrows()
        {
            // Arrange
            var calculator = new Calculator();
            var numbers = new Numbers(100, 0);

            // Act
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(numbers));
        }
    }
}

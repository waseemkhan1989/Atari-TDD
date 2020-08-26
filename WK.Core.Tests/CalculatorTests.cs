using System.Reflection;
using NUnit.Framework;

namespace WK.Core.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }
        
        [Test]
        public void Should_Add_When_InputGiven()
        {
            var add = _calculator.Add(1,2);
            Assert.That(add, Is.EqualTo(3));
        }
        
    }
}
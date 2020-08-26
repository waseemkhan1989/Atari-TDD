using NUnit.Framework;
using UnityEngine;

namespace WK.Core.TestsUnity.Playmode
{
    [TestFixture]
    public class CalculatorTests
    {
        private CalculatorBehaviour _calculator;

        [SetUp]
        public void Setup()
        {
            var gameObject = new GameObject("");
            _calculator = gameObject.AddComponent<CalculatorBehaviour>();
        }
        
        [Test]
        public void Should_Add_When_InputGiven()
        {
            var add = _calculator.Add(1,2);
            Assert.That(add, Is.EqualTo(3));
        }
        
    }
}
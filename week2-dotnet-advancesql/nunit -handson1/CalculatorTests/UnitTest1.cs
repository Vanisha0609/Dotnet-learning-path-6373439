using NUnit.Framework;
using CalcLibrary;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _sut;

        [SetUp]
        public void Setup() => _sut = new Calculator();

        [Test]
        public void Add_With1And2_Returns3()
        {
            var result = _sut.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));
        }
    }
}


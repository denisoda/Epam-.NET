using System;
using Logic;
using NUnit.Framework;

namespace Logic.UnitTests.PolynomialTests
{
    [TestFixture]
    class PolynomialOperationTests
    {
        [Test]
        public void PolynomialOperationTest_Addition()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial1 = new Polynomial(coeficients, degrees);

            int[] degrees2 = new int[] { 3, 1, 0, 0 };
            double[] coeficients2 = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial2 = new Polynomial(coeficients2, degrees2);

            int[] expectedDegrees = new int[] { 3, 1, 0 };
            double[] expectedCoefficients = new double[] { 4, 14, -20 };
            Polynomial expected = new Polynomial(expectedCoefficients, expectedDegrees);

            Assert.AreEqual(expected, polynomial1 + polynomial2);
        }

        [Test]
        public void PolynomialOperationTest_Addition_ArgumentNullException()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial1 = new Polynomial(coeficients, degrees);

            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    Polynomial result = polynomial1 + null;
                });
        }

        [Test]
        public void PolynomialOperationTest_Subtract()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial1 = new Polynomial(coeficients, degrees);

            int[] degrees2 = new int[] { 3, 1, 0, 0 };
            double[] coeficients2 = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial2 = new Polynomial(coeficients2, degrees2);

            int[] expectedDegrees = new int[] { };
            double[] expectedCoefficients = new double[] { };
            Polynomial expected = new Polynomial(expectedCoefficients, expectedDegrees);

            Assert.AreEqual(expected, polynomial1 - polynomial2);
        }

        [Test]
        public void PolynomialOperationTest_Subtract_ArgumentNullException()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial1 = new Polynomial(coeficients, degrees);

            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    Polynomial result = polynomial1 - null;
                });
        }

        [Test]
        public void PolynomialOperationTest_Multiplication()
        {
            int[] degrees = new int[] { 3, 1, 0 };
            double[] coeficients = new double[] { 2, 7, -5};
            Polynomial polynomial1 = new Polynomial(coeficients, degrees);

            int[] degrees2 = new int[] { 2, 1};
            double[] coeficients2 = new double[] { -3, 1 };
            Polynomial polynomial2 = new Polynomial(coeficients2, degrees2);

            int[] expectedDegrees = new int[] { 5, 4, 3, 2, 2, 1};
            double[] expectedCoefficients = new double[] { -6, 2, -21, 7, 15, -5};
            Polynomial expected = new Polynomial(expectedCoefficients, expectedDegrees);

            Assert.AreEqual(expected, polynomial1 * polynomial2);
        }

        [Test]
        public void PolynomialOperationTest_Multiplication_ArgumentNullException()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial1 = new Polynomial(coeficients, degrees);

            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    Polynomial result = polynomial1 * null;
                });
        }
    }
}

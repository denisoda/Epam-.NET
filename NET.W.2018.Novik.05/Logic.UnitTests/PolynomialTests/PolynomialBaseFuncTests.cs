using System;
using System.Collections.Generic;
using Logic;
using NUnit.Framework;

namespace Logic.UnitTests.PolynomialTests
{
    [TestFixture]
    public class PolynomialBaseFuncTests
    {
        #region Create polynomial tests

        [Test]
        public void PolynomialTest_CreateByNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(null,new int[] { }));
        }

        [Test]
        public void PolynolialTest_CreateByZeroCoefficient_ArgumentException()
        {
            int[] degrees = new int[] { 1, 2 };
            double[] coeficients = new double[] { 0, 1 };

            Assert.Throws<ArgumentException>(
                () => new Polynomial(coeficients, degrees));
        }

        public void PolynomialTest_CreateByNotTheSameArray_ArgumentException()
        {
            int[] degrees = new int[] { 1, 2 };
            double[] coeficients = new double[] { 1 };

            Assert.Throws<ArgumentException>(
                () => new Polynomial(coeficients, degrees));
        }

        [Test]
        public void PolynomialTest_CreateByArrays()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2 ,7 ,-5 ,-5 };
            Polynomial polynomial = new Polynomial(coeficients, degrees);

            string expected = "(2x^3) + (7x^1) + (-5x^0) + (-5x^0)";

            Assert.AreEqual(expected, polynomial.ToString());
        }

        #endregion // create polynomial

        #region Override  the Object's methods

        [Test]
        public void PolynomialTest_ToString()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial = new Polynomial(coeficients, degrees);

            string expected = "(2x^3) + (7x^1) + (-5x^0) + (-5x^0)";

            Assert.AreEqual(expected, polynomial.ToString());           
        }

        [Test]
        public void PolynomialTest_Equals()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial1 = new Polynomial(coeficients, degrees);

            int[] degrees2 = new int[] { 3, 1, 0, 0 };
            double[] coeficients2 = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial2 = new Polynomial(coeficients, degrees);

            Assert.IsTrue(polynomial1.Equals(polynomial2));
        }

        [Test]
        public void PolynomialTest_GetHasCode()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial1 = new Polynomial(coeficients, degrees);

            int[] degrees2 = new int[] { 3, 1, 0, 0 };
            double[] coeficients2 = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial2 = new Polynomial(coeficients, degrees);

            Assert.AreEqual(polynomial1.GetHashCode(), polynomial2.GetHashCode());
        }

        #endregion // override Object's class methods

        [Test]
        public void PolynomialTest_GetDegreeOfPolynomial()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial = new Polynomial(coeficients, degrees);

            int expected = 3;

            Assert.AreEqual(expected, polynomial.Degree);
        }

        [Test]
        public void PolynomialTest_ToStandart()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial = new Polynomial(coeficients, degrees);

            int[] expectedDegrees = new int[] { 3, 1, 0 };
            double[] expectedCoeficients = new double[] { 2, 7, 10 };
            Polynomial expected = new Polynomial(coeficients, degrees);

            Assert.AreEqual(expected,polynomial);
        }

        [Test]
        public void PolynomialTest_ToStandart_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => Polynomial.ToStandart(null));
        }
    }
}

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
            Assert.Throws<ArgumentNullException>(() => new Polynomial(null));
        }

        [Test]
        public void PolynolialTest_CreateByZeroCoeficient_ArgumentException()
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
        public void PolynomialTest_CreateByMonomials()
        {
            List<Monomial> values = new List<Monomial>();
            values.Add(new Monomial(2, 3));
            values.Add(new Monomial(7, 1));
            values.Add(new Monomial(-5, 0));
            values.Add(new Monomial(-5, 0));

            Assert.Pass();
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
            List<Monomial> values = new List<Monomial>();
            values.Add(new Monomial(2, 3));
            values.Add(new Monomial(7, 1));
            values.Add(new Monomial(-5, 0));
            values.Add(new Monomial(-5, 0));
            Polynomial polynomial = new Polynomial(values);

            string expected = "(2x^3) + (7x^1) + (-5x^0) + (-5x^0)";

            Assert.AreEqual(expected, polynomial.ToString());           
        }

        [Test]
        public void PolynomialTest_Equals()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial1 = new Polynomial(coeficients, degrees);

            List<Monomial> values = new List<Monomial>();
            values.Add(new Monomial(2, 3));
            values.Add(new Monomial(7, 1));
            values.Add(new Monomial(-5, 0));
            values.Add(new Monomial(-5, 0));
            Polynomial polynomial2 = new Polynomial(values);

            Assert.IsTrue(polynomial1.Equals(polynomial2));
        }

        [Test]
        public void PolynomialTest_GetHasCode()
        {
            int[] degrees = new int[] { 3, 1, 0, 0 };
            double[] coeficients = new double[] { 2, 7, -5, -5 };
            Polynomial polynomial1 = new Polynomial(coeficients, degrees);

            List<Monomial> values = new List<Monomial>();
            values.Add(new Monomial(2, 3));
            values.Add(new Monomial(7, 1));
            values.Add(new Monomial(-5, 0));
            values.Add(new Monomial(-5, 0));
            Polynomial polynomial2 = new Polynomial(values);

            Assert.AreEqual(polynomial1.GetHashCode(), polynomial2.GetHashCode());
        }

        #endregion // override Object's class methods

        [Test]
        public void PolynomialTest_GetDegreeOfPolynomial()
        {
            List<Monomial> values = new List<Monomial>();
            values.Add(new Monomial(2, 3));
            values.Add(new Monomial(7, 1));
            values.Add(new Monomial(-5, 0));
            values.Add(new Monomial(-5, 0));
            Polynomial polynomial = new Polynomial(values);

            int expected = 3;

            Assert.AreEqual(expected, polynomial.GetsDegree);
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

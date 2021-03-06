﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    [TestFixture]
    public class PolynomialTests
    {                
        [TestCase(null)]
        public void Constructor_PassedNullReference_ThrowsArgumentNullException(double[] coeffs)
        {
            Assert.Throws<ArgumentNullException>(() => new Polynomial(coeffs));
        }

        [TestCase(new double[] { })]
        public void Constructor_PassedEmptyArray_ThrowsArgumentException(double[] coeffs)
        {
            Assert.Throws<ArgumentException>(() => new Polynomial(coeffs));
        }

        [TestCase(new double[] { 12, 53, 2 }, ExpectedResult = "12 + 53*x^1 + 2*x^2")]
        [TestCase(new double[] { 12, 9, -3, 4 }, ExpectedResult = "12 + 9*x^1 - 3*x^2 + 4*x^3")]
        public string ToString_PassedPolynom_ExpectedPositiveTest(double[] coeffs)
        {
            var polynom1 = new Polynomial(coeffs);
            return polynom1.ToString();
        }

        [TestCase(new double[] { 12, 53, 2 }, new double[] { 2, 212, 4 }, ExpectedResult = false)]
        [TestCase(new double[] { 12, 9, -3, 4, 123}, new double[] { 12, 9, -3, 4 }, ExpectedResult = false)]
        public bool GetHashCode_GenerateHashForPolynoms_ExpectedPositiveTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            return new Polynomial(firstCoeffs).GetHashCode() == new Polynomial(secondCoeffs).GetHashCode();
        }

        [TestCase(new double[] { 12, 53, 2 }, new double[] { 2, 212, 4 }, ExpectedResult = false)]
        [TestCase(new double[] { 12, 9, -3, 4 }, new double[] { 12, 9, -3, 4 }, ExpectedResult = true)]
        public bool Equals_PassedPolynom_ExpectedPositiveTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            var polynom1 = new Polynomial(firstCoeffs);
            var polynom2 = new Polynomial(secondCoeffs);
            return polynom1.Equals(polynom2);
        }
               
        [TestCase(new double[] { 12, 53, 2 }, new double[] { 2, 212, 4 }, ExpectedResult = false)]
        [TestCase(new double[] { 12, 9, -3, 4 }, new double[] { 12, 9, -3, 4 }, ExpectedResult = true)]
        public bool OperatorEqual_CompareTwoPolynoms_ExpectedPositiveTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            var polynom1 = new Polynomial(firstCoeffs);
            object polynom2 = new Polynomial(secondCoeffs);
            return new Polynomial(firstCoeffs) == new Polynomial(secondCoeffs);
        }

        [TestCase(new double[] { 12, 53, 2 }, new double[] { 2, 212, 4 }, ExpectedResult = true)]
        [TestCase(new double[] { 12, 9, -3, 4 }, new double[] { 12, 9, -3, 4 }, ExpectedResult = false)]
        public bool OperatorNotEqual_CompareTwoPolynoms_ExpectedPositiveTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            return new Polynomial(firstCoeffs) != new Polynomial(secondCoeffs);
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4 }, ExpectedResult = new double[] { 2, 4, 6, 4 })]
        [TestCase(new double[] { 2, 4, 5 }, new double[] { 12, 4 }, ExpectedResult = new double[] { 14, 8, 5 })]
        public double[] OperatorAdd_AddTwoPolynoms_ExpectedPositiveTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            return (new Polynomial(firstCoeffs) + new Polynomial(secondCoeffs)).Coefficients;
        }
        
        [TestCase(new double[] { 2, 4, 5 }, new double[] { 12, 4 }, ExpectedResult = new double[] { 14, 8, 5 })]
        public double[] OperatorAdd_AddTwoPolynoms_Throws(double[] firstCoeffs, double[] secondCoeffs)
        {
            return (new Polynomial(firstCoeffs) + new Polynomial(secondCoeffs)).Coefficients;
        }

        [TestCase(new double[] { 3, 5, 4, 4, 7 }, new double[] { 1, 2, 3, 4 }, ExpectedResult = new double[] { 2, 3, 1, 0, 7 })]
        [TestCase(new double[] { 2, 4, 5 }, new double[] { 9, 4, 2, 10 }, ExpectedResult = new double[] { -7, 0, 3, -10 })]
        public double[] OperatorSub_SubtractTwoPolynoms_ExpectedPositiveTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            return (new Polynomial(firstCoeffs) - new Polynomial(secondCoeffs)).Coefficients;
        }

        [TestCase(new double[] { 2, 1 }, new double[] { 7, 4 }, ExpectedResult = new double[] { 14, 15, 4 })]
        [TestCase(new double[] { 2, 0, 5 }, new double[] { 7, 4 }, ExpectedResult = new double[] { 14, 8, 35, 20 })]
        public double[] OperatorMul_MultiplyTwoPolynoms_ExpectedPositiveTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            return (new Polynomial(firstCoeffs) * new Polynomial(secondCoeffs)).Coefficients;
        }

        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4 }, ExpectedResult = new double[] { 2, 4, 6, 4 })]
        [TestCase(new double[] { 2, 4, 5 }, new double[] { 12, 4 }, ExpectedResult = new double[] { 14, 8, 5 })]
        public double[] Add_AddTwoPolynoms_ExpectedPositiveTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            return (Polynomial.Add(new Polynomial(firstCoeffs), new Polynomial(secondCoeffs))).Coefficients;
        }

        [Test]
        public void Add_PassedNullReference_ThrowsArgumentException()
        {
            Polynomial polynom1 = new Polynomial(new double[] { 1, 3, 53 });
            Polynomial polynom2 = null;
            Assert.Throws<ArgumentNullException>(() => Polynomial.Add(polynom1, polynom2));
        }

        [TestCase(new double[] { 3, 5, 4, 4, 7 }, new double[] { 1, 2, 3, 4 }, ExpectedResult = new double[] { 2, 3, 1, 0, 7 })]
        [TestCase(new double[] { 2, 4, 5 }, new double[] { 9, 4, 2, 10 }, ExpectedResult = new double[] { -7, 0, 3, -10 })]
        public double[] Subtract_SubtractTwoPolynoms_ExpectedPositiveTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            return (Polynomial.Subtract(new Polynomial(firstCoeffs), new Polynomial(secondCoeffs))).Coefficients;
        }

        [Test]
        public void Subtract_PassedNullReference_ThrowsArgumentException()
        {
            Polynomial polynom1 = null;
            Polynomial polynom2 = new Polynomial(new double[] { 1, 3, 53 });
            Assert.Throws<ArgumentNullException>(() => Polynomial.Subtract(polynom1, polynom2));
        }

        [TestCase(new double[] { 2, 1 }, new double[] { 7, 4 }, ExpectedResult = new double[] { 14, 15, 4 })]
        [TestCase(new double[] { 2, 0, 5 }, new double[] { 7, 4 }, ExpectedResult = new double[] { 14, 8, 35, 20 })]
        public double[] Multiply_MultiplyTwoPolynoms_ExpectedPositiveTest(double[] firstCoeffs, double[] secondCoeffs)
        {
            return Polynomial.Multiply(new Polynomial(firstCoeffs), new Polynomial(secondCoeffs)).Coefficients;
        }

        [Test]
        public void Multiply_PassedNullReference_ThrowsArgumentException()
        {
            Polynomial polynom1 = null;
            Polynomial polynom2 = null;
            Assert.Throws<ArgumentNullException>(() => Polynomial.Multiply(polynom1, polynom2));
        }
    }
}

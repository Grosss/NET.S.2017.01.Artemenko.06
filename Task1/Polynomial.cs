using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Polynomial
    {
        private readonly double[] coefficients;
        public double[] Coefficients
        {
            get
            {
                double[] polynomCoeffs = new double[coefficients.Length];
                Array.Copy(coefficients, polynomCoeffs, coefficients.Length);
                return polynomCoeffs;
            }
        }

        #region Constructors

        Polynomial(double firstCoeff)
        {
            this.coefficients = new double[] { firstCoeff };
        }

        Polynomial(double firstCoeff, double secondCoeff)
        {
            this.coefficients = new double[] { firstCoeff, secondCoeff };
        }

        Polynomial(double firstCoeff, double secondCoeff, double thirdCoeff)
        {
            this.coefficients = new double[] { firstCoeff, secondCoeff, thirdCoeff };
        }

        Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException();

            if (coefficients.Length == 0)
                throw new ArgumentException();

            this.coefficients = new double[coefficients.Length];
            Array.Copy(coefficients, this.coefficients, coefficients.Length);
        }

        #endregion

        #region Overrided Object methods

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append($"{coefficients[0]}");
            for (int i = 1; i < coefficients.Length - 1; i++)
            {
                if (coefficients[i] != 0)
                {                    
                    if (coefficients[i] < 0)
                        result.Append($" - {-coefficients[i]}*x^{i}");
                    else
                        result.Append($" + {coefficients[i]}*x^{i}");
                }
            }
            if (coefficients[coefficients.Length - 1] < 0)
                result.Append($" - {-coefficients[coefficients.Length - 1]}*x^{coefficients.Length - 1}");
            else
                result.Append($" + {coefficients[coefficients.Length - 1]}*x^{coefficients.Length - 1}");

            return result.ToString();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (var cf in coefficients)
                    hash = hash * 23 + cf.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            var item = obj as Polynomial;

            if (ReferenceEquals(item, null))
                return false;

            return Equals(item);
        }

        public bool Equals(Polynomial polynom)
        {
            if (ReferenceEquals(this, polynom))
                return true;

            if (coefficients.Length != polynom.coefficients.Length)
                return false;

            for (int i = 0; i < coefficients.Length ; i++)
            {
                if (coefficients[i] != polynom.coefficients[i])
                    return false;
            }
            return true;
        }

        #endregion

        #region Overloaded operators

        public static bool operator ==(Polynomial polynom1, Polynomial polynom2)
        {
            if (polynom1 == null && polynom2 == null)
                return true;

            if (polynom1 == null || polynom2 == null)
                return false;

            return polynom1.Equals(polynom2);
        }

        public static bool operator !=(Polynomial polynom1, Polynomial polynom2)
        {
            return !(polynom1 == polynom2);
        }

        public static Polynomial operator +(Polynomial polynom1, Polynomial polynom2)
        {
            if (polynom1 == null || polynom2 == null)
                throw new ArgumentNullException();

            double[] result;
            if (polynom1.coefficients.Length > polynom2.coefficients.Length)
            {
                result = new double[polynom1.coefficients.Length];
                Array.Copy(polynom1.coefficients, result, polynom1.coefficients.Length);
                for (int i = 0; i < polynom2.coefficients.Length; i++)
                {
                    result[i] += polynom2.coefficients[i];
                }
            }
            else
            {
                result = new double[polynom2.coefficients.Length];
                Array.Copy(polynom2.coefficients, result, polynom2.coefficients.Length);
                for (int i = 0; i < polynom1.coefficients.Length; i++)
                {
                    result[i] += polynom1.coefficients[i];
                }
                
            }
            return new Polynomial(result);
        }

        public static Polynomial operator -(Polynomial polynom1, Polynomial polynom2)
        {
            if (polynom1 == null || polynom2 == null)
                throw new ArgumentNullException();
            
            double[] result;
            if (polynom2.coefficients.Length > polynom1.coefficients.Length)
            {
                result = new double[polynom2.coefficients.Length];
                Array.Copy(polynom1.coefficients, result, polynom1.coefficients.Length);
                for (int i = 0; i < polynom2.coefficients.Length; i++)
                {
                    result[i] -= polynom2.coefficients[i];
                }
            }
            else
            {
                result = new double[polynom1.coefficients.Length];
                Array.Copy(polynom1.coefficients, result, polynom1.coefficients.Length);
                for (int i = 0; i < polynom2.coefficients.Length; i++)
                {
                    result[i] -= polynom2.coefficients[i];
                }

            }
            return new Polynomial(result);
        }

        public static Polynomial operator *(Polynomial polynom1, Polynomial polynom2)
        {
            if (polynom1 == null || polynom2 == null)
                throw new ArgumentNullException();

            double[] result = 
                new double[polynom1.coefficients.Length + polynom2.coefficients.Length - 1];

            for (int i = 0; i < polynom1.coefficients.Length; i++)
            {
                for (int j = 0; j < polynom2.coefficients.Length; j++)
                {
                    result[i + j] += polynom1.coefficients[i] * polynom2.coefficients[j];
                }
            }

            return new Polynomial(result);
        }

        #endregion

        public static Polynomial Add(Polynomial polynom1, Polynomial polynom2)
        {
            return polynom1 + polynom2;
        }

        public static Polynomial Subtract(Polynomial polynom1, Polynomial polynom2)
        {
            return polynom1 - polynom2;
        }

        public static Polynomial Multiply(Polynomial polynom1, Polynomial polynom2)
        {
            return polynom1 * polynom2;
        }
    }
}

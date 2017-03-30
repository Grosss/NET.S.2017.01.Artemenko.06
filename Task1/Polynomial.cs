using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class Polynomial : ICloneable
    {
        private readonly double[] coefficients;
        private readonly int degree;
        private static readonly double epsilon;
        public double[] Coefficients
        {
            get
            {
                double[] polynomCoeffs = new double[coefficients.Length];
                Array.Copy(coefficients, polynomCoeffs, coefficients.Length);
                return polynomCoeffs;
            }
        }
        public int Degree { get { return degree; } }
        #region Constructors
        
        static Polynomial()
        {
            epsilon = 0.0000001d;
        }

        public Polynomial(params double[] coeffs)
        {
            if (coeffs == null)
                throw new ArgumentNullException();

            if (coeffs.Length == 0)
                throw new ArgumentException();

            for (int i = 0; i < coeffs.Length; i++)
            {
                if (Math.Abs(coeffs[i]) < epsilon)
                {
                    coeffs[i] = 0.0;
                }
            }

            for (int i = coeffs.Length - 1; i > -1; i--)
            {
                if (coeffs[i] != 0.0)
                {
                    degree = i;
                    break;
                }
            }

            this.coefficients = new double[degree + 1];
            Array.Copy(coeffs, coefficients, degree + 1);
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
            if (ReferenceEquals(this, obj))
                return true;

            if (ReferenceEquals(null, obj))
                return false;

            if (this.GetType() != obj.GetType())
                return false;
            
            return Equals((Polynomial)obj);
        }

        public bool Equals(Polynomial polynom)
        {
            if (ReferenceEquals(this, polynom))
                return true;

            if (ReferenceEquals(null, polynom))
                return false;

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
        
        #region Interface Implementation

        object ICloneable.Clone()
        {
            return Clone();
        }

        public Polynomial Clone()
        {
            return new Polynomial(coefficients);
        }

        #endregion

        #region Overloaded operators

        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
                return true;

            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                return false;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !(lhs == rhs);
        }

        public static Polynomial operator -(Polynomial polynom)
        {
            double[] resCoeffs = new double[polynom.coefficients.Length];
            for (int i = 0; i < polynom.coefficients.Length; i++)
                resCoeffs[i] = -polynom.coefficients[i];
            Polynomial resPolynom = new Polynomial(resCoeffs);
            return resPolynom;
        }

        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                throw new ArgumentNullException();
            
            if (lhs.coefficients.Length < rhs.coefficients.Length)
            {
                Polynomial temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
            double[] result = new double[lhs.coefficients.Length];
            Array.Copy(lhs.coefficients, result, lhs.coefficients.Length);
            for (int i = 0; i < rhs.coefficients.Length; i++)
            {
                result[i] += rhs.coefficients[i];
            }
            return new Polynomial(result);
        }

        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {            
            return lhs + -rhs;
        }

        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            if (lhs == null || rhs == null)
                throw new ArgumentNullException();

            double[] result = 
                new double[lhs.coefficients.Length + rhs.coefficients.Length - 1];

            for (int i = 0; i < lhs.coefficients.Length; i++)
            {
                for (int j = 0; j < rhs.coefficients.Length; j++)
                {
                    result[i + j] += lhs.coefficients[i] * rhs.coefficients[j];
                }
            }

            return new Polynomial(result);
        }

        #endregion

        public static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            return lhs + rhs;
        }

        public static Polynomial Subtract(Polynomial lhs, Polynomial rhs)
        {
            return lhs - rhs;
        }

        public static Polynomial Multiply(Polynomial lhs, Polynomial rhs)
        {
            return lhs * rhs;
        }
    }
}

using System;

namespace Logic
{
    public class Monomial
    {
        public Monomial()
        {
        }

        public Monomial(double coefficient, int degree)
        {
            this.Coefficient = coefficient;
            this.Degree = degree;
        }

        public double Coefficient { get; set; }

        public int Degree { get; set; }
    }
}

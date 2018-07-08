using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTest01_B
{
    public class Fraction
    {
        private int _numerator;
        private int _denominator;
        public Fraction Prev { get; set; }
        public Fraction Next { get; set; }

        public int Numerator
        {
            get { return _numerator; }
            set { _numerator = value; }
        }

        public int Denominator
        {
            get { return _denominator; }
            set { _denominator = value; }
        }

        public Fraction(int numerator, int denominator, Fraction prev, Fraction next)
        {
            _numerator = numerator;
            _denominator = denominator;
            Prev = prev;
            Next = next;
        }
    }
}

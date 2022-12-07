using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implment this class.e
    /// TODO: In other words, you must provide a means for:
    
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public int Real {get;}

        public int Imaginary {get;}

        public double Modulus 
        {
            get => Math.Sqrt((double)(Real*Real + Imaginary * Imaginary));
        }

        public double Phase 
        {
            get => Math.Atan2(Imaginary, Real);
        }
        
        public Complex Complement() => new Complex(Real, -Imaginary);

        public Complex(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public Complex(int Real) : this(Real, 0) {}

        public Complex Plus(Complex c) => new Complex(Real + c.Real, Imaginary + c.Imaginary);
        
        public Complex Minus(Complex c) => new Complex(Real - c.Real, Imaginary - c.Imaginary);

        public override string ToString()
        {            
            if(Real == 0 && Imaginary == 0) return "0";
            else if(Real == 0) return ((Imaginary == 1) ? "i" : (Imaginary == -1 ? "-i" : Imaginary + "i"));
            else if (Imaginary == 0) return Real.ToString();
            else return $"{Real}{(Imaginary > 0 ? "+" : "")}{((Imaginary == 1) ? "i" : (Imaginary == -1 ? "-i" : Imaginary + "i"))}";
        }

        public override bool Equals(object obj)
        {
            Complex c = obj as Complex;

            if(c == null) return false;
            return Real.Equals(c.Real) && Imaginary.Equals(c.Imaginary);
        }
    }
}
//#define CONSTUCTORS_CHECK
//#define ARITHMETICAL_OPERATORS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if CONSTUCTORS_CHECK
			Fraction A = new Fraction();
			A.Print();

			Fraction B = new Fraction(5);
			B.Print();

			Fraction C = new Fraction(1, 2);
			C.Print();

			Fraction D = new Fraction(2, 3, 4);
			D.Print(); 
#endif

#if ARITHMETICAL_OPERATORS

			Fraction A = new Fraction(2, 3, 4);
			Fraction B = new Fraction(3, 4, 5);
			Fraction C = new Fraction(A * B);
			A.Print();
			B.Print();
			C.Print();

			(A / B).Print(); 
#endif
			Fraction A = new Fraction(2,3,4);
			Fraction B = new Fraction(1,1,3);
			Fraction C = new Fraction(4, 1, 4);
			Fraction D = new Fraction(2.75);
			Console.WriteLine(new Fraction(1, 2) == new Fraction(5, 11));
			Console.WriteLine(A * B);
			Console.WriteLine(-C);
			Console.WriteLine(A - B + C);
			Console.WriteLine(A + C + B);
			Console.WriteLine(D);
			Console.WriteLine(B++);
			Console.WriteLine(B--);
			Console.WriteLine(A<=D);
			Console.WriteLine(A<D);
			Console.WriteLine(A*C-B/D);
			Console.WriteLine(D--);
        }
	}
}

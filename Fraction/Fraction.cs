using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	internal class Fraction
	{
		public int Integer { get; set; }
		public int Numerator { get; set; }
		int denominator;
		public int Denominator
		{
			get => denominator;
			set
			{
				if (value == 0) value = 1;
				denominator = value;
			}
		}
		public Fraction()
		{
			denominator = 1;
			Console.WriteLine($"DefConstructor: {this.GetHashCode()}");
		}
		public Fraction(int integer)
		{
			Integer = integer;
			Denominator = 1;
			Console.WriteLine($"Constructor: {this.GetHashCode()}");
		}
		public Fraction(int numerator, int denominator)
		{
			Numerator = numerator;
			Denominator = denominator;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}
		public Fraction(int integer, int numerator, int denominator)
		{
			Integer = integer;
			Numerator = numerator;
			Denominator = denominator;
			Console.WriteLine($"Constructor:\t{this.GetHashCode()}");
		}
		public Fraction(Fraction other)
		{
			this.Integer = other.Integer;
			this.Numerator = other.Numerator;
			this.Denominator = other.Denominator;
			Console.WriteLine($"CopyConstructor:{this.GetHashCode()}");
		}
		~Fraction()
		{
			Console.WriteLine($"Destructor:\t{this.GetHashCode()}");
		}

		//			Arithmetic Operators
		public static Fraction operator *(Fraction left, Fraction right)
		{
			left = left.ToImproper();
			right = right.ToImproper();

			return new Fraction
				(
				left.Numerator * right.Numerator,
				left.Denominator * right.Denominator
				).ToProper();
		}
		public static Fraction operator /(Fraction left, Fraction right)
		{
			
			return left * right.Inverted();
		}
		public static Fraction operator +(Fraction left, Fraction right)
		{
			Fraction copy_Left = left.ToImproper();
			Fraction copy_Right = right.ToImproper();

			return new Fraction
			(
				copy_Left.Integer + copy_Right.Integer,
				copy_Left.Numerator * copy_Right.Denominator + copy_Right.Numerator * copy_Left.Denominator,
				copy_Left.Denominator * copy_Right.Denominator
			).ToProper();
		}
		public static Fraction operator -(Fraction obj)
		{
			Fraction copy_obj = obj.ToImproper();

			return new Fraction
			(
				-copy_obj.Numerator, copy_obj.Denominator 
			) .ToProper();
		}
		public static Fraction operator -(Fraction left, Fraction right)
		{

			//Fraction copy_left = left.ToImproper();
			//Fraction copy_right = right.ToImproper();
			//return new Fraction(copy_left.Numerator * copy_right.Denominator
			//					- copy_right.Numerator * copy_left.Denominator,
			//					copy_left.Denominator * copy_right.Denominator
			//					).ToProper();

			return left + - right;
		}
		public static Fraction operator ++(Fraction obj)
		{
			obj.Integer++;
			return obj;
		}
		public static Fraction operator --(Fraction obj)
		{
			obj.Integer--;
			return obj;
		}

			//		Comparison operator:
		public static bool operator ==(Fraction left, Fraction right)
		{
			return left.ToImproper().Numerator * right.ToImproper().Denominator 
					== right.ToImproper().Numerator * left.ToImproper().Denominator;
		}
		public static bool operator !=(Fraction left, Fraction right)
		{
			return !(left == right);
		}

		public static bool operator >(Fraction left, Fraction right)
		{
			left = left.ToImproper();
			right = right.ToImproper();
			
			return (left.Numerator * right.Denominator > right.Numerator * left.Denominator)?true:false;
		}

		public static bool operator <(Fraction left, Fraction right)
		{
			left = left.ToImproper();
			right = right.ToImproper();

			return (left.Numerator * right.Denominator < right.Numerator * left.Denominator) ? true : false;
		}
		public static bool operator >=(Fraction left, Fraction right)
		{
			left = left.ToImproper();
			right = right.ToImproper();

			return (left.Numerator * right.Denominator >= right.Numerator * left.Denominator) ? true : false;
		}

		public static bool operator <=(Fraction left, Fraction right)
		{
			left = left.ToImproper();
			right = right.ToImproper();

			return (left.Numerator * right.Denominator <= right.Numerator * left.Denominator) ? true : false;
		}

		//				Conversion operators:
		public static implicit operator Fraction(double num)
		{
			int integ = Math.Abs((int)num);  // извлекаем целую часть
			double absNum = Math.Abs(num);
			int lengthInteg = integ.ToString().Length;   // находим длину целой части
			string fractPart = absNum.ToString().Substring(lengthInteg+1); // убираем целую часть
			int numer = int.Parse(fractPart);
			int denom = (int)Math.Pow(10, fractPart.Length);

			return new Fraction((num > 0? integ:-integ), numer, denom);
		}

		//							Methods:
		// чтобы в консоль выводился результат, необходимо переопределить метод ToString();
		public override string ToString()
		{
			if (Integer != 0)
			{	
				return  (Numerator != 0? $"{Integer}({Numerator}/{Denominator})":$"{Integer}");
			}
			return $"{Numerator}/{Denominator}";
		}
		public Fraction ToProper()
		{
			Fraction proper = new Fraction();
			//proper.Integer = this.Integer; 
			proper.Integer += Numerator / Denominator;
			proper.Numerator = Numerator % Denominator;
			proper.Denominator = Denominator;
			if (proper.Numerator < 0 && proper.Integer!=0) { proper.Numerator *= -1; }
			return proper.GreatComDiv();
		}
		public Fraction ToImproper()
		{
			return new Fraction(Numerator + Integer * Denominator, Denominator);
		}
		public Fraction Inverted()
		{
			Fraction inverted = ToImproper();
			//Fraction inverted = new Fraction(this);
			//inverted.ToImproper();
			//https://stackoverflow.com/questions/804706/swap-two-variables-without-using-a-temporary-variable
			(inverted.Numerator, inverted.Denominator) = (inverted.Denominator, inverted.Numerator);
			return inverted.ToProper();
		}
		public static int GreatComDiv(int a, int b) // наибольший общий делитель
		{
			// Алгоритм Евклида для нахождения НОД
			while (b != 0)
			{
				int temp = b;
				b = a % b;
				a = temp;
			}
			return a;
		}
		public Fraction GreatComDiv()
		{
			//Fraction obj = new Fraction();
			int gcd = GreatComDiv(Numerator, Denominator);
			return new Fraction(Integer,
								Numerator / gcd,
								Denominator / gcd
								);
		}
		public void Print()
		{
			if (Integer != 0) Console.Write(Integer);
			if (Numerator != 0)
			{
				if (Integer != 0) Console.Write("(");
				Console.Write($"{Numerator}/{Denominator}");
				if (Integer != 0) Console.Write(")");
			}
			else if (Integer == 0) Console.Write(0);
			Console.WriteLine();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string expression;
			string[] numbers;
			do
			{
				Console.Write("Введите простое арифметическое выражение: ");

				expression = Console.ReadLine();

				//Console.WriteLine(expression);

				numbers = expression.Split('+', '-', '*', '/');  //метод string[] Split(...) разделяет строку по указанным разделителям.
																		  // этот метод не изменяем исходную строку, а возвращает измененную строку ввиде массива строк.

			} while (true);


			double a = Convert.ToDouble(numbers[0]);
			double b = Convert.ToDouble(numbers[1]);
			Console.WriteLine(a + "\t" + b);
			switch (expression[expression.IndexOfAny(new char[]{'+','-','*','/'})])
			{
				case '+': Console.WriteLine($"{a}+{b}={a+b}"); break;
				case '-': Console.WriteLine($"{a}-{b}={a-b}"); break;
				case '*': Console.WriteLine($"{a}*{b}={a*b}"); break;
				case '/': Console.WriteLine($"{a}/{b}={a/b}"); break;
			}

		}
	}
}

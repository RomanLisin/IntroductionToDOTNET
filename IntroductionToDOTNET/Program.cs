//#define CONSOLE_PARAMETRS
//#define INPUT_DATA
//#define DATA_TYPES


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

namespace IntroductionToDOTNET
{
	internal class Program
	{

		static readonly string delimiter = "\n-------------------------------------------------------";
		static void Main(string[] args)
		{
			Console.Title = "Introduction to .NET";
#if CONSOLE_PARAMETRS
			Console.Beep(137, 1000);
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.CursorLeft = 22;
			Console.CursorTop = 11;
			Console.SetCursorPosition(22, 7);
			Console.Write("Hello.NET");  // Выводит строку на экран
			Console.WriteLine("Introduction"); // Выводит строку на экран и переводит курсор в начало следующей строки.
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ResetColor(); 
			//Console.Clear();

#endif

#if INPUT_DATA
			Console.Write("Введите Ваше имя: ");
			string first_name = Console.ReadLine();
			Console.Write("Введите Вашу фамилию: ");
			string last_name = Console.ReadLine();
			Console.WriteLine("Введите Ваш возраст: ");
			int age = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Ваше имя: " + first_name + " Ваша фамилия: " + last_name + "Ваш возраст: " + age); // Конкатенация строк
			Console.WriteLine(String.Format("Ваше имя: {0}, Ваша фамилия: {1}, Ваш возраст: {2}", first_name, last_name, age)); // Форматирование строк
			Console.WriteLine($"Ваше имя: {first_name}, Ваша фамилия: {last_name}, Ваш возраст: {age}"); // интерполяция строк
#endif


#if DATA_TYPES


			//Console.WriteLine("Char");
			//Console.WriteLine(sizeof(char));
			//Console.WriteLine((int)char.MinValue);
			//Console.WriteLine((int)char.MinValue);
			//Console.WriteLine();
			//object/*.*/

			//Console.WriteLine("SHORT");
			//Console.WriteLine(sizeof(short));
			//Console.WriteLine("USHORT");
			//Console.WriteLine(sizeof(ushort));
			//Console.WriteLine(${ ushort.MinValue});

			Console.WriteLine(delimiter);

			//Console.WriteLine($"Переменная типа 'short' занимает {sizeof(short)}Байт памяти, и принимает значения в диапазоне" +
			//	$"" ");
			Console.WriteLine($"ushort: {short.MinValue}...{ushort.MaxValue}");
			Console.WriteLine($" short: {short.MinValue}...{short.MaxValue}");
			Console.WriteLine($"decimal: {decimal.MinValue}...{decimal.MaxValue}");
			// IEEE-754 знаковый бит является неотъемлемой частью дробного числа
			Console.WriteLine();
#endif

			Console.Write("Введите число: ");
			int n = Convert.ToInt32(Console.ReadLine());
			long f = 1;
			for (int i=1;i<=n;i++)
			{
				f *= i;
				Console.WriteLine($"{i}!={f}");
			}
			Console.WriteLine($"Конечный результат: {n}!={f};");
			

			//BigInteger 5350;
 		}
	}
}


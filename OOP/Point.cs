using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
	internal class Point
	{
		double x;
		double y;
		public double X
		{
			get => x; //{ return x; }
			set
			{	
		       
				x = value;
			} // ключевое слово value возвращает значение, которое приходит из вне
		}
		public double Y
		{
			get => y;//{ return y; }
			set { y = value; }
		}
		public double GetX()
		{
			return x;
		}
		public double GetY()
		{
			return y;
		}
		public void SetX(double x)
		{
			this.x = x;
		}
		public void SetY(double y)
		{
			this.y = y;
		}

		// можно использовать автосвойства
		//public double X { get ; set; }
		//public double Y { get; set; }
		public Point(double x, double y)
		{
			X = x;
			Y = y;
            Console.WriteLine($"Constructor:\t {this.GetHashCode()}");
        }
		~Point()
		{
			Console.WriteLine($"Destructor:\t {this.GetHashCode()}");
		}
	}
}

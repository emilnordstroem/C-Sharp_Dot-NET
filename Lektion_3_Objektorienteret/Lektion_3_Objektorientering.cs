using System;
using System.Collections.Generic;
using System.Text;

namespace ObjektOrienteret
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Shape> shapes = new List<Shape>();
			shapes.Add(new Shape());
			shapes.Add(new Shape(2, 2));
			shapes.Add(new Circle(10));
			shapes.Add(new Circle(2, 2, 10));
			shapes.Add(new Rectangle());
			shapes.Add(new Rectangle(2, 2));

			Console.Out.WriteLine(string.Join(", ", shapes));


			Time t1, t2;

			t1 = new Time("00:00:30");
			Console.Out.WriteLine($"Default: {t1.ToString()}");
			t2 = t1;
			t2.Seconds = t2.Seconds + 29;
			Console.Out.WriteLine($"Adding 29 Seconds: {t2.ToString()}");
			t1 = new Time("00:30:00");
			Console.Out.WriteLine($"Default: {t1.ToString()}");
			t2 = t1;
			t2.Minutes = t2.Minutes + 29;
			Console.Out.WriteLine($"Adding 29 Minutes: {t2.ToString()}");
			t1 = new Time("12:00:00");
			Console.Out.WriteLine($"Default: {t1.ToString()}");
			t2 = t1;
			t2.Hours = t2.Hours + 11;
			Console.Out.WriteLine($"Adding 11 Hours: {t2.ToString()}");

			t1 = new Time("23:59:59");
			Console.Out.WriteLine($"Default: {t1.ToString()}");
			t2 = t1;
			t2.Seconds = t2.Seconds + 1;
			Console.Out.WriteLine($"Adding 1 Second: {t2.ToString()}");
			t1 = new Time("23:59:00");
			Console.Out.WriteLine($"Default: {t1.ToString()}");
			t2 = t1;
			t2.Minutes = t2.Minutes + 1;
			Console.Out.WriteLine($"Adding 1 Minute: {t2.ToString()}");
			t1 = new Time("23:00:00");
			Console.Out.WriteLine($"Default: {t1.ToString()}");
			t2 = t1;
			t2.Hours = t2.Hours + 1;
			Console.Out.WriteLine($"Adding 1 Hour: {t2.ToString()}");

		}
	}

	internal class Shape
	{
		private double x;
		private double y;

		public Shape(double x, double y)
		{
			this.x = x;
			this.y = y;
		}

		public Shape() : this(1, 1) { }

		public double X
		{
			get { return x; }
			set { x = value; }
		}
		public double Y
		{
			get { return y; }
			set { y = value; }
		}

		public override string ToString()
		{
			return $"Shape: {X}, {Y}";
		}
	}

	internal class Circle : Shape
	{
		private double radius;
		public Circle(double x, double y, double radius) : base(x, y)
		{
			this.radius = radius;
		}
		public Circle(double radius) : base()
		{
			this.radius = radius;
		}

		public double Radius
		{
			get { return radius; }
			set { radius = value; }
		}

		public override string ToString()
		{
			return $"Circle: {X}, {Y}, {Radius}";
		}
	}

	internal class Rectangle : Shape
	{
		public Rectangle(double length, double width) : base(length, width) { }

		public Rectangle() : base() { }

		public double Length
		{
			get { return X; }
			set { X = value; }
		}

		public double Width
		{
			get { return Y; }
			set { Y = value; }
		}

		public override string ToString()
		{
			return $"Rectangle: {X}, {Y}";
		}

	}


	public struct Time
	{
		private int secondsSinceMidnight;

		public Time(string time)
		{
			int seconds = Int32.Parse(time.Substring(6, 2));
			int minutes = Int32.Parse(time.Substring(3, 2));
			int hours = Int32.Parse(time.Substring(0, 2));
			secondsSinceMidnight = hours * 3600 + minutes * 60 + seconds;
		}

		public Time(int hours, int minutes, int seconds)
		{
			if (hours > 23 || minutes > 59 || seconds > 59)
			{
				throw new InvalidDataException();
			}
			secondsSinceMidnight = (hours * 3600) + (minutes * 60) + seconds;

		}

		public int Hours
		{
			get { return secondsSinceMidnight / 3600; }
			set
			{
				int hours = value;
				int minutes = (secondsSinceMidnight % 3600) / 60;
				int seconds = secondsSinceMidnight % 60;
				secondsSinceMidnight = hours * 3600 + minutes * 60 + seconds;
			}
		}

		public int Minutes
		{
			get { return (secondsSinceMidnight % 3600) / 60; }
			set
			{
				int minutes = value;
				int hours = secondsSinceMidnight / 3600;
				int seconds = secondsSinceMidnight % 60;
				secondsSinceMidnight = hours * 3600 + minutes * 60 + seconds;
			}
		}

		public int Seconds
		{
			get { return secondsSinceMidnight % 60; }
			set
			{
				int seconds = value;
				int hours = secondsSinceMidnight / 3600;
				int minutes = (secondsSinceMidnight % 3600) / 60;
				secondsSinceMidnight = hours * 3600 + minutes * 60 + seconds;
			}
		}

		public override string ToString()
		{
			return $"Current Time: {Hours}:{Minutes}:{Seconds}";
		}

	}

}

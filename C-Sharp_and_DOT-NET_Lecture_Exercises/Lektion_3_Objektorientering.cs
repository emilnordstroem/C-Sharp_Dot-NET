using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_and_DOT_NET_Lecture_Exercises
{

    internal class Program
    {
        static void Main (string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Shape());
            shapes.Add(new Shape(2, 2));
            shapes.Add(new Circle(10));
            shapes.Add(new Circle(2, 2, 10));
            shapes.Add(new Rectangle());
            shapes.Add(new Rectangle(2, 2));
            
			Console.Out.WriteLine(string.Join(", ", shapes));
			

        }
	}

    internal class Shape
    {
        private double x;
		private double y;

        public Shape (double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Shape (): this(1,1) { }

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
        public Circle (double x, double y, double radius): base(x, y)
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
        public Rectangle(double length, double width): base(length, width){ }

        public Rectangle(): base() { }

        public double Length { 
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

}

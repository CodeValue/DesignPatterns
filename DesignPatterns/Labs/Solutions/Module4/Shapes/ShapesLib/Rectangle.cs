using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ShapesLib {
	public class Rectangle : Shape {
		public int Width { get; private set; }
		public int Height { get; private set; }

		public Rectangle(int width, int height, ConsoleColor color = ConsoleColor.White) : base(color) {
			Width = width;
			Height = height;
		}

		public override void Display(TextWriter writer, int indent) {
			writer.Write(new string(' ', indent));
			writer.WriteLine("Rectangle: {2} Width={0}, Height={1}", Width, Height, PositionAsString);
		}
	}
}

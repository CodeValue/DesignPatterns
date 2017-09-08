using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ShapesLib {
	public class Circle : Shape {
		public int Radius { get; private set; }

		public Circle(int radius, ConsoleColor color = ConsoleColor.White) : base(color) {
			Radius = radius;
		}

		public override void Display(TextWriter writer, int indent) {
			writer.Write(new string(' ', indent));
			writer.WriteLine("Circle: {1} Radius={0}", Radius, PositionAsString);
		}
	}
}

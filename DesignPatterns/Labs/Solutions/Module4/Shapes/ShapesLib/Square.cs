using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ShapesLib {
	public class Square : Shape {
		public int Length { get; private set; }

		public Square(int len, ConsoleColor color = ConsoleColor.White) : base(color) {
			Length = len;
		}

		public override void Display(TextWriter writer, int indent) {
			writer.Write(new string(' ', indent));
			writer.WriteLine("Square: {1} Length: {0}", Length, PositionAsString);
		}
	}
}

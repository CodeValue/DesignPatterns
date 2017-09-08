using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ShapesLib {
	public abstract class Shape {
		public ConsoleColor Color { get; set; }
		public int X { get; protected set; }
		public int Y { get; protected set; }

		public abstract void Display(TextWriter writer, int indent = 0);

		protected string PositionAsString {
			get {
				return string.Format("({0},{1})", X, Y);
			}
		}

		protected Shape(ConsoleColor color) {
			Color = color;
		}

		protected Shape()
			: this(ConsoleColor.White) {
		}

		public virtual void Move(int dx, int dy) {
			X += dx;
			Y += dy;
		}
	}
}

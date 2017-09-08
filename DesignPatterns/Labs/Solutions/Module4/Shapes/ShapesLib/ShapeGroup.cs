using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ShapesLib {
	public class ShapeGroup : Shape {
		readonly List<Shape> _shapes = new List<Shape>();

		public override void Display(TextWriter writer, int indent) {
			writer.Write(new string(' ', indent));
			writer.WriteLine("Group:");
			foreach(var shape in _shapes) {
				shape.Display(writer, indent + 2);
			}
		}

		public override void Move(int dx, int dy) {
			foreach(var shape in _shapes)
				shape.Move(dx, dy);
		}

		public void Add(Shape shape) {
			_shapes.Add(shape);
		}
	}
}

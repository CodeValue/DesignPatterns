using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapesLib;
using System.IO;

namespace ShapesApp {
	class ShapeManager {
		readonly List<Shape> _shapes = new List<Shape>();

		public void Add(Shape shape) {
			_shapes.Add(shape);
		}

		public IEnumerable<Shape> Shapes {
			get { return _shapes; }
		}

		public void Display(TextWriter writer) {
			int i = 0;
			foreach(var shape in _shapes) {
				writer.Write("{0}) ", ++i);
				shape.Display(writer);
			}
		}

		public void RemoveAt(int index) {
			_shapes.RemoveAt(index);
		}

		public void Remove(Shape shape) {
			_shapes.Remove(shape);
		}

		public Shape this[int index] {
			get { return _shapes[index]; }
		}
	}
}

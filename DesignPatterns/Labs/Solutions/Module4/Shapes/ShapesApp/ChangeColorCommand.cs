using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapesLib;

namespace ShapesApp {
	class ChangeColorCommand : ICommand {
		Shape _shape;
		ConsoleColor _color;

		public ChangeColorCommand(Shape shape, ConsoleColor color) {
			_shape = shape;
			_color = color;
		}

		#region ICommand Members

		public void Execute() {
			var prev = _shape.Color;
			_shape.Color = _color;
			_color = prev;
		}

		public void Undo() {
			Execute();
		}

		#endregion
	}
}

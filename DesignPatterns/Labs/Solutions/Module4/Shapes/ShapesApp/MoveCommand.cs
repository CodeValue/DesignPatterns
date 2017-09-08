using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapesLib;

namespace ShapesApp {
	class MoveCommand : ICommand {
		readonly Shape _shape;
		readonly int _dx, _dy;

		public MoveCommand(Shape shape, int dx, int dy) {
			_shape = shape;
			_dx = dx;
			_dy = dy;
		}

		#region ICommand Members

		public void Execute() {
			_shape.Move(_dx, _dy);
		}

		public void Undo() {
			_shape.Move(-_dx, -_dy);
		}

		#endregion
	}
}

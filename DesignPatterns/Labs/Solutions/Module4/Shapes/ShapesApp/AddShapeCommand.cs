using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapesLib;

namespace ShapesApp {
	class AddShapeCommand : ICommand {
		ShapeManager _mgr;
		Shape _shape;

		public AddShapeCommand(ShapeManager sm, Shape shape) {
			_mgr = sm;
			_shape = shape;
		}

		#region ICommand Members

		public virtual void Execute() {
			_mgr.Add(_shape);
		}

		public virtual void Undo() {
			_mgr.Remove(_shape);
		}

		#endregion
	}

	class RemoveShapeCommand : AddShapeCommand {
		public RemoveShapeCommand(ShapeManager mgr, Shape shape) : base(mgr, shape) { }

		public override void Execute() {
			base.Undo();
		}

		public override void Undo() {
			base.Execute();
		}
	}
}

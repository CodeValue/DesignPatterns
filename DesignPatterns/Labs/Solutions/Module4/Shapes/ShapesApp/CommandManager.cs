using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesApp {
	class CommandManager {
		readonly List<ICommand> _undoList = new List<ICommand>();
		readonly List<ICommand> _redoList = new List<ICommand>();

		public void Add(ICommand cmd, bool execute = true) {
			_undoList.Add(cmd);
			if(execute)
				cmd.Execute();
			_redoList.Clear();
		}

		public bool CanUndo {
			get { return _undoList.Count > 0; }
		}

		public bool CanRedo {
			get { return _redoList.Count > 0; }
		}

		public void Undo() {
			if(!CanUndo)
				throw new InvalidOperationException("Cannot undo");
			var cmd = _undoList[_undoList.Count - 1];
			cmd.Undo();
			_redoList.Add(cmd);
			_undoList.RemoveAt(_undoList.Count - 1);
		}

		public void Redo() {
			if(!CanRedo)
				throw new InvalidOperationException("Cannot redo");
			var cmd = _redoList[_redoList.Count - 1];
			cmd.Execute();
			_undoList.Add(cmd);
			_redoList.RemoveAt(_redoList.Count - 1);
		}
	}
}

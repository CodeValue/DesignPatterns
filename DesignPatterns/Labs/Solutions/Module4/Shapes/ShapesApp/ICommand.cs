﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesApp {
	interface ICommand {
		void Execute();
		void Undo();
	}
}

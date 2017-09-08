using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapesLib;

namespace ShapesApp {
	class Program {
		static void Main(string[] args) {
			var sm = new ShapeManager();
			var cmdMgr = new CommandManager();
			sm.Add(new Rectangle(10, 3, ConsoleColor.Green));
			sm.Add(new Circle(5, ConsoleColor.Red));
			sm.Add(new Square(8, ConsoleColor.Blue));
			var group = new ShapeGroup();
			group.Add(new Circle(10));
			group.Add(new Rectangle(6, 8, ConsoleColor.Cyan));
			sm.Add(group);

			var group2 = new ShapeGroup();
			group2.Add(new Square(12, ConsoleColor.DarkGray));
			group2.Add(new Circle(6));
			group.Add(group2);

			var rnd = new Random();

			bool done = false;
			while(!done) {
				int n;
				Console.WriteLine();
				Console.Write("A=Add, E=Remove, D=Display, M=Move, U=Undo, R=Redo, Q=Quit: ");
				switch(Console.ReadLine().ToUpper()) {
					case "D":
						sm.Display(Console.Out);
						break;

					case "Q":
						done = true;
						break;

					case "M":
						n = GetShapeNumber();
						Console.Write("X Offset: ");
						int dx = int.Parse(Console.ReadLine());
						Console.Write("Y Offset: ");
						int dy = int.Parse(Console.ReadLine());
						var cmd = new MoveCommand(sm[n], dx, dy);
						cmdMgr.Add(cmd);
						break;

					case "U":
						if(!cmdMgr.CanUndo)
							Console.WriteLine("Cannot undo!");
						else
							cmdMgr.Undo();
						break;

					case "R":
						if(!cmdMgr.CanRedo)
							Console.WriteLine("Cannot redo!");
						else
							cmdMgr.Redo();
						break;

					case "A":
						Shape shape = null;
						switch(rnd.Next(3)) {
							case 0: shape = new Square(rnd.Next(10) + 5); break;
							case 1: shape = new Circle(rnd.Next(10) + 2); break;
							case 2: shape = new Rectangle(rnd.Next(10) + 1, rnd.Next(10) + 3); break;
						}
						cmdMgr.Add(new AddShapeCommand(sm, shape));
						break;

					case "E":
						n = GetShapeNumber();
						cmdMgr.Add(new RemoveShapeCommand(sm, sm[n]));
						break;
				}
			}
		}

		static int GetShapeNumber() {
			Console.Write("Shape number: ");
			return int.Parse(Console.ReadLine()) - 1;
		}
	}
}

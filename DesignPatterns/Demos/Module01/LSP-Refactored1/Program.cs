using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSP_Refactored1 {
	class Program {
		static void Main(string[] args) {
			var r1 = new Rectangle(8, 5);
			Process(r1);
			var r2 = new Square(6);
			Process(r2);
		}

		private static void Process(Rectangle r) {
			Console.WriteLine(r.Area);
		}
	}
}

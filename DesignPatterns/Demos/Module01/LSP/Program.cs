using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSP {
	class Program {
		static void Main(string[] args) {
			var r1 = new Rectangle();
			Process(r1);
			var r2 = new Square();
			Process(r2);
		}

		private static void Process(Rectangle r) {
			r.Width = 8;
			r.Height = 5;
			Console.WriteLine(r.Area);		// expected 40
		}
	}
}

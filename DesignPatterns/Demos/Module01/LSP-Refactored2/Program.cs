using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSP_Refactored2 {
	class Program {
		static void Main(string[] args) {
			Rectangle r = new Rectangle { Height = 5, Width = 8 };
			Square s = new Square { Length = 10 };
			Console.WriteLine(r.Area);
			Console.WriteLine(s.Area);
		}
	}
}

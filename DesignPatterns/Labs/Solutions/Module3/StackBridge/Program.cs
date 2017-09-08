using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackBridge {
	class Program {
		static void Main(string[] args) {
			var stack = new Stack<int> { StackImpl = new StackArrayImpl<int>() };
			for(int i = 1; i <= 10; i++)
				stack.Push(i * i);

			stack.Dump(Console.Out);
		}
	}
}

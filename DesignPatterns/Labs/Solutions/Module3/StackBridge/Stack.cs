using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StackBridge {
	class Stack<T> {
		public IStack<T> StackImpl { get; set; }

		public void Push(T value) {
			StackImpl.Push(value);
		}

		public T Pop() {
			return StackImpl.Pop();
		}

		public T Peek() {
			return StackImpl.Peek();
		}

		public bool IsEmpty {
			get { return StackImpl.IsEmpty; }
		}

		public int Count {
			get { return StackImpl.Count; }
		}

		public void Dump(TextWriter writer) {
			while(!IsEmpty)
				writer.WriteLine(Pop());
		}
	}
}

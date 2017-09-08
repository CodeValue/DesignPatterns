using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackBridge {
	public interface IStack<T> {
		void Push(T value);
		T Pop();
		T Peek();
		bool IsEmpty { get; }
		int Count { get; }
	}
}

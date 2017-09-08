using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackBridge {
	class StackArrayImpl<T> : IStack<T> {
		T[] _items;
		int _sp;

		public StackArrayImpl() {
			 _items = new T[8];
		}

		#region IStack<T> Members

		public void Push(T value) {
			if(_sp >= _items.Length)
				Array.Resize(ref _items, _items.Length * 2);
			_items[_sp++] = value;
		}

		public T Pop() {
			return _items[--_sp];
		}

		public T Peek() {
			return _items[_sp - 1];
		}

		public bool IsEmpty {
			get { return _sp == 0; }
		}

		public int Count {
			get { return _sp; }
		}

		#endregion
	}
}

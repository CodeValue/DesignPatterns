using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackBridge {
	class StackListImpl<T> : IStack<T> {
		readonly List<T> _items = new List<T>();

		#region IStack<T> Members

		public void Push(T value) {
			_items.Add(value);
		}

		public T Pop() {
			T value = _items[_items.Count - 1];
			_items.RemoveAt(_items.Count - 1);
			return value;
		}

		public T Peek() {
			return _items[_items.Count - 1];
		}

		public bool IsEmpty {
			get {
				return _items.Count == 0;
			}
		}

		public int Count {
			get { return _items.Count; }
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericApp {
	public interface IMultiDictionary<K, V> {
		void Add(K key, V value);
		bool Remove(K key);
		bool Remove(K key, V value);
		void Clear();
		bool ContainsKey(K key);
		bool Contains(K key, V value);
		ICollection<K> Keys { get; }
		ICollection<V> Values { get; }
		int Count { get; }
	}

	class Program {
		static void Main(string[] args) {
			MultiDictionary<int, string> d = new MultiDictionary<int, string>();
			d.Add(1, "one");
			d.Add(2, "two");
			d.Add(3, "three");
			d.Add(1, "ich");
			d.Add(2, "nee");
			d.Add(3, "sun");

			Console.WriteLine("Total: {0}", d.Count);
			foreach(int k in d.Keys)
				Console.WriteLine(k);

			foreach(string v in d.Values)
				Console.WriteLine(v);

			Console.WriteLine();
			Console.WriteLine(d.Contains(3, "three"));
			Console.WriteLine(d.Contains(4, "four"));

			foreach(KeyValuePair<int, string> pair in d)
				Console.WriteLine(pair);
		}
	}
}

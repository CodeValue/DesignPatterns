using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace GenericApp {
	public class MultiDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>, IMultiDictionary<K, V> {
		private Dictionary<K, LinkedList<V>> _set = new Dictionary<K, LinkedList<V>>();

		#region IEnumerable<KeyValuePair<K,V>> Members

		public IEnumerator<KeyValuePair<K, V>> GetEnumerator() {
			LinkedList<KeyValuePair<K, V>> list = new LinkedList<KeyValuePair<K, V>>();
			foreach(KeyValuePair<K, LinkedList<V>> pair in _set)
				foreach(V v in pair.Value)
					//yield return new KeyValuePair<K, V>(pair.Key, v);
					list.AddLast(new KeyValuePair<K, V>(pair.Key, v));
			return list.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		#endregion

		#region IMultiDictionary<K,V> Members

		public void Add(K key, V value) {
			if(_set.ContainsKey(key))
				_set[key].AddLast(value);
			else {
				LinkedList<V> list = new LinkedList<V>();
				list.AddLast(value);
				_set.Add(key, list);
			}
		}

		public bool Remove(K key) {
			return _set.Remove(key);
		}

		public bool Remove(K key, V value) {
			if(!_set.ContainsKey(key)) return false;
			_set[key].Remove(value);
			if(_set[key].Count == 0)
				_set.Remove(key);
			return true;
		}

		public void Clear() {
			_set.Clear();
		}

		public int Count {
			get {
				return Values.Count;
			}
		}

		public bool ContainsKey(K key) {
			return _set.ContainsKey(key);
		}

		public bool Contains(K key, V value) {
			if(!ContainsKey(key)) return false;
			return _set[key].Find(value) == null ? false : true;
		}

		public ICollection<K> Keys {
			get { return _set.Keys; }
		}

		public ICollection<V> Values {
			get {
				List<V> all = new List<V>();
				foreach(LinkedList<V> list in _set.Values)
					all.AddRange(list);
				return all;
			}
		}

		#endregion
	}
}

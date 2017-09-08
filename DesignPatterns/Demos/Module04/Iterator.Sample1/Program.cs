using System;
using System.Collections;

namespace Iterator.Sample1 {
	class Program {
		static void Main() {
			// Build a collection
			Collection collection = new Collection();
			collection[0] = new Item("Item 0");
			collection[1] = new Item("Item 1");
			collection[2] = new Item("Item 2");
			collection[3] = new Item("Item 3");
			collection[4] = new Item("Item 4");
			collection[5] = new Item("Item 5");
			collection[6] = new Item("Item 6");
			collection[7] = new Item("Item 7");
			collection[8] = new Item("Item 8");

			// Create iterator
			Iterator iterator = new Iterator(collection);

			// Skip every other item
			iterator.Step = 2;

			Console.WriteLine("Iterating over collection:");

			for(Item item = iterator.First();
				 !iterator.IsDone; item = iterator.Next()) {
				Console.WriteLine(item.Name);
			}
		}
	}

	// A collection item
	class Item {
		private string _name;

		// Constructor
		public Item(string name) {
			this._name = name;
		}

		// Gets name
		public string Name {
			get { return _name; }
		}
	}

	// The 'Aggregate' interface
	interface IAbstractCollection {
		Iterator CreateIterator();
	}

	// The 'ConcreteAggregate' class
	class Collection : IAbstractCollection {
		private ArrayList _items = new ArrayList();

		public Iterator CreateIterator() {
			return new Iterator(this);
		}

		// Gets item count
		public int Count {
			get { return _items.Count; }
		}

		// Indexer
		public object this[int index] {
			get { return _items[index]; }
			set { _items.Add(value); }
		}
	}

	// The 'Iterator' interface
	interface IAbstractIterator {
		Item First();
		Item Next();
		bool IsDone { get; }
		Item CurrentItem { get; }
	}

	// The 'ConcreteIterator' class
	class Iterator : IAbstractIterator {
		private Collection _collection;
		private int _current = 0;

		public Iterator(Collection collection) {
			this._collection = collection;
			Step = 1;
		}

		// Gets first item
		public Item First() {
			_current = 0;
			return _collection[_current] as Item;
		}

		// Gets next item
		public Item Next() {
			_current += Step;
			if(!IsDone)
				return _collection[_current] as Item;
			else
				return null;
		}

		// Gets or sets stepsize
		public int Step { get; set; }

		// Gets current iterator item
		public Item CurrentItem {
			get { return _collection[_current] as Item; }
		}

		// Gets whether iteration is complete
		public bool IsDone {
			get { return _current >= _collection.Count; }
		}
	}
}

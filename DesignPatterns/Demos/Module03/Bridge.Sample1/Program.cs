using System;
using System.Collections.Generic;

namespace Bridge.Sample1 {
	class Program {
		/// <summary>
		/// Entry point into console application.
		/// </summary>
		static void Main() {
			// Create RefinedAbstraction
			var customers = new Customers();

			// Set ConcreteImplementor
			customers.DataObject = new CustomersData { City = "Chicago" };

			// Exercise the bridge
			customers.Show();
			customers.Next();
			customers.Show();
			customers.Next();
			customers.Show();

			customers.Add("Henry Velasquez");
			customers.ShowAll();
		}
	}

	// The 'Abstraction' class
	class CustomersBase {
		// Gets or sets data object
		public IDataObject<string> DataObject { get; set; }

		public virtual void Next() {
			DataObject.NextRecord();
		}

		public virtual void Prior() {
			DataObject.PriorRecord();
		}

		public virtual void Add(string name) {
			DataObject.AddRecord(name);
		}

		public virtual void Delete(string name) {
			DataObject.DeleteRecord(name);
		}

		public virtual void Show() {
			DataObject.ShowRecord();
		}

		public virtual void ShowAll() {

			DataObject.ShowAllRecords();
		}
	}

	// The 'RefinedAbstraction' class
	class Customers : CustomersBase {
		public override void ShowAll() {
			// Add separator lines
			Console.WriteLine();
			Console.WriteLine("------------------------");
			base.ShowAll();
			Console.WriteLine("------------------------");
		}
	}

	// The 'Implementor' interface
	interface IDataObject<T> {
		void NextRecord();
		void PriorRecord();
		void AddRecord(T t);
		void DeleteRecord(T t);
		T GetCurrentRecord();
		void ShowRecord();
		void ShowAllRecords();
	}

	// The 'ConcreteImplementor' class
	class CustomersData : IDataObject<string> {
		// Gets or sets city
		public string City { get; set; }

		private List<string> _customers;
		private int _current = 0;

		// Constructor
		public CustomersData() {
			// Simulate loading from database
			_customers = new List<string>
              { "Jim Jones", "Samual Jackson", "Allan Good",
                "Ann Stills", "Lisa Giolani" };
		}

		public void NextRecord() {
			if(_current <= _customers.Count - 1) {
				_current++;
			}
		}

		public void PriorRecord() {
			if(_current > 0) {
				_current--;
			}
		}

		public void AddRecord(string customer) {
			_customers.Add(customer);
		}

		public void DeleteRecord(string customer) {
			_customers.Remove(customer);
		}

		public string GetCurrentRecord() {
			return _customers[_current];
		}

		public void ShowRecord() {
			Console.WriteLine(_customers[_current]);
		}

		public void ShowAllRecords() {
			Console.WriteLine("Customer Group: " + City);
			_customers.ForEach(customer =>
				 Console.WriteLine(" " + customer));
		}
	}
}

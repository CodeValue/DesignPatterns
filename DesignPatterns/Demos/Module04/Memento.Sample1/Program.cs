using System;

namespace Memento.Sample1 {
	class Program {
		static void Main() {
			SalesProspect s = new SalesProspect();
			s.Name = "Noel van Halen";
			s.Phone = "(412) 256-0990";
			s.Budget = 25000.0;

			// Store internal state
			ProspectMemory m = new ProspectMemory();
			m.Memento = s.SaveMemento();

			// Continue changing originator
			s.Name = "Leo Welch";
			s.Phone = "(310) 209-7111";
			s.Budget = 1000000.0;

			// Restore saved state
			s.RestoreMemento(m.Memento);
		}
	}

	// The 'Originator' class
	class SalesProspect {
		private string _name;
		private string _phone;
		private double _budget;

		// Gets or sets name
		public string Name {
			get { return _name; }
			set {
				_name = value;
				Console.WriteLine("Name:   " + _name);
			}
		}

		// Gets or sets phone
		public string Phone {
			get { return _phone; }
			set {
				_phone = value;
				Console.WriteLine("Phone:  " + _phone);
			}
		}

		// Gets or sets budget
		public double Budget {
			get { return _budget; }
			set {
				_budget = value;
				Console.WriteLine("Budget: " + _budget);
			}
		}

		// Stores memento
		public Memento SaveMemento() {
			Console.WriteLine("\nSaving state --\n");
			return new Memento { Name = _name, Phone = _phone, Budget = _budget};
		}

		// Restores memento
		public void RestoreMemento(Memento memento) {
			Console.WriteLine("\nRestoring state --\n");
			this.Name = memento.Name;
			this.Phone = memento.Phone;
			this.Budget = memento.Budget;
		}
	}

	// The 'Memento' class
	class Memento {
		public string Name { get; set; }
		public string Phone { get; set; }
		public double Budget { get; set; }
	}

	// The 'Caretaker' class
	class ProspectMemory {
		public Memento Memento { get; set; }
	}
}

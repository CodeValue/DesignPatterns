using System;
using System.Collections.Generic;

namespace Observer.Sample1 {
	class Program {
		static void Main() {
			// Create IBM stock and attach investors
			var ibm = new IBM("IBM", 120.0);
			ibm.Attach(new Investor("Sorros"));
			ibm.Attach(new Investor("Berkshire"));

			// Fluctuating prices will notify investors
			ibm.Price = 120.10;
			ibm.Price = 121.00;
			ibm.Price = 120.50;
			ibm.Price = 120.75;

		}
	}

	// The 'Subject' abstract class
	abstract class Stock {
		private double _price;
		private List<IInvestor> _investors = new List<IInvestor>();

		// Constructor
		public Stock(string symbol, double price) {
			Symbol = symbol;
			_price = price;
		}

		public void Attach(IInvestor investor) {
			_investors.Add(investor);
		}

		public void Detach(IInvestor investor) {
			_investors.Remove(investor);
		}

		public void Notify() {
			foreach(IInvestor investor in _investors) {
				investor.Update(this);
			}
			Console.WriteLine();
		}

		// Gets or sets the price
		public double Price {
			get { return _price; }
			set {
				if(_price != value) {
					_price = value;
					Notify();
				}
			}
		}

		public string Symbol { get; private set; }
	}

	// The 'ConcreteSubject' class
	class IBM : Stock {
		// Constructor
		public IBM(string symbol, double price)
			: base(symbol, price) {
		}
	}

	// The 'Observer' interface
	interface IInvestor {
		void Update(Stock stock);
	}

	// The 'ConcreteObserver' class
	class Investor : IInvestor {
		public string Name { get; set; }
		public Stock Stock { get; set; }

		// Constructor
		public Investor(string name) {
			Name = name;
		}

		public void Update(Stock stock) {
			Console.WriteLine("Notified {0} of {1}'s " +
				 "change to {2:C}", Name, stock.Symbol, stock.Price);
		}
	}
}

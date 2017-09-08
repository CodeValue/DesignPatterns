using System;

namespace Chain.Sample1 {
	class Program {
		/// <summary>
		/// Entry point into console application.
		/// </summary>
		static void Main() {
			// Setup Chain of Responsibility
			Approver larry = new Director();
			Approver sam = new VicePresident();
			Approver tammy = new President();

			larry.Successor = sam;
			sam.Successor = tammy;

			// Generate and process purchase requests
			var purchase = new Purchase { Number = 2034, Amount = 350.00, Purpose = "Supplies" };
			larry.ProcessRequest(purchase);

			purchase = new Purchase { Number = 2035, Amount = 32590.10, Purpose = "Project X" };
			larry.ProcessRequest(purchase);

			purchase = new Purchase { Number = 2036, Amount = 122100.00, Purpose = "Project Y" };
			larry.ProcessRequest(purchase);
		}
	}

	// The 'Handler' abstract class
	abstract class Approver {
		public abstract void ProcessRequest(Purchase purchase);

		// Sets or gets the next approver
		public Approver Successor { get; set; }
	}

	// The 'ConcreteHandler' class
	class Director : Approver {
		public override void ProcessRequest(Purchase purchase) {
			if(purchase.Amount < 10000.0) {
				Console.WriteLine("{0} approved request# {1}",
					 this.GetType().Name, purchase.Number);
			}
			else if(Successor != null) {
				Successor.ProcessRequest(purchase);
			}
		}
	}

	// The 'ConcreteHandler' class
	class VicePresident : Approver {
		public override void ProcessRequest(Purchase purchase) {
			if(purchase.Amount < 25000.0) {
				Console.WriteLine("{0} approved request# {1}",
					 this.GetType().Name, purchase.Number);
			}
			else if(Successor != null) {
				Successor.ProcessRequest(purchase);
			}
		}
	}

	// The 'ConcreteHandler' clas
	class President : Approver {
		public override void ProcessRequest(Purchase purchase) {
			if(purchase.Amount < 100000.0) {
				Console.WriteLine("{0} approved request# {1}",
					 this.GetType().Name, purchase.Number);
			}
			else {
				Console.WriteLine(
					 "Request# {0} requires an executive meeting!",
					 purchase.Number);
			}
		}
	}

	// Class that holds request details
	public class Purchase {
		public double Amount { get; set; }
		public string Purpose { get; set; }
		public int Number { get; set; }
	}
}

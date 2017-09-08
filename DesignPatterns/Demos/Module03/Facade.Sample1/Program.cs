using System;

namespace Facade.Sample1 {
	class Program {
		/// <summary>
		/// Entry point into console application.
		/// </summary>
		static void Main() {
			// Facade
			var mortgage = new Mortgage();

			// Evaluate mortgage eligibility for customer
			var customer = new Customer { Name = "Bart Simpson" };
			bool eligible = mortgage.IsEligible(customer, 125000);

			Console.WriteLine("\n{0} has been {1}", customer.Name, (eligible ? "Approved" : "Rejected"));
		}
	}

	// The 'Subsystem ClassA' class
	class Bank {
		public bool HasSufficientSavings(Customer c, int amount) {
			Console.WriteLine("Check bank for " + c.Name);
			return true;
		}
	}

	// The 'Subsystem ClassB' class
	class Credit {
		public bool HasGoodCredit(Customer c) {
			Console.WriteLine("Check credit for " + c.Name);
			return true;
		}
	}

	// The 'Subsystem ClassC' class
	class Loan {
		public bool HasNoBadLoans(Customer c) {
			Console.WriteLine("Check loans for " + c.Name);
			return true;
		}
	}

	// The 'Facade' class
	class Mortgage {
		private Bank _bank = new Bank();
		private Loan _loan = new Loan();
		private Credit _credit = new Credit();

		public bool IsEligible(Customer cust, int amount) {
			Console.WriteLine("{0} applies for {1:C} loan\n",
				 cust.Name, amount);

			bool eligible = true;

			// Check creditworthyness of applicant
			if(!_bank.HasSufficientSavings(cust, amount)) {
				eligible = false;
			}
			else if(!_loan.HasNoBadLoans(cust)) {
				eligible = false;
			}
			else if(!_credit.HasGoodCredit(cust)) {
				eligible = false;
			}

			return eligible;
		}
	}

	/// <summary>
	/// Customer class
	/// </summary>
	class Customer {
		// Gets or sets the name
		public string Name { get; set; }
	}
}

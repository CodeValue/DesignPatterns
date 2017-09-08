using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	class SavingsAccount : Account {
		internal SavingsAccount(Guid number)
			: base(number) {
			
		}
		public override void Withdraw(decimal amount) {
			throw new InvalidOperationException("Cannot withdraw from a SavingAccount");
		}

		public double InterestRate { get; internal set; }

		internal void AddInterest() {
			Balance *= (decimal)(1.0 + InterestRate);
		}
	}
}

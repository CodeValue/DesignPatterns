using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	class CommisionAccount : Account {
		readonly Account _original;

		public double Commission { get; set; }

		public CommisionAccount(Account original) : base(original.AccountNumber) {
			_original = original;
		}

		public override void Deposit(decimal amount) {
			_original.Deposit(amount);
			_original.Withdraw((decimal)Commission * amount);
		}

		public override void Withdraw(decimal amount) {
			_original.Withdraw(amount);
			_original.Withdraw((decimal)Commission * amount);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Banking {
	internal class TracingAccount : Account {
		readonly Account _original;

		public TracingAccount(Account original) : base(original.AccountNumber) {
			_original = original;
		}

		public TextWriter Logger { get; set; }

		public override void Deposit(decimal amount) {
			_original.Deposit(amount);
			Logger.WriteLine("{0}: Deposit {1}", AccountNumber, amount);
		}

		public override void Withdraw(decimal amount) {
			_original.Withdraw(amount);
			Logger.WriteLine("{0}: Withdraw {1}", AccountNumber, amount);
		}
	}
}

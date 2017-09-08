using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace SimpleMEF {
	[Export]
	class Account {
		[Import(AllowDefault = true)]
		public ILogger Logger { get; private set; }

		public void Deposit(decimal amount) {
			if(amount <= 0)
				throw new ArgumentException("amount must be positive");
			Balance += amount;
			if(Logger != null)
				Logger.Log(string.Format("Deposited {0}", amount));
		}

		public void Withdraw(decimal amount) {
			if(amount <= 0)
				throw new ArgumentException("amound must be positive");
			if(amount > Balance)
				throw new InvalidOperationException("Overdraft is forbidden");
			Balance -= amount;
			Logger.Log(string.Format("Withdrew {0}", amount));
		}

		public decimal Balance { get; private set; }

	}

}

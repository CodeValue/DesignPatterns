using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace SimpleMEF {
	[Export(typeof(IAccount))]
	class BankAccount : IAccount {
		private decimal _balance;

		[Import]
		public ILogger Logger { get; private set; }

		#region IAccount Members

		public void Deposit(decimal amount) {
			if(amount <= 0)
				throw new ArgumentException("amount must be positive");
			_balance += amount;
			Logger.Log(string.Format("Deposited {0}", amount));
		}

		public void Withdraw(decimal amount) {
			if(amount <= 0)
				throw new ArgumentException("amound must be positive");
			if(amount > _balance)
				throw new InvalidOperationException("Overdraft is forbidden");
			_balance -= amount;
			Logger.Log(string.Format("Withdrew {0}", amount));
		}

		public decimal Balance {
			get { return _balance; }
		}

		#endregion
	}

	//[Export(typeof(IAccount))]
	class TradingAccount : IAccount {
		#region IAccount Members

		public void Deposit(decimal amount) {
		}

		public void Withdraw(decimal amount) {
		}

		public decimal Balance {
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}

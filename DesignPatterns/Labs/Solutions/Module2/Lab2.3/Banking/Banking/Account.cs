using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	public abstract class Account {
		public readonly Guid AccountNumber;
		public Customer Customer { get; internal set; }

		internal Account(Guid number) {
			AccountNumber = number;
		}

		public decimal Balance { get; protected set; }

		public virtual void Deposit(decimal amount) {
			if(amount <= 0)
				throw new ArgumentException("amount");
			Balance += amount;
		}

		public abstract void Withdraw(decimal amount);
	}
}

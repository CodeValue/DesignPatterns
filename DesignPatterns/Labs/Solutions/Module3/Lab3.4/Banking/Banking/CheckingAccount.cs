using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	class CheckingAccount : Account {
		internal CheckingAccount(Guid number) : base(number) { }

		public override void Withdraw(decimal amount) {
			if(amount <= 0)
				throw new ArgumentException("amount");
			if(amount > WithdrawLimit)
				throw new InvalidOperationException("Exceeded withdraw limit");
			Balance -= amount;
		}

		public decimal WithdrawLimit { get; internal set; }

	}
}

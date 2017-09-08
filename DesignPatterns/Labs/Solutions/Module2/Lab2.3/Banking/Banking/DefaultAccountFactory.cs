using System;
using System.ComponentModel.Composition;

namespace Banking {
	[Export(typeof(IAccountFactory))]
	class DefaultAccountFactory : IAccountFactory {
		#region IAccountFactory Members

		public Account CreateAccount(AccountType type, Customer customer) {
			Account acc = null;
			switch(type) {
				case AccountType.CheckingAccount:
					var chk = new CheckingAccount(Guid.NewGuid());
					chk.WithdrawLimit = 2500 * (decimal)customer.BaseLimitFactor;
					acc = chk;
					break;

				case AccountType.SavingsAccount:
					var sav = new SavingsAccount(Guid.NewGuid());
					sav.InterestRate = (new Random().Next(5) + 1) / 100.0;
					acc = sav;
					break;
			}
			return acc;
		}

		#endregion
	}
}

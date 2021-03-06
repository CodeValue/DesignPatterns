﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	class DefaultAccountFactory : IAccountFactory {
		#region IAccountFactory Members

		public Account CreateAccount(AccountType type, Customer customer) {
			Account acc = null;
			switch(type) {
				case AccountType.CheckingAccount:
					bool commission = customer.BaseLimitFactor > 1.5;
					var chk = new CheckingAccount(Guid.NewGuid());
					chk.WithdrawLimit = 2500 * (decimal)customer.BaseLimitFactor;
					acc = commission ? (Account)new CommisionAccount(chk) { Commission = .1 } : (Account)chk;
					break;

				case AccountType.SavingsAccount:
					var sav = new SavingsAccountProxy(Guid.NewGuid());
					sav.InterestRate = (new Random().Next(5) + 1) / 100.0;
					acc = sav;
					break;
			}
			return acc;
		}

		#endregion
	}
}

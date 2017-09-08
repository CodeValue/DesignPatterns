using System;
using System.Collections.Generic;

namespace Banking {
	public class Customer {
		readonly HashSet<Guid> _accounts = new HashSet<Guid>();

		public string Name { get; private set; }

		internal Customer(string name) {
			Name = name;
			BaseLimitFactor = 1.0;
		}

		internal void AddAccount(Account account) {
			_accounts.Add(account.AccountNumber);
		}

		protected internal Bank Bank;

		public IEnumerable<Account> Accounts {
			get {
				return Bank.GetAccountsForCustomer(this);
			}
		}

		public virtual double BaseLimitFactor { get; protected set; }
	}
}

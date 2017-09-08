using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

		public IEnumerable<Account> Accounts {
			get {
				return Bank.Instance.GetAccountsForCustomer(this);
			}
		}

		public virtual double BaseLimitFactor { get; protected set; }
	}
}

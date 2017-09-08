using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	public static class BankingHelper {
		public static Account CreateCustomerWithAccount(string name, AccountType type) {
			var bank = Bank.Instance;
			var customer = bank.CreateCustomer(name);
			return bank.CreateAccount(type, customer);
		}

		public static IEnumerable<Account> GetAccountsWithBalance(decimal balance) {
			return Bank.Instance.AllAcounts.Where(acc => acc.Balance > balance);
		}
	}
}

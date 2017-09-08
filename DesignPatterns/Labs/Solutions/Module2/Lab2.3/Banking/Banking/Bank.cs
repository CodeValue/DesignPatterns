using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace Banking {
	[Export]
	public class Bank {
		readonly Dictionary<Guid, Account> _accounts = new Dictionary<Guid, Account>();
		readonly List<Customer> _customers = new List<Customer>();

		[Import]
		IAccountFactory _accountFactory;

		[Import]
		ICustomerFactory _customerFactory;

		private Bank() {
		}

		public Account CreateAccount(AccountType type, Customer customer) {
			Account acc = _accountFactory.CreateAccount(type, customer);
			if(acc != null) {
				_accounts.Add(acc.AccountNumber, acc);
				acc.Customer = customer;
				customer.AddAccount(acc);
			}
			return acc;
		}

		public Account OpenAccount(Guid number) {
			return _accounts[number];
		}

		public void UpdateAccounts() {
			foreach(var acc in _accounts.Values) {
				var sav = acc as SavingsAccount;
				if(sav != null)
					sav.AddInterest();
			}
		}

		public IEnumerable<Account> GetAccountsForCustomer(Customer customer) {
			return _accounts.Values.Where(acc => acc.Customer == customer);
		}

		public Customer CreateCustomer(string name) {
			var customer = _customerFactory.CreateCustomer(name);
			customer.Bank = this;
			_customers.Add(customer);
			return customer;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	public class Bank {
		readonly Dictionary<Guid, Account> _accounts = new Dictionary<Guid, Account>();
		readonly List<Customer> _customers = new List<Customer>();

		private static readonly Bank _bank = new Bank();

		public static Bank Instance {
			get
			{
				return _bank;
			}
		}

		private Bank() {
		}

		public bool EnableLogging { get; set; }

		public Account CreateAccount(AccountType type, Customer customer) {
			IAccountFactory factory = new DefaultAccountFactory();
			Account acc = factory.CreateAccount(type, customer);
			if(acc != null) {
				_accounts.Add(acc.AccountNumber, acc);
				acc.Customer = customer;
				customer.AddAccount(acc);
			}
			return EnableLogging ? new TracingAccount(acc) { Logger = Console.Out } : acc;
		}

		public Account OpenAccount(Guid number) {
			var acc = _accounts[number];
			return acc;
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
			ICustomerFactory factory = new NameCustomerFactory();
			var customer = factory.CreateCustomer(name);
			_customers.Add(customer);
			return customer;
		}

		internal IEnumerable<Account> AllAcounts {
			get {
				return _accounts.Values;
			}
		}
	}
}

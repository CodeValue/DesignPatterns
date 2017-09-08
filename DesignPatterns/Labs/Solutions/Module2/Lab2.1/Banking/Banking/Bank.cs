using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	public enum AccountType {
		CheckingAccount, SavingsAccount
	}

	public class Bank {
		readonly Dictionary<Guid, Account> _accounts = new Dictionary<Guid, Account>();

		private static readonly Bank _bank = new Bank();

		public static Bank Instance {
			get { return _bank; }
		}

		private Bank() {
		}

		public Account CreateAccount(AccountType type) {
			Account acc = null;
			switch(type) {
				case AccountType.CheckingAccount:
					var chk = new CheckingAccount(Guid.NewGuid());
					chk.WithdrawLimit = 2500;
					acc = chk;
					break;

				case AccountType.SavingsAccount:
					var sav = new SavingsAccount(Guid.NewGuid());
					sav.InterestRate = (new Random().Next(5) + 1) / 100.0;
					acc = sav;
					break;
			}
			if(acc != null)
				_accounts.Add(acc.AccountNumber, acc);
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
	}
}

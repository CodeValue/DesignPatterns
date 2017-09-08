using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking {
	public enum AccountType {
		CheckingAccount, SavingsAccount
	}

	interface IAccountFactory {
		Account CreateAccount(AccountType type, Customer customer);
	}
}

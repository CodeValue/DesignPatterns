using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Banking;

namespace BankingApp {
	class Program {
		static void Main(string[] args) {
			Bank bank = Bank.Instance;
			var acc1 = bank.CreateAccount(AccountType.CheckingAccount);
			acc1.Deposit(200);
			acc1.Withdraw(50);
			Console.WriteLine(acc1.Balance);

			var acc2 = bank.CreateAccount(AccountType.SavingsAccount);
			acc2.Deposit(1000);

			Console.WriteLine(acc2.Balance);
			bank.UpdateAccounts();
			Console.WriteLine(acc2.Balance);
		}
	}
}

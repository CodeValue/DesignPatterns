using System;
using Banking;

namespace BankingApp {
	class Program {
		static void Main(string[] args) {
			Bank bank = Bank.Instance;
			var bart = bank.CreateCustomer("Bart");
			var acc1 = bank.CreateAccount(AccountType.CheckingAccount, bart);
			acc1.Deposit(200);
			acc1.Withdraw(50);
			Console.WriteLine(acc1.Balance);

			bank.EnableLogging = true;

			var acc2 = bank.CreateAccount(AccountType.SavingsAccount, bart);
			acc2.Deposit(1000);

			Console.WriteLine(acc2.Balance);
			bank.UpdateAccounts();
			Console.WriteLine(acc2.Balance);

			Console.WriteLine("accounts for {0}:", bart.Name);
			foreach(var account in bart.Accounts)
				Console.WriteLine(account.Balance);

			// create a VIP account
			Customer vip = bank.CreateCustomer("Homer Dumdum Simpson");
			var vipacc = bank.CreateAccount(AccountType.CheckingAccount, vip);
			vipacc.Deposit(10000);
			vipacc.Withdraw(4000);
			Console.WriteLine("VIP Balance: {0}", vipacc.Balance);

			var acc4 = BankingHelper.CreateCustomerWithAccount("Peter Parker", AccountType.SavingsAccount);
			acc4.Deposit(1000);

			foreach(var acc in BankingHelper.GetAccountsWithBalance(900))
				Console.WriteLine("{0}: {1}", acc.Customer.Name, acc.Balance);
		}
	}
}

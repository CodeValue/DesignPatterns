using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Banking;
using System.ComponentModel.Composition.Hosting;

namespace BankingApp {
	class Program {
		public static CompositionContainer Container { get; private set; }

		static void Main(string[] args) {
			var catalog = new AssemblyCatalog(typeof(Bank).Assembly);
			var container = new CompositionContainer(catalog);
			Container = container;

			Bank bank = container.GetExportedValue<Bank>();
			var bart = bank.CreateCustomer("Bart");
			var acc1 = bank.CreateAccount(AccountType.CheckingAccount, bart);
			acc1.Deposit(200);
			acc1.Withdraw(50);
			Console.WriteLine(acc1.Balance);

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
		}
	}
}

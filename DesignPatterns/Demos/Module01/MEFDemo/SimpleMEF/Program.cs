using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace SimpleMEF {
	class Program {
		static void Main(string[] args) {
			AssemblyCatalog catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
			CompositionContainer container = new CompositionContainer(catalog);
			
			var acc = new Account();
			container.ComposeParts(acc);
			acc.Deposit(200);
			Console.WriteLine("Balance: {0}", acc.Balance);

			// alternative
			var acc2 = container.GetExportedValue<Account>();
			acc2.Deposit(100);
			Console.WriteLine("Balance: {0}", acc.Balance);

		}
	}
}

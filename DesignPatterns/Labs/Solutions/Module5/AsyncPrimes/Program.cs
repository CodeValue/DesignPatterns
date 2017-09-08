using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AsyncPrimes {
	class Program {
		static void Main(string[] args) {
			var calculator = new AsyncPrimeCalculator();
			var ev = new AutoResetEvent(false);
			calculator.BeginCalculate(3, 1000000, ar => {
				var result = calculator.EndCalculate(ar);
				Console.WriteLine("Primes: {0}", result.Count());
				ev.Set();
			}, null);
			Console.WriteLine("Doing something else...");
			ev.WaitOne();
			Console.WriteLine("Done.");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ParallelPrimes {
	class Program {
		static void Main(string[] args) {
			var sw = Stopwatch.StartNew();
			var result = CalcPrimes(3, 10000000, 1);
			sw.Stop();
			Console.WriteLine("Elapsed with deg 1: {0}", sw.ElapsedMilliseconds);
			sw.Restart();
			result = CalcPrimes(3, 10000000);
			sw.Stop();
			Console.WriteLine("Elapsed with deg -1: {0}", sw.ElapsedMilliseconds);
		}

		static IEnumerable<int> CalcPrimes(int first, int last, int degree = -1) {
			var options = new ParallelOptions { MaxDegreeOfParallelism = degree };
			var list = new List<int>(1024);
			Parallel.For(first, last, options, i => {
				int limit = (int)Math.Sqrt(i);
				bool prime = true;
				for(int j = 2; j <= limit; j++)
					if(i % j == 0) {
						prime = false;
						break;
					}
				if(prime)
					lock(list)
						list.Add(i);
			});
			return list;
		}
	}
}

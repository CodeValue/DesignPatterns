using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsyncPrimes {
	class AsyncPrimeCalculator {
		static IEnumerable<int> CalcPrimes(int from, int to) {
			var list = new List<int>();
			for(int i = from; i <= to; i++) {
				bool isprime = true;
				int limit = (int)Math.Sqrt(i);
				for(int j = 2; j <= limit; j++)
					if(i % j == 0) {
						isprime = false;
						break;
					}
				if(isprime)
					list.Add(i);
			}
			return list;
		}

		static Func<int, int, IEnumerable<int>> _delegate = CalcPrimes;

		public IAsyncResult BeginCalculate(int from, int to, AsyncCallback callback, object state) {
			return _delegate.BeginInvoke(from, to, callback, state);
		}

		public IEnumerable<int> EndCalculate(IAsyncResult ar) {
			return _delegate.EndInvoke(ar);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;

namespace ProducerConsumer {
	class Program {
		static void Main(string[] args) {
			BlockingCollection<int> coll = new BlockingCollection<int>(new ConcurrentQueue<int>());

			ThreadPool.QueueUserWorkItem(_ => {
				Console.WriteLine(coll.Take());
				foreach(int n in coll.GetConsumingEnumerable())
					Console.WriteLine("{0} {1}", n, DateTime.Now.TimeOfDay.TotalSeconds);
			});

			Random r = new Random();
			for(int i = 0; i < 50; i++) {
				Thread.Sleep(r.Next(1000));
				coll.Add(i);
				Console.WriteLine("Doing something...");
			}
		}
	}
}

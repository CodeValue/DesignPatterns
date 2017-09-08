using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace SimpleMEF {
	[Export(typeof(ILogger))]
	class ConsoleLogger : ILogger {
		#region ILogger Members

		public void Log(string message) {
			Console.WriteLine("{0}: {1}", DateTime.Now.ToLongTimeString(), message);
		}

		#endregion
	}
}

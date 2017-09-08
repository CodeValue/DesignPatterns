using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddinHost {
	public interface ILogger {
		void Log(string message);
	}

	public interface IAddIn {
		string Name { get; }
		void Init();
	}
}

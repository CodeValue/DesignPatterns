using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddinHost;
using System.ComponentModel.Composition;

namespace SimpleAddin2 {
	[Export(typeof(IAddIn))]
	public class Addin2 : IAddIn {
		public Addin2() {
			Console.WriteLine("Addin2 ctor");
		}

		[Import]
		public ILogger Logger { get; private set; }

		#region IAddIn Members

		public void Init() {
			Logger.Log("SimpleAddIn2 started");
		}

		public string Name {
			get { return "Addin 2"; }
		}

		#endregion
	}
}

using System;
using AddinHost;
using System.ComponentModel.Composition;

namespace SampleAddin1 {
	[Export(typeof(IAddIn))]
	public class Addin1 : IAddIn {
		[Import]
		public ILogger Logger { get; private set; }

		public Addin1() {
			Console.WriteLine("Addin1 ctor");
		}

		#region IAddIn Members

		public void Init() {
			Logger.Log("SimpleAddIn1 Started");
		}

		public string Name {
			get { return "Addin 1"; }
		}

		#endregion
	}
}

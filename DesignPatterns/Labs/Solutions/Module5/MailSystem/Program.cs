using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MailSystem {
	class Program {
		static void Main(string[] args) {
			MailManager mgr = new MailManager();

			mgr.MailArrived += OnNewMail;
			mgr.MailArrived += (s, e) => {
				Console.WriteLine("Arrived {0}", e.Body);
			};

			mgr.SimulateMailArrived();

//			mgr.MailArrived -= OnNewMail;
			mgr.SimulateMailArrived();

			#region Simulation
			using(Timer t = new Timer(delegate {
				mgr.SimulateMailArrived();
				}, null, new Random().Next(1000) + 400, 1000)) {

				Thread.Sleep(10000);
			}
			#endregion
		}

		#region Handler method
		public static void OnNewMail(object sender, MailArrivedEventArgs e) {
			Console.WriteLine("Mail arrived at {2}: {0} Contents: {1}", 
				e.Title, e.Body, DateTime.Now.ToLongTimeString());
		}
		#endregion
	}
}

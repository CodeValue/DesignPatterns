using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace APM {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Starting...");
			var wr = WebRequest.Create("http://msdn.microsoft.com");
			wr.Method = "HEAD";
			wr.BeginGetResponse(ar => {
				var response = wr.EndGetResponse(ar);
				string headers = ParseHeaders(response);
				Console.WriteLine(headers);
			}, null);
			Console.WriteLine("Doing other stuff...");
			Console.ReadLine();
		}

		static string ParseHeaders(WebResponse response) {
			var headers = from header in response.Headers.Keys.Cast<string>()
							  select string.Format("{0}: {1}", header, response.Headers[header]);
			return string.Join(Environment.NewLine, headers.ToArray());
		}
	}
}

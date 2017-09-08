using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace CustomAttributes {
	class Program {
		static void Main() {
			Console.WriteLine("All Code Approved: {0}",
				AnalyzeAssembly(Assembly.GetExecutingAssembly()));
			AnalyzeAssembly(typeof(string).Assembly);
		}

		static bool AnalyzeAssembly(Assembly asm) {
			bool approved = true;
			foreach(Type t in asm.GetTypes()) {
				object[] attrs = t.GetCustomAttributes(typeof(CodeReviewAttribute), false);
				Console.WriteLine("Code review for type {0} ({1} reviewers)", t.Name, attrs.Length);
				foreach(CodeReviewAttribute cra in attrs) {
					Console.WriteLine("Code Review: Name: {0}, Date: {1}, Approved: {2}",
						cra.Name, cra.ReviewDate.ToShortDateString(), cra.Approved);
					approved = approved && cra.Approved;
				}
				Console.WriteLine();
			}
			return approved;
		}
	}

}

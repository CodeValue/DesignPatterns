using System;
using System.IO;

namespace Mod1.Ex1 {
	class EmployeeDisplay : IEmployeeDisplay {
		#region IEmployeeDisplay Members

		public void Display(Employee emp, TextWriter writer) {
			writer.WriteLine("Employee: {0}: {1}, {2}", emp.Id, emp.LastName, emp.FirstName);
		}

		#endregion
	}
}

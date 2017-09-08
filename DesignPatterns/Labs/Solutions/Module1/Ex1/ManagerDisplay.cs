using System;
using System.IO;

namespace Mod1.Ex1 {
	class ManagerDisplay : IEmployeeDisplay {
		#region IEmployeeDisplay Members

		public void Display(Employee emp, TextWriter writer) {
			writer.WriteLine("Manager: {0}: {1}, {2}", emp.Id, emp.LastName, emp.FirstName);
		}

		#endregion
	}
}

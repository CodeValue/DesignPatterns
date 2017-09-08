using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Mod1.Ex1 {
	public static class PersonnelManager {
		public static void DisplayEmployees(Employee[] employees) {
			foreach(var emp in employees)
				emp.Display();
		}

		public static void WriteSalaries(Employee[] employees, string file) {
			FileStream fs = File.OpenWrite(file);
			StreamWriter writer = new StreamWriter(fs);
			foreach(var emp in employees)
				writer.WriteLine("{0}: {1}", emp.Id, emp.TotalSalary);
			writer.Close();
			fs.Close();
		}
	}
}

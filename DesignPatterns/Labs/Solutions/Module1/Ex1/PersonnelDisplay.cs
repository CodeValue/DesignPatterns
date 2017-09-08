using System;
using System.IO;

namespace Mod1.Ex1 {
	public class PersonnelDisplay {
		readonly PersonnelManager _mgr;

		public PersonnelDisplay(PersonnelManager mgr) {
			_mgr = mgr;
		}

		public void Display(TextWriter writer) {
			foreach(var emp in _mgr)
				DisplayFactory.CreateDisplay(emp).Display(emp, writer);
		}

		public void WriteSalaries(Stream stm) {
			using(StreamWriter writer = new StreamWriter(stm)) {
				WriteSalaries(writer);
			}
		}

		public void WriteSalaries(TextWriter writer) {
			foreach(var emp in _mgr)
				writer.WriteLine("{0}: {1}", emp.Id, emp.TotalSalary);
		}

		public void WriteSalaries(string path) {
			using(var fs = File.OpenWrite(path)) {
				WriteSalaries(fs);
			}
		}


	}
}

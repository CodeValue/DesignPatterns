using System;
using System.Collections.Generic;
using System.IO;

namespace Mod1.Ex1 {
	public class PersonnelManager : IEnumerable<Employee> {
		readonly List<Employee> _employees = new List<Employee>();
		static int _runningID;

		public void Add(Employee employee) {
			if(employee.Id == 0)
				employee.Id = ++_runningID;
			_employees.Add(employee);
		}

		public void AddRange(IEnumerable<Employee> employees) {
			foreach(var emp in employees)
				Add(emp);
		}

		public void Remove(Employee employee) {
			_employees.Remove(employee);
		}

		public void DisplayEmployees(TextWriter output) {
			PersonnelDisplay display = new PersonnelDisplay(this);
			display.Display(output);
		}

		public void WriteSalaries(string path) {
			PersonnelDisplay display = new PersonnelDisplay(this);
			display.WriteSalaries(path);
		}

		#region IEnumerable<Employee> Members

		public IEnumerator<Employee> GetEnumerator() {
			return _employees.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		#endregion
	}
}

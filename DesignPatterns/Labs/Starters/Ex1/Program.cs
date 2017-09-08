using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mod1.Ex1 {
	class Program {
		static void Main(string[] args) {
			Employee[] emps = {
				new Employee(1) { FirstName = "Bart", LastName = "Simpson", BaseSalary = 1000 },
				new Employee(2) { FirstName = "Lisa", LastName = "Simpson", BaseSalary = 1200 },
				new Manager(100) { FirstName = "Clark", LastName = "Kent", BaseSalary = 2000, SalesPercentage = .2 },
				new Manager(101) { FirstName = "Homer", LastName = "Simpson", BaseSalary = 1500, SalesPercentage = .1 },
				new Employee(4) { FirstName = "Marge", LastName = "Simpson", BaseSalary = 1400 }
									};

			PersonnelManager.DisplayEmployees(emps);
			PersonnelManager.WriteSalaries(emps, @"c:\temp\salaries.dat");
		}
	}
}

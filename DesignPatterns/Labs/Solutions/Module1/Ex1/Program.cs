using System;

namespace Mod1.Ex1 {
	class Program {
		static void Main(string[] args) {
			Employee[] emps = {
				new Employee { FirstName = "Bart", LastName = "Simpson", BaseSalary = 1000 },
				new Employee { FirstName = "Lisa", LastName = "Simpson", BaseSalary = 1200 },
				new Manager { FirstName = "Clark", LastName = "Kent", BaseSalary = 2000, SalesPercentage = .2 },
				new Manager { FirstName = "Homer", LastName = "Simpson", BaseSalary = 1500, SalesPercentage = .1 },
				new Employee { FirstName = "Marge", LastName = "Simpson", BaseSalary = 1400 }
									};

			var personnel = new PersonnelManager();
			personnel.AddRange(emps);
			personnel.DisplayEmployees(Console.Out);
			personnel.WriteSalaries(@"c:\temp\salaries.dat");
			
			PersonnelDisplay display = new PersonnelDisplay(personnel);
			display.WriteSalaries(Console.Out);
		}
	}
}

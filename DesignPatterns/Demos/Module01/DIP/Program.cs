using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIP {
	class HelloHidden {
		public string Hello(string name) {
			if(DateTime.Now.Hour < 12) return "Good morning, " + name;
			else if(DateTime.Now.Hour < 18) return "Good afternoon, " + name;
			else return "Good evening, " + name;
		}
	}

	class HelloExplicit {
		readonly DateTime _dt;

		public HelloExplicit(DateTime dt) {
			_dt = dt;
		}

		public string Hello(string name) {
			if(_dt.Hour < 12) return "Good morning, " + name;
			else if(_dt.Hour < 18) return "Good afternoon, " + name;
			else return "Good evening, " + name;
		}
	}

	class Program {
		static void Main(string[] args) {
		}
	}
}

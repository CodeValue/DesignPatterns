using System;
using System.Runtime.Remoting;

namespace Proxy.Sample1 {
	class Program {
		static void Main() {
			// Create math proxy
			IMath math = MathFactory.GetMath();

			// Do the math
			Console.WriteLine("4 + 2 = " + math.Add(4, 2));
			Console.WriteLine("4 - 2 = " + math.Sub(4, 2));
			Console.WriteLine("4 * 2 = " + math.Mul(4, 2));
			Console.WriteLine("4 / 2 = " + math.Div(4, 2));
		}
	}

	static class MathFactory {
		public static IMath GetMath() {
			return new MathProxy();
		}
	}

	// The 'Subject' interface
	public interface IMath {
		double Add(double x, double y);
		double Sub(double x, double y);
		double Mul(double x, double y);
		double Div(double x, double y);
	}

	// The 'RealSubject' class
	class Math : MarshalByRefObject, IMath {
		public double Add(double x, double y) { return x + y; }
		public double Sub(double x, double y) { return x - y; }
		public double Mul(double x, double y) { return x * y; }
		public double Div(double x, double y) { return x / y; }
	}

	// The remote 'Proxy Object' class
	class MathProxy : IMath {
		private Math _math;

		public MathProxy() {
			// Create Math instance in a different AppDomain
			var ad = AppDomain.CreateDomain("MathDomain", null, null);
			_math = (Math)ad.CreateInstanceAndUnwrap(typeof(Math).Assembly.FullName, typeof(Math).FullName);
		}

		public double Add(double x, double y) {
			return _math.Add(x, y);
		}

		public double Sub(double x, double y) {
			return _math.Sub(x, y);
		}

		public double Mul(double x, double y) {
			return _math.Mul(x, y);
		}

		public double Div(double x, double y) {
			return _math.Div(x, y);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSP_Refactored2 {
	abstract class Shape {
		public abstract int Area { get; }
	}

	class Rectangle : Shape {
		public int Width { get; set; }
		public int Height { get; set; }

		public override int Area {
			get {
				return Width * Height;
			}
		}
	}

	class Square : Shape {
		public int Length { get; set; }

		public override int Area {
			get {
				return Length * Length;
			}
		} 
	}

}

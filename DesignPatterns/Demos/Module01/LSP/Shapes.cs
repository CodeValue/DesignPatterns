using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSP {
	class Rectangle {
		public virtual int Width { get; set; }
		public virtual int Height { get; set; }

		public virtual int Area {
			get {
				return Width * Height;
			}
		}
	}

	class Square : Rectangle {
		public override int Height {
			set {
				base.Height = value;
				base.Width = value;
			}
		}

		public override int Width {
			set {
				base.Height = value;
				base.Width = value;
			}
		}
	}

}

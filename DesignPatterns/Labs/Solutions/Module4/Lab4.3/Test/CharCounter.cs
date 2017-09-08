using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paragraphs;

namespace Test {
	class CharCounter : IParagraphEvents {
		#region IParagraphEvents Members

		public void ParagraphChanged(int length) {
			Console.WriteLine("{0} characters", length);
		}

		#endregion
	}
}

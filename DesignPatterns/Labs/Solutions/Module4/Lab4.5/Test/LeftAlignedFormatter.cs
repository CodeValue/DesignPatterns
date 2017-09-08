using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paragraphs;

namespace Test {
	class LeftLineFormatter : ILineFormat {
		#region ILineFormat Members

		public int GetSpacesForLine(int line) {
			return 0;
		}

		#endregion
	}

	class LeftAlignedFormatter : IParagraphFormatter {
		#region IParagraphFormatter Members

		public ILineFormat Format(Paragraph paragraph) {
			return new LeftLineFormatter();
		}

		#endregion
	}
}

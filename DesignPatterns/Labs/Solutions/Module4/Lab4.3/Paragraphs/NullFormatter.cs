using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paragraphs {
	class NullFormatter : IParagraphFormatter {
		#region IParagraphFormatter Members

		public ILineFormat Format(Paragraph paragraph) {
			return _default;
		}

		#endregion

		static ILineFormat _default = new DefaultLineFormatter();

		class DefaultLineFormatter : ILineFormat {
			#region ILineFormat Members

			public int GetSpacesForLine(int line) {
				return 0;
			}

			#endregion
		}
	}
}

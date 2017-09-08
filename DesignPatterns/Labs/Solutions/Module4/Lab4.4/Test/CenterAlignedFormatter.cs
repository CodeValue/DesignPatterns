using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paragraphs;

namespace Test {
	class CenterLineFormatter : ILineFormat {
		private Paragraph _para;
		int _maxLen;

		#region ILineFormat Members

		public int GetSpacesForLine(int line) {
			return (_maxLen - _para.GetLine(line).Length) / 2;
		}

		#endregion
		public CenterLineFormatter(Paragraph para) {
			_para = para;
			for(int i = 0; i < para.LinesCount; i++) {
				var len = _para.GetLine(i).Length;
				if(len > _maxLen)
					_maxLen = len;
			}
		}
	}

	class CenterAlignedFormatter : IParagraphFormatter {
		#region IParagraphFormatter Members

		public ILineFormat Format(Paragraph paragraph) {
			return new CenterLineFormatter(paragraph);
		}

		#endregion
	}
}

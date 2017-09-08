using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paragraphs {
	public interface ILineFormat {
		int GetSpacesForLine(int line);
	}

	public interface IParagraphFormatter {
		ILineFormat Format(Paragraph paragraph);
	}
}

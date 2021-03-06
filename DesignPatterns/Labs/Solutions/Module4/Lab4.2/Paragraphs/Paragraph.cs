﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paragraphs {
	sealed class ParagraphLine {
		public string Text { get; set; }
		public int Spaces { get; set; }
	}

	public class Paragraph {
		readonly List<ParagraphLine> _lines = new List<ParagraphLine>();

		public Paragraph() {
			Formatter = new NullFormatter();
		}

		public IParagraphFormatter Formatter { get; set; }

		public void Add(string text) {
			_lines.Add(new ParagraphLine { Text = text });
			Format();
		}

		public string GetLine(int i) {
			return _lines[i].Text;
		}

		public int LinesCount {
			get { return _lines.Count; }
		}

		private void Format() {
			var format = Formatter.Format(this);
			for(int i = 0; i < _lines.Count; i++)
				_lines[i].Spaces = format.GetSpacesForLine(i);
		}

		public override string ToString() {
			return string.Join(Environment.NewLine, _lines.Select(line => line.Text)); 
		}
	}
}

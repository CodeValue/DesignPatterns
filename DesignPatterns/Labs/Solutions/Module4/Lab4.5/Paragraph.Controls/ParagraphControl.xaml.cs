using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Paragraphs.Controls {
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class ParagraphControl : UserControl {
		Paragraph _para = new Paragraph();

		public ParagraphControl() {
			InitializeComponent();
		}

		public void Append(string text) {
			_para.Add(text);
		}

		public IParagraphFormatter Formatter {
			get { return (IParagraphFormatter)GetValue(FormatterProperty); }
			set { SetValue(FormatterProperty, value); }
		}

		public static readonly DependencyProperty FormatterProperty =
			 DependencyProperty.Register("Formatter", typeof(IParagraphFormatter), typeof(ParagraphControl), new UIPropertyMetadata(null,
				 (s, e) => {
					 var ctl = s as ParagraphControl;
					 Debug.Assert(ctl != null);
					 ctl._para.Formatter = (IParagraphFormatter)e.NewValue;
				 }));


	}
}

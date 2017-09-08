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
using System.Net;
using System.Threading;

namespace AsyncUI {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void OnGetData(object sender, RoutedEventArgs e) {
			var wr = WebRequest.Create("http://msdn.microsoft.com");
			wr.Method = "HEAD";
			_data.Text = string.Empty;
			var sc = SynchronizationContext.Current;
			wr.BeginGetResponse(ar => {
				var response = wr.EndGetResponse(ar);
				string headers = ParseHeaders(response);
				sc.Post(delegate {
					_data.Text = headers;
				}, null);
			}, null);
		}

		private string ParseHeaders(WebResponse response) {
			var headers = from header in response.Headers.Keys.Cast<string>()
							  select string.Format("{0}: {1}", header, response.Headers[header]);
			return string.Join(Environment.NewLine, headers.ToArray());
		}
	}
}

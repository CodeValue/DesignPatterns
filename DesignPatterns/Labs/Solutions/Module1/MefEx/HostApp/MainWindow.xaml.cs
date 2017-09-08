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
using System.ComponentModel.Composition;

namespace HostApp {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		AddinManager _mgr;

		public MainWindow(AddinManager mgr) {
			InitializeComponent();

			DataContext = _mgr = mgr;
		}

		private void OnInit(object sender, RoutedEventArgs e) {
			_mgr.InitAddins();
		}

		private void OnDoWork(object sender, RoutedEventArgs e) {
			_mgr.DoWork();
		}
	}
}

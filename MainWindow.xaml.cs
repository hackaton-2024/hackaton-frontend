using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sad
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			AdjustWindowToAllScreens(this);
			SourceInitialized += OnSourceInitialized;
			MainContent.Content = new LoginPage();
		}
		private void OnSourceInitialized(object sender, EventArgs e)
		{
			AdjustWindowToAllScreens(this);
		}

		private void AdjustWindowToAllScreens(Window window)
		{
			// Initialize with primary screen size
			var minLeft = SystemParameters.VirtualScreenLeft;
			var minTop = SystemParameters.VirtualScreenTop;
			var maxRight = SystemParameters.VirtualScreenLeft + SystemParameters.VirtualScreenWidth;
			var maxBottom = SystemParameters.VirtualScreenTop + SystemParameters.VirtualScreenHeight;

			// Set window position and size
			window.Left = minLeft;
			window.Top = minTop;
			window.Width = maxRight - minLeft;
			window.Height = maxBottom - minTop;

			window.WindowState = WindowState.Maximized;
		}

	}
}


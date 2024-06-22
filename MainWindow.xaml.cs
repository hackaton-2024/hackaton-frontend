using sad.Services;
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
			LoadTokenAndNavigate();
			//MainContent.Content = new LoginPage();
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
			/*			window.Left = minLeft;
						window.Top = minTop;*/
			window.Width = 450;
			window.Height = 600;

			window.WindowState = WindowState.Maximized;
		}


		//TOKENS
		private void LoadTokenAndNavigate()
		{
			var token = TokenManager.GetToken();
			if (token != null)
			{
				ApiClient.SetBearerToken(token);
				NavigateToHomePage();
			}
			else
			{
				NavigateToLoginPage();
			}
		}

		public void NavigateToHomePage()
		{
			MainContent.Content = new HomePage();
		}

		public void NavigateToLoginPage()
		{
			MainContent.Content = new LoginPage();
		}

	}
}


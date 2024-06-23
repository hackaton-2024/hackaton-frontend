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
	/// Interaction logic for HomePage.xaml
	/// </summary>
	public partial class HomePage : UserControl
	{
		public HomePage()
		{
			InitializeComponent();
		}

		private void LogoutButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Сигурни ли сте че искате да излезете от профила си?", "Потвърждение за излизане", MessageBoxButton.YesNo, MessageBoxImage.Question);

			if(result == MessageBoxResult.Yes)
			{
				TokenManager.DeleteTokens();

				var parent = this.Parent as ContentControl;
				if (parent != null)
				{
					parent.Content = new LoginPage();
				}
			}
        }
    }
}

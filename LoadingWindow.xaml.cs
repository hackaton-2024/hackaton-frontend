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
using System.Windows.Shapes;

namespace sad
{
	/// <summary>
	/// Interaction logic for LoadingWindow.xaml
	/// </summary>
	public partial class LoadingWindow : Window
	{
		public LoadingWindow()
		{
			InitializeComponent();
			StartProgress();
			
		}


		public async void StartProgress()
		{
			// Simulate a task with a progress bar
			for (int i = 0; i <= 100; i++)
			{
				progressBar.Value = i;
				await Task.Delay(2); // Simulate some work being done
			}

			// Once the task is complete, open the main window and close this one
			OpenMainWindow();
		}

		private void OpenMainWindow()
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close();
		}
	}
}

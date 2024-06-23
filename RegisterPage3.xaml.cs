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
    /// Interaction logic for RegisterPage3.xaml
    /// </summary>
    public partial class RegisterPage3 : UserControl
    {
        public RegisterPage3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			var parent = this.Parent as ContentControl;
			if (parent != null)
			{
				parent.Content = new HomePage();
			}
		}
    }
}

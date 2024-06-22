using sad;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SwitchToRegisterPage1(); // Initially display UserControl1
        }

        private void SwitchToRegisterPage1()
        {
            var uc1 = new RegisterPage();
            uc1.SwitchRegisterPage2 += (s, e) => SwitchToRegisterPage2();
            MainContent.Content = uc1;
        }

        private void SwitchToRegisterPage2()
        {
            var uc2 = new RegisterPage2();
            uc2.SwitchToRegisterPage3 += (s, e) => SwitchToRegisterPage3();
            MainContent.Content = uc2;
        }

        private void SwitchToRegisterPage3()
        {
            var uc3 = new RegisterPage3();
            MainContent.Content = uc3;
        }
    }
}
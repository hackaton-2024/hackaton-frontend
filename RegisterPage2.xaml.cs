using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class OptionItem
    {
        public string Description { get; set; }
        public bool IsSelected { get; set; }
    }
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        public void Execute(object parameter) => _execute();

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
    public class MainViewModel : INotifyPropertyChanged
    {
        private OptionItem _selectedOption;

        public ObservableCollection<OptionItem> Options { get; set; }

        public OptionItem SelectedOption
        {
            get => _selectedOption;
            set
            {
                _selectedOption = value;
                OnPropertyChanged();
            }
        }

        public ICommand NextStepCommand { get; }

        public MainViewModel()
        {
            Options = new ObservableCollection<OptionItem>
            {
                new OptionItem { Description = "Детска градина" },
                new OptionItem { Description = "Училище" },
                new OptionItem { Description = "Университет" },
                new OptionItem { Description = "Дом за деца от семеен тип" },
                new OptionItem { Description = "Дом за възрастни с увреждания" }
            };

            NextStepCommand = new RelayCommand(NextStep);
        }

        private void NextStep()
        {
            if (SelectedOption != null)
            {
                System.Windows.MessageBox.Show($"Selected: {SelectedOption.Description}");
            }
            else
            {
                System.Windows.MessageBox.Show("No option selected.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    /// <summary>
    /// Interaction logic for RegisterPage2.xaml
    /// </summary>
    public partial class RegisterPage2 : UserControl
    {
        public RegisterPage2()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			var parent = this.Parent as ContentControl;
			if (parent != null)
			{
				parent.Content = new RegisterPage3();
			}
		}
    }
}

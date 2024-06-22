﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sad
{
    /// <summary>
    /// Interaction logic for LoadingPage.xaml
    /// </summary>
    public partial class LoadingPage : UserControl
    {
        public LoadingPage()
        {
            InitializeComponent();
            loadprogressbar();
        }
        private void loadprogressbar()
        {
            Duration dur = new Duration(TimeSpan.FromSeconds(30));
            DoubleAnimation dblani = new DoubleAnimation(200.0, dur);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, dblani);
        }

    }
}
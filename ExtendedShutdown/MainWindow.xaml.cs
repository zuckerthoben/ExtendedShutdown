// <copyright file="MainWindow.xaml.cs" company="Christoph Nienaber">
// Copyright (c) Christoph Nienaber. All rights reserved.
// </copyright>

namespace ExtendedShutdown
{
    using System.Runtime.InteropServices.ComTypes;
    using System.Windows;
    using ExtendedShutdown.ViewModels;
    using ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.DataContext = this.viewModel = new MainViewModel();
            this.InitializeComponent();
        }

        private void ShutdownButton_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.Shutdown();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.Restart();
        }

        private void LogOffButton_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.LogOff();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.Cancel();
        }
    }
}

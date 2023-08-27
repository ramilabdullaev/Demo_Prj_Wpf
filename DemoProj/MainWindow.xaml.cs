using DemoProj.Data;
using DemoProj.Model;
using DemoProj.ViewModel;
using System;
using System.Windows;

namespace DemoProj
{
    public partial class MainWindow : Window
    {
        private readonly CustomersViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new CustomersViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += CustomersView_Loaded;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private async void ButtonAddUstomer_Click(object sender, RoutedEventArgs e)
        {
            await _viewModel.Add();
        }

        private async void ButtonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            await _viewModel.Delete();
        }
    }
}

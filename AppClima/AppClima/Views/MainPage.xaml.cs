using AppClima.ViewModels;
using Microsoft.Maui.Controls;

namespace AppClima.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = BindingContext as MainPageViewModel;
            viewModel?.OnSearchTextChanged(sender, e);
        }



    }
}

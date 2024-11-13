using AppClima.Models;
using AppClima.Services;
using AppClima.ViewModels;
using Microsoft.Maui.Controls;

namespace AppClima.Views
{
    public partial class WeatherDetailPage : ContentPage
    {
        public WeatherDetailPage(Cidade cidade)
        {
            InitializeComponent();

            BindingContext = new WeatherDetailViewModel(new WeatherService(), cidade);
        }
    }
}

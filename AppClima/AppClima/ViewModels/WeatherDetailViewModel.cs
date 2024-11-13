using AppClima.Models;
using AppClima.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppClima.ViewModels
{
    public class WeatherDetailViewModel : BaseViewModel
    {
        private readonly WeatherService _weatherService;
        public Previsao Previsao { get; set; }
        public Cidade Cidade { get; set; }

        public ICommand ObterPrevisaoParaUmDiaCommand { get; }
        public ICommand ObterPrevisaoParaSeisDiasCommand { get; }

        public WeatherDetailViewModel(WeatherService weatherService, Cidade cidade)
        {
            _weatherService = weatherService;
            Cidade = cidade;
            ObterPrevisaoParaUmDiaCommand = new Command(async () => await ObterPrevisaoAsync(1));
            ObterPrevisaoParaSeisDiasCommand = new Command(async () => await ObterPrevisaoAsync(6));
        }

        private async Task ObterPrevisaoAsync(int days)
        {
            Previsao = await _weatherService.ObterPrevisaoAsync(Cidade.Id.ToString(), days);
            OnPropertyChanged(nameof(Previsao)); 
        }

    }
}

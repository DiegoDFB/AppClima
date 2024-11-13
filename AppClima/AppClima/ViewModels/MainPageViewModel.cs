using AppClima.Models;
using AppClima.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppClima.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly WeatherService _weatherService;
        public ObservableCollection<Cidade> Cidades { get; } = new();
        public ObservableCollection<Cidade> CidadesFiltradas { get; set; } = new();

        private string _textoPesquisa;
        public string TextoPesquisa
        {
            get => _textoPesquisa;
            set
            {
                SetProperty(ref _textoPesquisa, value);
                OnSearchTextChanged();
            }
        }

        public ICommand ObterCidadesCommand { get; }

        private Cidade _cidadeSelecionada;
        public Cidade CidadeSelecionada
        {
            get => _cidadeSelecionada;
            set
            {
                SetProperty(ref _cidadeSelecionada, value);
                if (_cidadeSelecionada != null)
                    SelecionarCidade(_cidadeSelecionada);
            }
        }
        public MainPageViewModel() : this(new WeatherService()) { }

        public MainPageViewModel(WeatherService weatherService)
        {
            _weatherService = weatherService;
            ObterCidadesCommand = new Command(async () => await ObterCidadesAsync());
        }

        private async Task ObterCidadesAsync()
        {
            var cidades = await _weatherService.ObterCidadesAsync();
            foreach (var cidade in cidades)
                Cidades.Add(cidade);

            CidadesFiltradas = new ObservableCollection<Cidade>(Cidades);
        }

        private void SelecionarCidade(Cidade cidade)
        {
        }

        public void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var textoPesquisa = e.NewTextValue?.ToLower();
            if (string.IsNullOrEmpty(textoPesquisa))
            {
                CidadesFiltradas.Clear();
                foreach (var cidade in Cidades)
                {
                    CidadesFiltradas.Add(cidade);
                }
            }
            else
            {
                var cidadesFiltradas = Cidades.Where(c => c.Nome.ToLower().Contains(textoPesquisa) || c.Estado.ToLower().Contains(textoPesquisa)).ToList();
                CidadesFiltradas.Clear();
                foreach (var cidade in cidadesFiltradas)
                {
                    CidadesFiltradas.Add(cidade);
                }
            }

            OnPropertyChanged(nameof(CidadesFiltradas));
        }



    }
}

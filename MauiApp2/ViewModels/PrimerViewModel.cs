using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MauiApp2.Servicios;
using Location = MauiApp2.Models.Location;

namespace MauiApp2.ViewModels;

    public class PrimerViewModel : INotifyPropertyChanged
    {
        private readonly IRickAndMortyService _rickAndMortyService;

        public PrimerViewModel(IRickAndMortyService service)
        {
            _rickAndMortyService = service;
            LoadData();
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private ObservableCollection<Location> _locations = new ObservableCollection<Location>();
        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set { SetProperty(ref _locations, value); }
        }

        

        public async Task LoadData()
        {
            IsLoading = true;
            var data = await _rickAndMortyService.ObtenerLocalizacion();
            Locations = new ObservableCollection<Location>(data);
            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }

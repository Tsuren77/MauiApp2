using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MauiApp2.Models;
using MauiApp2.Servicios;

namespace MauiApp2.ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    private readonly IRickAndMortyService _rickAndMortyService;
    public event PropertyChangedEventHandler PropertyChanged;
    private bool _isLoading;
    private ObservableCollection<Personajes> _personajes = new ObservableCollection<Personajes>();
    
    public HomeViewModel(IRickAndMortyService service)
    {
        _rickAndMortyService = service;
        LoadData();
    }
    public bool IsLoading
    {
        get { return _isLoading; }
        set { SetProperty(ref _isLoading, value); }
    }

    public ObservableCollection<Personajes> Personajes
    {
        get { return _personajes; }
        set { SetProperty(ref _personajes, value); }
    }

    public async Task LoadData()
    {
        IsLoading = true;
        var data = await _rickAndMortyService.Obtener();
        if (data != null && data.results != null)
        {
            _personajes.Clear();
            foreach (var result in data.results)
            {
                _personajes.Add(new Personajes
                {
                    info = data.info,
                    results = new[] { result }
                });
            }
        }
        IsLoading = false;
    }
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected bool SetProperty<T>(ref T backingStore, T value,[CallerMemberName] string propertyName = "",Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;
        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    } 
    public async Task LoadMoreData()
    {
        string nextUrl = _personajes.LastOrDefault()?.info?.next;
        if (!string.IsNullOrEmpty(nextUrl))
        {
            var data = await _rickAndMortyService.ObtenerMas(nextUrl);
            if (data != null && data.results != null)
            {
                foreach (var result in data.results)
                {
                    _personajes.Add(new Personajes
                    {
                        info = data.info,
                        results = new[] { result }
                    });
                }
            }
        }
    }


}

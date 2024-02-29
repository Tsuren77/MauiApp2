using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp2.Models;
using MauiApp2.Servicios;

namespace MauiApp2.ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    private readonly IRickAndMortyService _rickAndMortyService;

    public HomeViewModel(IRickAndMortyService service)
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

    private ObservableCollection<Personajes> _personajes = new ObservableCollection<Personajes>();
    public ObservableCollection<Personajes> Personajes
    {
        get { return _personajes; }
        set { SetProperty(ref _personajes, value); }
    }

    

    public async Task LoadData()
    {
        IsLoading = true;
        var data = await _rickAndMortyService.Obtener();
        Personajes = new ObservableCollection<Personajes>(data);
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
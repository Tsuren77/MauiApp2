using MauiApp2.Models;
using MauiApp2.Servicios;
using MauiApp2.ViewModels;

namespace MauiApp2.View;

public partial class HomeView : ContentPage
{
    private readonly HomeViewModel _viewModel;
    public HomeView(IRickAndMortyService service)
    {
        InitializeComponent();
        _viewModel = new HomeViewModel(service);
        BindingContext = _viewModel;
    }
    private async void OnPersonajeTapped(object sender, EventArgs e)
    {
        var frame = sender as Frame;
        var personaje = frame.BindingContext as Personajes;
        await Navigation.PushAsync(new DetailView(personaje));
    }
    private async void OnLoadMoreClicked(object sender, EventArgs e)
    {
        await _viewModel.LoadMoreData();
    }
}
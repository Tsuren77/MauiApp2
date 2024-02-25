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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadData();
    }
}


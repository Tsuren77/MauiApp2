using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp2.Servicios;
using MauiApp2.ViewModels;

namespace MauiApp2.View;

public partial class HomeView : ContentPage
{
    private readonly IRickAndMortyService _rickAndMortyService;

    public HomeView(IRickAndMortyService service)
    {
        InitializeComponent();
        _rickAndMortyService = service;
        BindingContext = new HomeViewModel(_rickAndMortyService);
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await ((HomeViewModel)BindingContext).LoadData();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp2.Servicios;
using MauiApp2.ViewModels;

namespace MauiApp2.View;

public partial class PrimerNivelView : ContentPage
{
    private readonly PrimerViewModel _viewModel;
    public PrimerNivelView(IRickAndMortyService service)
    {
        InitializeComponent();
        _viewModel = new PrimerViewModel(service);
        BindingContext = _viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadData();
    }
    
    
}
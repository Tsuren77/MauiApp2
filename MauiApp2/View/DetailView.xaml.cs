using MauiApp2.ViewModels;

namespace MauiApp2.View;

public partial class DetailView : ContentPage
{
    public DetailView(DetailViewModel detailViewModel)
    {
        InitializeComponent();
        BindingContext = detailViewModel;
    }
}
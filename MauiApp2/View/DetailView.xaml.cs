using MauiApp2.Models;

namespace MauiApp2.View;
public partial class DetailView : ContentPage
    {
        public DetailView(Personajes personaje)
        {
            InitializeComponent();
            BindingContext = personaje;
        }

    }

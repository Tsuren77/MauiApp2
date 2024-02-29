using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp2.ViewModels;

namespace MauiApp2.View;

public partial class AboutView : ContentPage
{
    public AboutView(AboutViewModel aboutViewModel)
    {
        InitializeComponent();
        BindingContext = aboutViewModel;

    }
}
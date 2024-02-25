using MauiApp2.View;

namespace MauiApp2;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        InitializeRouting();
    }

    private static void InitializeRouting()
    {
        Routing.RegisterRoute("home/detail", typeof(DetailView));
    }
}
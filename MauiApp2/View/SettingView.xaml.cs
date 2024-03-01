using MauiApp2.ViewModels;

namespace MauiApp2.View
{
    public partial class SettingView : ContentPage
    {
        private readonly SettingViewModel _viewModel;

        public SettingView()
        {
            InitializeComponent();
            _viewModel = new SettingViewModel(); 
            BindingContext = _viewModel;
        }

        private void BtnIdiomaEspañol_Clicked(object sender, EventArgs e)
        {
            
        }

        private void BtnIdiomaIngles_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
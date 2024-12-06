using BTGClientManagerMauiRest.ViewModels;

namespace BTGClientManagerMauiRest
{
    public partial class MainPage : ContentPage
    {
        public MainPage(ClientViewModel clientViewModel)
        {
            InitializeComponent();
            BindingContext = clientViewModel;
        }
    }
}

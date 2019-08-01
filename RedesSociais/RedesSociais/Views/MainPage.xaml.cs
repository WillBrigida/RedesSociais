using RedesSociais.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RedesSociais.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }
    }
}
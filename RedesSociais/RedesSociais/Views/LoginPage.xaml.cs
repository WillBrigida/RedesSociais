using RedesSociais.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RedesSociais.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
           
        }

        private void Senha_Focused(object sender, FocusEventArgs e)
        {
            
            if (e.IsFocused == true)
            {
                FacebookButton.IsVisible = false;
                GoogleButton.IsVisible = false;
            }
            else
            {
                FacebookButton.IsVisible = true;
                GoogleButton.IsVisible = true;
            }
        }

       
        private void Login_Focused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused == true)
            {
                FacebookButton.IsVisible = false;
                GoogleButton.IsVisible = false;
            }
            else
            {
                FacebookButton.IsVisible = true;
                GoogleButton.IsVisible = true;
            }
        }
    }
}
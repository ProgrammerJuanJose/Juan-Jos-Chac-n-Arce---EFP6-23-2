using FinalExamApp.ViewModels;
using FinalExamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalExamApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BienvenidaPage : ContentPage
    {
        UserViewModel viewModel;
        public BienvenidaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
            LoadUserAsync();
        }

        private async void LoadUserAsync()
        {
            PkrUser.ItemsSource = await viewModel.GetUserAsync();
        }

        private async void BtnIngreso_Clicked(object sender, EventArgs e)
        { 
            await Navigation.PushAsync(new PreguntaPage());
        }

        private async void BtnPreguntas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerPreguntasPage());
        }
    }
}
using FinalExamApp.Models;
using FinalExamApp.ViewModels;
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
    public partial class PreguntaPage : ContentPage
    {
        UserViewModel viewModel;
        public PreguntaPage()
        {
            InitializeComponent();
            //LoadUserName();
        }

        //private void LoadUserName()
        //{
        //    LblUserName.Text = GlobalObjects.MyLocalUser.Nombre.ToUpper();
        //}

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //Capturar el rol que se haya seleccionado en el picker
            User SelectedUser = PkrUser.SelectedItem as User;
            AskStatus SelectedStatus = PkrStatus.SelectedItem as AskStatus;

            bool R = await viewModel.AddAskAsync(TxtAsk.Text.Trim(),
                                                 TxtAskDetail.Text.Trim());

            if (R)
            {
                await DisplayAlert(":)", "Ask created Ok!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Something went wrong!", "OK");
            }


        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OlaMundoPCL
{
    public partial class MainPage : ContentPage
    {
        int alertCount = 0;

        public MainPage()
        {
            InitializeComponent();

            btnSecondPage.Clicked += BtnSecondPage_Clicked;
            btnModal1.Clicked += BtnModal1_Clicked;
            btnAlert1.Clicked += BtnAlert1_Clicked;
            btnActionSheet1.Clicked += BtnActionSheet1_Clicked;
        }

        private async void BtnActionSheet1_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Opções", "Cancelar", null, "Inserir", "Editar", "Excluir");
            btnActionSheet1.Text = action;
        }

        private async void BtnAlert1_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Title", "Message...", "OK");
            alertCount++;
            btnModal1.Text = $"Alert({alertCount})";
        }

        //private void BtnAlert1_Clicked(object sender, EventArgs e)
        //{
        //    DisplayAlert("Title", "Message...", "OK");
        //    alertCount++;
        //    btnModal1.Text = $"Alert({alertCount})";
        //}

        private void BtnModal1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ModalPage1());
        }

        private void BtnSecondPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondPage());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OlaMundoPCL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            btnVoltar.Clicked += BtnVoltar_Clicked;
            btnModal1.Clicked += BtnModal1_Clicked;
        }

        private void BtnModal1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ModalPage1());
        }

        private void BtnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            lblTitle.Text = "Use Button Up or Voltar!";            
            return base.OnBackButtonPressed();
        }
    }
}
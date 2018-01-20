using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace anima1
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            btnEsconder.Clicked += BtnEsconder_Clicked;
            btnMostrar.Clicked += BtnMostrar_Clicked;
            btnCancelar.Clicked += BtnCancelar_Clicked;
		}

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            ViewExtensions.CancelAnimations(imagem);
        }

        private async void BtnMostrar_Clicked(object sender, EventArgs e)
        {
            await Task.WhenAll(
                imagem.ScaleTo(1, 1000), //1x em 1 segundo
                imagem.RotateTo(360, 1000) //360° em 1 segundo
                );
        }

        private async void BtnEsconder_Clicked(object sender, EventArgs e)
        {
            await Task.WhenAll(
                imagem.ScaleTo(0, 1000),
                imagem.RotateTo(-360, 1000) 
                );
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}

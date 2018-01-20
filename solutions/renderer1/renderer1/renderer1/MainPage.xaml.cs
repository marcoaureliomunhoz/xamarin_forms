using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace renderer1
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
        {
            InitializeComponent();

            btnEntrar.Clicked += BtnEntrar_Clicked;
        }

        private void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            DisplayAlert(txtNome.Text, "Olá que tal?", "OK");
        }
    }
}

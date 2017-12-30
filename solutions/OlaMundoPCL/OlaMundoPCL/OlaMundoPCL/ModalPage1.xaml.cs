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
    public partial class ModalPage1 : ContentPage
    {
        public ModalPage1()
        {
            InitializeComponent();
            btnVoltar.Clicked += BtnVoltar_Clicked;
        }

        private void BtnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
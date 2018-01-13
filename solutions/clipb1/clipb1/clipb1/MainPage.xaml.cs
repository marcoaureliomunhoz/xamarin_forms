using clipb1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace clipb1
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            btnCopiar.Clicked += BtnCopiar_Clicked;
		}

        private void BtnCopiar_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IClipboardService>().SetText(txtTexto.Text);
        }
    }
}

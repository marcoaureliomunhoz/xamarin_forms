using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pcl_nivel1_app1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (btnCliqueAqui!=null)
            {
                btnCliqueAqui.Clicked += BtnCliqueAqui_Clicked;
            }
        }

        private void BtnCliqueAqui_Clicked(object sender, EventArgs e)
        {
            lblNome.Text = txtNome.Text;
        }
    }
}

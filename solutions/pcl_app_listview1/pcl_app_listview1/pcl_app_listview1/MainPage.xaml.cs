using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pcl_app_listview1
{
    public partial class MainPage : ContentPage
    {
        private string[] _editoras = { "novatec", "Excel Books", "Brasport" };

        public MainPage()
        {
            InitializeComponent();

            listEditoras.ItemsSource = _editoras;
            listEditoras.ItemTapped += ListEditoras_ItemTapped;
        }

        private void ListEditoras_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Editora", e.Item.ToString(), "OK");
            (sender as ListView).SelectedItem = null;
        }
    }
}

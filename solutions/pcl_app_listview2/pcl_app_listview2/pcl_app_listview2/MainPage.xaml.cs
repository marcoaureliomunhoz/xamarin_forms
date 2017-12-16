using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pcl_app_listview2
{
    public partial class MainPage : ContentPage
    {
        private List<Editora> _editoras;

        public MainPage()
        {
            InitializeComponent();

            _editoras = new List<Editora>
            {
                new Editora {
                    Codigo = 1,
                    Nome = "novatec",
                    Site = "www.novatec.com.br"
                },
                new Editora
                {
                    Codigo = 2,
                    Nome = "Excel Books",
                    Site = "www.excelbooks.com"
                }
            };

            listViewEditoras.ItemsSource = _editoras;

            var template = new DataTemplate(typeof(TextCell));
            template.SetBinding(TextCell.TextProperty, "Nome");
            template.SetBinding(TextCell.DetailProperty, "Site");
            template.SetValue(TextCell.TextColorProperty, Color.Red);
            template.SetValue(TextCell.DetailColorProperty, Color.Blue);
            listViewEditoras.ItemTemplate = template;

            listViewEditoras.ItemTapped += ListViewEditoras_ItemTapped;
        }

        private void ListViewEditoras_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var editora = (Editora)e.Item;
            DisplayAlert("Editora", editora.Nome, "OK");
            (sender as ListView).SelectedItem = null;
        }
    }
}

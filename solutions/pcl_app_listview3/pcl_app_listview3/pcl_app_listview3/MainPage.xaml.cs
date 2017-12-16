using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pcl_app_listview3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            listViewEditoras.ItemsSource = new Editora[] {
                new Editora
                {
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
            listViewEditoras.ItemTemplate = new DataTemplate(typeof(EditoraListViewCell));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pcl_app_navdrawer1
{
    public class NavigationDrawer : MasterDetailPage
    {
        public NavigationDrawer()
        {
            Title = "Navigation Drawer";
            string[] itensMenu = { "Main", "PageX", "PageY" };

            ListView listView = new ListView
            {
                ItemsSource = itensMenu
            };
            this.Master = new ContentPage
            {
                Title = "Opções",
                Content = listView
            };
            listView.ItemTapped += ListView_ItemTapped;
            Detail = new NavigationPage(new MainPage());
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ContentPage pagina;
            switch (e.Item.ToString())
            {
                case "Main":
                    pagina = new MainPage();
                    break;
                case "PageX":
                    pagina = new PageX();
                    break;
                case "PageY":
                    pagina = new PageY();
                    break;
                default:
                    pagina = new MainPage();
                    break;
            }
            Detail = new NavigationPage(pagina);
            (sender as ListView).SelectedItem = null;
            this.IsPresented = false;
        }
    }
}

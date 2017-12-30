using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pcl_app_tabpage1
{
    public class TabPage : TabbedPage
    {
        public TabPage()
        {
            this.Title = "Titulo da Página";
            this.Children.Add(new MainPage() { Title = "Main" });
            this.Children.Add(new PageX() { Title = "PageX" });
            this.Children.Add(new PageY() { Title = "PageY" });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pcl_app_listview3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditoraListViewCell : ViewCell
    {
        public EditoraListViewCell()
        {
            InitializeComponent();

            lblNome.SetBinding(Label.TextProperty, nameof(Editora.Nome));
            lblCodigo.SetBinding(Label.TextProperty, nameof(Editora.Codigo));
            lblSite.SetBinding(Label.TextProperty, nameof(Editora.Site));

            var detalhesAction = new MenuItem { Text = "Detalhes" };
            detalhesAction.Clicked += DetalhesAction_Clicked;

            var excluirAction = new MenuItem { Text = "Excluir", IsDestructive = true };
            excluirAction.Clicked += ExcluirAction_Clicked;

            ContextActions.Add(detalhesAction);
            ContextActions.Add(excluirAction);
        }

        private void DetalhesAction_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Detalhes");
        }

        private void ExcluirAction_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Excluindo");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appsqlite1
{
    public partial class MainPage : ContentPage
    {
        TorcedorDB db;

        public MainPage()
        {
            InitializeComponent();

            db = new TorcedorDB();

            btnCarregar.Clicked += BtnCarregar_Clicked;
            btnSalvar.Clicked += BtnSalvar_Clicked;
            btnExcluir.Clicked += BtnExcluir_Clicked;
        }

        private async void BtnExcluir_Clicked(object sender, EventArgs e)
        {
            var daSim = await DisplayAlert("Atenção", "Confirma a exclusão?", "Sim", "Não");
            if (daSim)
            {
                int codigo = 0;
                Int32.TryParse(txtCodigo.Text, out codigo);
                if (codigo > 0)
                {
                    if (db.Excluir(codigo))
                    {
                        await DisplayAlert("Sucesso!", "O registro foi excluído com sucesso.", "OK");
                        txtCodigo.Text = "";
                        txtNome.Text = "";
                        txtTime.Text = "";
                    }
                    else
                    {
                        await DisplayAlert("Ops!", "Não foi possível excluir o registro.", "OK");
                    }
                }
            }
        }

        private void BtnSalvar_Clicked(object sender, EventArgs e)
        {
            int codigo = 0;
            Int32.TryParse(txtCodigo.Text, out codigo);
            var torcedor = new Torcedor();
            torcedor.Codigo = codigo;
            torcedor.Nome = txtNome.Text;
            torcedor.Time = txtTime.Text;
            if (db.Salvar(torcedor))
            {
                txtCodigo.Text = torcedor.Codigo.ToString();
                DisplayAlert("Sucesso!", "O registro foi salvo com sucesso.", "OK");
            }
            else
            {
                DisplayAlert("Ops!", "Não foi possível salvar o registro.", "OK");
            }
        }

        private void BtnCarregar_Clicked(object sender, EventArgs e)
        {
            int codigo = 0;
            Int32.TryParse(txtCodigo.Text, out codigo);
            if (codigo > 0)
            {
                var torcedor = db.GetTornecedor(codigo);
                if (torcedor != null)
                {
                    txtNome.Text = torcedor.Nome;
                    txtTime.Text = torcedor.Time;
                }
            }
            else
            {
                txtCodigo.Text = "";
                txtNome.Text = "";
                txtTime.Text = "";
            }
        }
    }
}

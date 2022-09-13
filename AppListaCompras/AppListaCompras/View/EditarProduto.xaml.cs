using AppListaCompras.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaCompras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarProduto : ContentPage
    {
        public EditarProduto()
        {
            InitializeComponent();
        }

        // Toda utilização de await exige um método async
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                // TypeCast "(Produto)" necessário, pois o BindingContext é genérico
                Produto produto_anexado = BindingContext as Produto;

                Produto p = new Produto

                {
                    // Id = ((Produto) BindingContext).Id

                    Id = produto_anexado.Id,
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                };

                await App.Database.Update(p);

                await DisplayAlert("Sucesso!", "Produto Editado", "OK");

                await Navigation.PushAsync(new Lista());

            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "Ok");
            }

        }
    }
}
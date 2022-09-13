using AppListaCompras.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaCompras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        // Propriedade global da classe
        ObservableCollection<Produto> lista_produtos = new ObservableCollection<Produto>();

        public Lista()
        {
            InitializeComponent();

            lst_produtos.ItemsSource = lista_produtos;
        }

        private void ToolbarItem_Clicked_Novo(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new NovoProduto());

            } catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "Ok");
            }
            
        }

        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {
            // Função soma, somando cada item com seu preço multiplicado pela quantidade
            double soma = lista_produtos.Sum(i => i.Preco * i.Quantidade);

            string msg = "O total da compra é: " + soma;

            // Infomando o usuário
            DisplayAlert("Total!", msg, "OK");
        }

        protected override void OnAppearing()
        {

            if (lista_produtos.Count == 0)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {
                    List<Produto> temp = await App.Database.GetAll();

                    foreach (Produto item in temp)
                    {
                        lista_produtos.Add(item);
                    }

                    // Retirando o reloading da tela após carregar os registros
                    carregando.IsRefreshing = false;

                });

            }
         
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem disparador = (MenuItem)sender;

            Produto produto_selecionado = (Produto)disparador.BindingContext;

            // Pergunta e espera a confirmação do usuário sobre o delete do item (await)
            bool confirmacao = await DisplayAlert("Tem certeza?", "Remover item?", "Sim", "Nao");

            if(confirmacao)
            {
                // Exclusão do banco de dados
                await App.Database.Delete(produto_selecionado.Id);

                // Exclusão da lista na interface 
                lista_produtos.Remove(produto_selecionado);

            }

        }
    }
}
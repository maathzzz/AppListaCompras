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
    public partial class Lista : ContentPage
    {
        public Lista()
        {
            InitializeComponent();
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

        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}
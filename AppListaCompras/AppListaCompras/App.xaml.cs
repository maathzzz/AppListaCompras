using AppListaCompras.Helper;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper database;
        // Acesso direto ao SQLite pela propriedade database
        // Classe que fornece os métodos de gerenciamento do arquivo SQLiteDatabaseHelper.cs
        public static SQLiteDatabaseHelper Database
        {           

            get
            {
                if(database == null)
                {
                    // Definir string para ser o caminho:

                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "arquivo.db3"
                        );

                    database = new SQLiteDatabaseHelper(path);
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}

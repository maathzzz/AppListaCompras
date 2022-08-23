using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppListaCompras.Model; 
using SQLite;

namespace AppListaCompras.Helper
{
    public class SQLiteDatabaseHelper

        /**
         * 
         */
    {
        readonly SQLiteAsyncConnection _conn;

        /**
         * 
         */

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        /**
         * 
         */

        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }
        
        /**
         * 
         */

        public void Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE id= ? ";

            _conn.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }

        /**
         * Continuar aqui!      
         */   

        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        /*
         * faz o delete para cada item na tabela; onde o id do item é igual ao id recebido como parâmetro
         */

        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
    }
}

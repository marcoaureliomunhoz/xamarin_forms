using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace appsqlite1
{
    public class TorcedorDB
    {
        private SQLiteConnection db;

        public TorcedorDB()
        {
            db = DependencyService.Get<IDatabase>().GetConnection();
            db.CreateTable<Torcedor>();
        }

        public Torcedor GetTornecedor(int codigo)
        {
            return db.Table<Torcedor>().FirstOrDefault(x => x.Codigo == codigo);
        }

        public bool Salvar(Torcedor cadastro)
        {
            if (cadastro.Codigo > 0)
            {
                return db.Update(cadastro) > 0;                
            }
            else
            {
                db.Insert(cadastro);
                return cadastro.Codigo > 0;
            }
        }

        public bool Excluir(int codigo)
        {
            return db.Delete<Torcedor>(codigo) > 0;
        }
    }
}

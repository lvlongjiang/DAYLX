using EFContext;
using IRepositorySqlDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySqlDb
{
    public class RepositorySqlDbleave<T> : IRepositorySqlDbleave<T> where T : class, new()
    {
        private readonly MyDbContext db;

        public RepositorySqlDbleave(MyDbContext db)
        {
            this.db = db;
        }







    }
}

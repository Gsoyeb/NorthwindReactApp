using NorthwindReactApp.Infrastructure.Data;
using NorthwindReactApp.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindReactApp.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }   // Setting Category is private so that you would not be able to set Category values directly but get is public
        public IProductRepository Product { get; private set; }


        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db;

            Category = new CategoryRepository(this._db);
            Product = new ProductRepository(this._db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

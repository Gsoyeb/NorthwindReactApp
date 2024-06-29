using NorthwindReactApp.Domain.Entities;
using NorthwindReactApp.Infrastructure.Data;
using NorthwindReactApp.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindReactApp.Infrastructure.Repository
{
    public class ProductRepository : Repo<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) { 
            this._db = db;  
        }

        public void Update(Product product)
        {
            this.Update(product);
        }
    }
}

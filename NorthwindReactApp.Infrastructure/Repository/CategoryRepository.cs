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
    public class CategoryRepository : Repo<Category>, ICategoryRepository   // Class inheritance from repo<T> (in this case Category).  When you inherit, you inherit everything: fields, properties, methods
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)   // passing db parameter that we got from ApplicationDbContext db and using it to invoke Repo<Category> constructor
        {
            this._db = db;
        }

        public void Update(Category category)
        {
            this._db.Update(category);
        }

    }
}

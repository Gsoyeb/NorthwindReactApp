using NorthwindReactApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindReactApp.Infrastructure.Repository.IRepository
{
    public interface ICategoryRepository : IRepo<Category>
    {
        void Update(Category category);
    }
}

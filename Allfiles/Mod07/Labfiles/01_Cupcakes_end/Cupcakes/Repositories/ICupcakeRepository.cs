using Cupcakes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cupcakes.Repositories
{
    public interface ICupcakeRepository
    {
        IEnumerable<Cupcake> GetCupcakes();
        Cupcake GetCupcakeById(int id);
        void CreateCupcake(Cupcake cupcake);
        void DeleteCupcake(int id);
        void SaveChanges();
        bool CupcakeExists(int id);
        IQueryable<Bakery> PopulateBakeriesDropDownList();
    }
}

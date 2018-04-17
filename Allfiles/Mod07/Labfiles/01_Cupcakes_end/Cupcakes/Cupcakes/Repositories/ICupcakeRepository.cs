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
        void CreateCupcake();
        void DeleteCupcake(int id);
        void UpdateCupcake(int id);
    }
}

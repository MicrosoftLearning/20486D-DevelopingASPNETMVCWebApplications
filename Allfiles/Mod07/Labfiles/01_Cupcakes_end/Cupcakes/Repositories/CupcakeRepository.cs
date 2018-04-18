using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupcakes.Data;
using Cupcakes.Models;

namespace Cupcakes.Repositories
{
    public class CupcakeRepository : ICupcakeRepository
    {
        private CupcakeContext _context;

        public CupcakeRepository(CupcakeContext context)
        {
            _context = context;
        }

        public void CreateCupcake(Cupcake cupcake)
        {
            _context.Add(cupcake);
            _context.SaveChangesAsync();
        }

        public bool CupcakeExists(int id)
        {
            return _context.Cupcakes.Any(c => c.CupcakeId == id);
        }

        public void DeleteCupcake(int id)
        {
            var cupcake = _context.Cupcakes.SingleOrDefault(c => c.CupcakeId == id);
            _context.Cupcakes.Remove(cupcake);
            _context.SaveChangesAsync();
        }

        public Cupcake GetCupcakeById(int id)
        {
            return _context.Cupcakes.SingleOrDefault(c => c.CupcakeId == id);
        }

        public IEnumerable<Cupcake> GetCupcakes()
        {
            return _context.Cupcakes.ToList();
        }

        public void UpdateCupcake(Cupcake cupcake)
        {
            _context.Update(cupcake);
            _context.SaveChangesAsync();
        }
    }
}

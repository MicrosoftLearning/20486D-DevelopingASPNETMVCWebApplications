using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitiesWebsite.Models;

namespace CitiesWebsite.Services
{
    public interface ICityProvider : IEnumerable<KeyValuePair<string, City>>
    {
        City this[string name] { get; }
    }
}

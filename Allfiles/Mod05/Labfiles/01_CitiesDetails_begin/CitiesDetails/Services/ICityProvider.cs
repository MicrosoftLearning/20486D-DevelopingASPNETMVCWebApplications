using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesDetails.Services
{
    public interface ICityProvider : IEnumerable<KeyValuePair<string, CityDetails>>
    {
        CityDetails this[string name] { get; }
    }
}

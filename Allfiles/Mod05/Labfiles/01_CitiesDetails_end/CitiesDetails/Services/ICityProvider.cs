using System.Collections.Generic;

namespace CitiesDetails.Services
{
    public interface ICityProvider : IEnumerable<KeyValuePair<string, CityDetails>>
    {
        CityDetails this[string name] { get; }
    }
}
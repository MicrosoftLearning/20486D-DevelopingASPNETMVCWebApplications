using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewsExample.Services
{
    public interface IPersonProvider
    {
        List<Person> PersonList { get; }
    }
}

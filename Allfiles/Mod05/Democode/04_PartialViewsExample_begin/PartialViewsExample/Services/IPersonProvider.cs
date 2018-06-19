using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewsExample.Services
{
    public interface IPersonProvider
    {
        Person this[int index] { get; }
    }
}

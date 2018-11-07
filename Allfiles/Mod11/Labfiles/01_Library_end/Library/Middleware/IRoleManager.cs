using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Middleware
{
    interface IRoleManager
    {
       Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration);
    }
}

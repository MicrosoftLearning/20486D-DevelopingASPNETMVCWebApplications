using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRExample.Hubs
{
    public class SquaresHub : Hub
    {
        public async Task SwapColor(int rowIndex, int columnIndex)
        {
            await Clients.Others.SendAsync("SwapSquareColor", rowIndex, columnIndex);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRExample.Services
{
    public interface ISquareManager
    {
        string[,] GetSquares();
        void SwapColor(int x, int y);
    }
}

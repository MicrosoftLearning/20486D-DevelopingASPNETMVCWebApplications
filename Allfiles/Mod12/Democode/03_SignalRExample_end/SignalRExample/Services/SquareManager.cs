using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRExample.Services
{
    public class SquareManager : ISquareManager
    {
        private string[,] _squares;

        public SquareManager()
        {
            _squares = new string[3, 3]
            {
                { "blue","blue","blue" },
                { "blue","blue","blue" },
                { "blue","blue","blue" }
            };
        }

        public string[,] GetSquares()
        {
            return _squares;
        }

        public void SwapColor(int x, int y)
        {
            if(_squares[x, y] == "blue")
            {
                _squares[x, y] = "red";
            }
            else
            {
                _squares[x, y] = "blue";
            }
        }
    }
}

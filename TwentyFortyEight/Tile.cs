using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyFortyEight
{
    class Tile
    {
        public int Value { get; set; }

        public Tile(int value)
        {
            this.Value = value;
        }

        public bool IsFree()
        {
            return Value == 0;
        }

    }
}

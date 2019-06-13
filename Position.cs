using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Position //column and row together as a Field
    {
        public int row;
        public int column;

        public Position(int row,int column) // Constructor
        {
        this.row = row;
        this.column = column;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            int column = 3;
            int row = 3;
            int[,] table = new int[column, row];


            for( int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    table[i, j] = 0;
                    Console.WriteLine(table);
                }
            }
                


            //Console.WriteLine("Hello Player {0} it is your turn to select a column");
            //Console.WriteLine("Hello Player {0} it is your turn to select a row");
        }
    }
}

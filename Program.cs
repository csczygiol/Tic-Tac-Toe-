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
            bool PlayerOnesTurn = true;
            Field[,] table = new Field[column, row]; //The semicolon is used for a two dimensional array

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    table[i, j] = new Field();
                }
            }

            PrintTable(table);//Prints Array

            for(int turn = 0; turn < 9; turn ++)
            {
                bool FieldisPossessed = false;

                do
                {
                    Position position = ReadInput(PlayerOnesTurn);
                    if (PlayerOnesTurn)
                    {
                        FieldisPossessed = !table[position.column, position.row].SetStatus(Status.X); //Sets Player1 input
                    }
                    else
                    {
                        FieldisPossessed = !table[position.column, position.row].SetStatus(Status.O);//Sets Player2 input
                    }
                    if (FieldisPossessed)
                    {
                        Console.WriteLine("This Field is Possessed by Ghosts");
                    }
                }

                while (FieldisPossessed);//Solange das Feld nicht zugewiesen werden kann wird der vorgang wiederholt
                PlayerOnesTurn = !PlayerOnesTurn; // Dreht es um Player1 wird zu Player2 und wieder andersrum
                PrintTable(table);//Prints Array
            }
            
        }

        public static Position ReadInput(bool PlayerOnesTurn)
        {
            int column = 0;
            int row = 0;
            string Player = PlayerOnesTurn?"1":"2"; //Fragezeichenn ist kurzschreibweise von if, Wenn es true ist dann wird die Nummer die vor dem Doppelpunkt ist genommen, wenn nicht nimmt man die nach dem doppelpunkt
            bool isError = false;

            do
            {
                isError = false;
                try
                {
                    Console.WriteLine($"Hello Player {Player} it is your turn to select a column");//$ macht das man geschweifte klammern benutzen kann dessen input sich anpast.
                    column = Convert.ToInt32(Console.ReadLine());
                    isError = checkNumber(column);
                }
                catch (Exception)
                {
                    isError = true;
                    Console.WriteLine("Your Input was incorrect choose a Number between 1 and 3 for the column");
                }

            } while (isError);

            do
            {
                isError = false;
                try
                {
                    Console.WriteLine($"Hello Player {Player} it is your turn to select a row");
                    row = Convert.ToInt32(Console.ReadLine());
                    isError = checkNumber(row);
                }
                catch (Exception)
                {
                    isError = true;
                    Console.WriteLine("Your Input was incorrect choose a Number between 1 and 3 for the row");
                }

            } while (isError);

            return new Position(column -1,row -1);
        }

        public static bool checkNumber(int number)
        {
            if (number >= 1|| number <= 3)
            {
                return false;
            }

            return true;
        }

        public static void PrintTable(Field[,] table)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write("|");

                for (int j = 0; j < 3; j++)
                {
                    Console.Write(table[i,j].status + "|");
                    
                }
                Console.WriteLine();
                Console.WriteLine("_______");
            }
           
        }

    }
}

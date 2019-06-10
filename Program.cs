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
                Position position = null;

                do
                {
                    position = ReadInput(PlayerOnesTurn);
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
                        PrintTable(table);
                    }
                }

                while (FieldisPossessed);//Solange das Feld nicht zugewiesen werden kann wird der vorgang wiederholt
                PrintTable(table);//Prints Array
                //Methode runde klammern
                if (CheckWinner(table, PlayerOnesTurn,position))
                {
                    string Player = PlayerOnesTurn ? "X" : "O";
                    Console.WriteLine($" {Player} You lucky Bastard!! You Won!");
                    break;
                }
                PlayerOnesTurn = !PlayerOnesTurn; // Dreht es um Player1 wird zu Player2 und wieder andersrum
            }
            

        }

        public static Position ReadInput(bool PlayerOnesTurn)
        {
            int column = 0;
            int row = 0;
            string Player = PlayerOnesTurn?"X":"O"; //Fragezeichenn ist kurzschreibweise von if, Wenn es true ist dann wird die Nummer die vor dem Doppelpunkt ist genommen, wenn nicht nimmt man die nach dem doppelpunkt
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
            if (number >= 1 && number <= 3)
            {
                return false;
            }
            Console.WriteLine("Your Input was incorrect choose a Number between 1 and 3");
            return true; // IST DER FEHLER
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

        public static bool CheckWinner(Field[,] table, bool PlayerOnesTurn, Position position)
        {
            string player = "X";
            if (!PlayerOnesTurn)
            {
                player = "O";
            }
            //Console.WriteLine(table[position.column, 0].GetStatus().Equals(player) + " " + table[position.column, 0].GetStatus() + " " + player);
            if (table[position.column,0].GetStatus() == player && table[position.column, 1].GetStatus() == player && table[position.column, 2].GetStatus() == player) //&& vergleicht alle informationen/ & vergleicht nur die Zahlen
            {

                return true;
            }
            if (table[0, position.row].GetStatus() == player && table[1, position.row].GetStatus() == player && table[2, position.row].GetStatus() == player) //&& vergleicht alle informationen/ & vergleicht nur die Zahlen
            {

                return true;
            }
            if (table[0, 0].GetStatus() == player && table[1, 1].GetStatus() == player && table[2, 2].GetStatus() == player) //Diagonale 
            {

                return true;
            }
            if (table[2, 0].GetStatus() == player && table[1, 1].GetStatus() == player && table[0, 2].GetStatus() == player) //Diagonale 
            {

                return true;
            }

            return false;
        }

    }
}

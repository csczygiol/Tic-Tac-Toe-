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

            for (int i = 0; i < column; i++) //creating the Array / Gamespace
            {
                for (int j = 0; j < row; j++)
                {
                    table[i, j] = new Field();
                }
            }

            PrintTable(table);//Prints Array

            for(int turn = 0; turn < 9; turn ++) // Loop for amount of 9 turns
            {
                bool FieldisPossessed = false; //boolean for taken Positions, if a Position is possessed the Players can't use it anymore
                Position position = null;

                do
                {
                    position = ReadInput(PlayerOnesTurn);
                    if (PlayerOnesTurn)
                    {
                        FieldisPossessed = !table[position.column, position.row].SetStatus(Status.X); //Sets PlayerX input
                    }
                    else
                    {
                        FieldisPossessed = !table[position.column, position.row].SetStatus(Status.O);//Sets PlayerO input
                    }
                    if (FieldisPossessed)
                    {
                        Console.WriteLine("This Field is Possessed by Ghosts");// Gives answer that the Position is already taken
                        PrintTable(table);
                    }
                }

                while (FieldisPossessed);//Solange das Feld nicht zugewiesen werden kann wird der vorgang wiederholt //Till no Position is assigned the loop will go on
                PrintTable(table);//Prints Array
                //Methode runde klammern
                if (CheckWinner(table, PlayerOnesTurn,position)) //checks win condition by checking the Arrays position, which Players turn and if the winning condition is met
                {
                    string Player = PlayerOnesTurn ? "X" : "O"; // If Shortcut, if Player X or Players O turn
                    Console.WriteLine($" {Player} You lucky Bastard!! You Won!");
                    break; //game stops
                }
                PlayerOnesTurn = !PlayerOnesTurn; // Dreht es um Player1 wird zu Player2 und wieder andersrum //Switches it, Player X swaps to Player O and Player O swaps to Player X
            }
            

        }

        public static Position ReadInput(bool PlayerOnesTurn)
        {//Fragezeichenn ist kurzschreibweise von if, Wenn es true ist dann wird die Nummer die vor dem Doppelpunkt ist genommen, wenn nicht nimmt man die nach dem doppelpunkt
            int column = 0;
            int row = 0;
            string Player = PlayerOnesTurn?"X":"O"; //If shortcut, If Player X or Player O turn
            bool isError = false;

            do
            {
                isError = false;
                try
                {
                    Console.WriteLine($"Hello Player {Player} it is your turn to select a column");//$ macht das man geschweifte klammern benutzen kann dessen input sich anpast.
                    column = Convert.ToInt32(Console.ReadLine()); //Console reads column input
                    isError = checkNumber(column); //checks if number for column isn't to big or small and equals is error
                }
                catch (Exception)
                {
                    isError = true; // when number is to big or to small
                    Console.WriteLine("Your Input was incorrect choose a Number between 1 and 3 for the column");
                }

            } while (isError); //It will loop till the Error is fixed aka till the Player puts in a correct number

            do
            {
                isError = false;
                try
                {
                    Console.WriteLine($"Hello Player {Player} it is your turn to select a row");
                    row = Convert.ToInt32(Console.ReadLine());
                    isError = checkNumber(row); //checks if number for row isn't to big or small and equals is error
                }
                catch (Exception)
                {
                    isError = true; // when number is to big or to small
                    Console.WriteLine("Your Input was incorrect choose a Number between 1 and 3 for the row");
                }

            } while (isError); //It will loop till the Error is fixed aka till the Player puts in a correct number

            return new Position(column -1,row -1);
        }

        public static bool checkNumber(int number) // Method which checks if number is to big or to small
        {
            if (number >= 1 && number <= 3) // if number is bigger or equals one && number is smaller or equals 3
            {
                return false;
            }
            Console.WriteLine("Your Input was incorrect choose a Number between 1 and 3");
            return true; // IST DER FEHLER //If checknumber is true the number is incorrect
        }

        public static void PrintTable(Field[,] table) //array with additions
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

        public static bool CheckWinner(Field[,] table, bool PlayerOnesTurn, Position position) // Winning Conditions
        {
            string player = "X";
            if (!PlayerOnesTurn) // if PlayerOnesTurn isn't true the player X swaps to player O
            {
                player = "O";
            }
            //Console.WriteLine(table[position.column, 0].GetStatus().Equals(player) + " " + table[position.column, 0].GetStatus() + " " + player); was used to print if one of the certain parameters is true or false
            if (table[position.column,0].GetStatus() == player && table[position.column, 1].GetStatus() == player && table[position.column, 2].GetStatus() == player) //Vertical
            {

                return true;
            }
            if (table[0, position.row].GetStatus() == player && table[1, position.row].GetStatus() == player && table[2, position.row].GetStatus() == player) //Horizontal
            {

                return true;
            }
            if (table[0, 0].GetStatus() == player && table[1, 1].GetStatus() == player && table[2, 2].GetStatus() == player) //Diagonal 1
            {

                return true;
            }
            if (table[2, 0].GetStatus() == player && table[1, 1].GetStatus() == player && table[0, 2].GetStatus() == player) //Diagonal 2
            {

                return true;
            }

            return false;
        }
        //&& vergleicht alle informationen/ & vergleicht nur die Zahlen
    }
}

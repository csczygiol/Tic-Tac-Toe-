using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public enum Status
    {
        N = 0, //empty field
        X = 1, //Player one
        O = 2 //Player two
    }

    class Field
    {
        public Status status;

        public Field()//byte row, byte column
        {
            this.status = Status.N; // this ruft das Objekt selber auf
        }

        public bool SetStatus(Status status) // it is a void because we can't use return in this method
        {
            if(this.status != Status.N) //kleines status variable, großes Status Enum // Muss erst das überprüfen was eingespeichert ist
            {
                return false; //überprüfung ob ein Feld besetzt ist oder nicht besetzt ist // Checks if a Position is taken or not   
            }
            this.status = status;
            return true;
            
        }

        public string GetStatus() //Großes String Obejekt, kleines string Datentyp // Gets the Status of the Position if it is taken by X or O or if it is free
        {
            if (status == Status.N)
            {
                return "N";
            }
            if (status == Status.O)
            {
                return "O";
            }
            if (status == Status.X)
            {
                return "X";
            }
            return null;
        }
    }
}

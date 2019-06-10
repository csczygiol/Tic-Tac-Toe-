using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public enum Status
    {
        N = 0,
        X = 1,
        O = 2
    }

    class Field
    {
        public Status status;

        //readonly private byte Row;
        //readonly private byte Column;

        public Field()//byte row, byte column
        {
            this.status = Status.N; // this ruft das Objekt selber auf
            //this.Column = column;
            //this.Row = row;
        }
        //public byte GetColumn()
        //{
        //    return this.Column;
        //}
        //public byte GetRow()
        //{
        //    return this.Row;
        //}

        public bool SetStatus(Status status) // it is a void because we can't use return in this method
        {
            if(status != Status.N) //kleines status variable, großes Status Enum
            {
                this.status = status;
                return true;
            }
            return false; //überprüfung ob ein Feld besetzt ist oder nicht besetzt ist
        }
    }
}

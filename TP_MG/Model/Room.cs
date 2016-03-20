using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_MG.Model
{
    class Room
    {
        private int roomNumber;
        public int RoomNumber
        {
            get
            {
                return this.FloorNumber * 100 + this.roomNumber;
            }
            set
            {
                roomNumber = value;
            }
        }

        public int FloorNumber { get; set; }

        public override string ToString()
        {
            return String.Format("room  no. {0} a {1} floor", RoomNumber, FloorNumber);
        }
    }


    
}

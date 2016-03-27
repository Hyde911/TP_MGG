using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_MG.Model
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public Room (int roomNumber)
        {
            RoomNumber = roomNumber;
            FloorNumber = roomNumber / 100;
        }


        public override string ToString()
        {
            return String.Format("room no. {0} on {1} floor", RoomNumber, FloorNumber);
        }
    }


    
}

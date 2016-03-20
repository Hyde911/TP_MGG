using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_MG.Model
{
    class Reservation
    {
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public int ResID { get; set; }

        public Reservation (Customer customer, Room room, int resID)
        {
            this.Customer = customer;
            this.Room = room;
            this.ResID = resID;
        }

        public override string ToString()
        {
            return String.Format("Reservation no. {0} of {1} by customer: {2}", ResID, Room.ToString(), Customer.ToString());
        }
    }
}

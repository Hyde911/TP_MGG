using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_MG.Interfaces;
using TP_MG.Model;

namespace TP_MG.DataGens
{
    public class SmallDataGenerator : IDataGenerator
    {
        public void fillData(List<Customer> customers, Dictionary<int, Room> rooms, ObservableCollection<Reservation> reservations)
        {
            fillCustomers(customers);
            fillRooms(rooms);
            fillReservations(reservations);
        }

        public void fillCustomers(List<Customer> customers)
        {

        }

        public void fillRooms (Dictionary<int, Room> rooms)
        {

        }

        public void fillReservations (ObservableCollection<Reservation> reservations)
        {

        }
    }
}

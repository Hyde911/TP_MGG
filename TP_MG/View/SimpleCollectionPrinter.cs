using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_MG.Interfaces;
using TP_MG.Model;
using TP_MG.Repositories;

namespace TP_MG.View
{
    public class SimpleCollectionPrinter : IDataPrinter
    {
        public void printCollections(DataRepository repository)
        {
            Dictionary<int, Customer> customersMap = repository.getAllCustomers();
            List<Room> roomsList = repository.getAllRooms();
            ObservableCollection<Reservation> reservationList = repository.getAllReservations();

            foreach(KeyValuePair<int, Customer> customer in customersMap)
            {
                Console.WriteLine(customer.Key.ToString().PadLeft(2) + ": " +  customer.Value.ToString());
            }

            foreach(Room room in roomsList)
            {
                Console.WriteLine(room.ToString());
            }

            foreach (Reservation res in reservationList)
            {
                Console.WriteLine(res.ToString());
            }
    }
    }
}

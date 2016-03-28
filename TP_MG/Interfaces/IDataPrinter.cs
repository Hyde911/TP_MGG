using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_MG.Model;

namespace TP_MG.Interfaces
{
    public interface IDataPrinter
    {
        void printCustomers(Dictionary<int, Customer> customersMap);
        void printRooms(List<Room> roomsList);
        void printReservations(ObservableCollection<Reservation> reservationList);
        void printWarning(string warning);
    }
}

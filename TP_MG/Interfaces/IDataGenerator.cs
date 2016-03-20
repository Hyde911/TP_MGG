using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_MG.Model;

namespace TP_MG.Interfaces
{
   public interface IDataGenerator
    {
        void fillData(List<Customer> customers, Dictionary<int, Room> rooms, ObservableCollection<Reservation> reservations);
    }
}

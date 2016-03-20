using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_MG.Interfaces;
using TP_MG.Model;

namespace TP_MG.Repositories
{
    public class DataRepository
    {
        private List<Customer> customerList = new List<Customer>();
        private Dictionary<int, Room> roomsMap = new Dictionary<int, Room>();
        private ObservableCollection<Reservation> reservationList = new ObservableCollection<Reservation>();
        private IDataGenerator dataGenerator;

        public DataRepository(IDataGenerator aDataGenerator)
        {
            this.dataGenerator = aDataGenerator;
        }
    }
}

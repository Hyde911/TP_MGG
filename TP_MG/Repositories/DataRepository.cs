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
        private Dictionary<int, Customer> customersMap = new Dictionary<int, Customer>();
        private List<Room> roomsList = new List<Room>();
        private ObservableCollection<Reservation> reservationList = new ObservableCollection<Reservation>();

        internal void addCustomer(string v, object vip)
        {
            throw new NotImplementedException();
        }

        private IDataGenerator dataGenerator;

        public DataRepository(IDataGenerator aDataGenerator)
        {
            this.dataGenerator = aDataGenerator;
            aDataGenerator.fillData(customersMap,roomsList,reservationList);
            
        }

        public void addCustomer(string firstName, string lastName, category group)
        {
            if (!String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName))
            {
                customersMap.Add(customersMap.Keys.Max() + 1, new Customer(firstName, lastName, group));
            }
            else
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
        }

        public void addRoom(int roomNumber)
        {
            if (roomNumber >= 100 && roomNumber < 300)
            {
                roomsList.Add(new Room(roomNumber));
            }
            else
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
            
        }

        public void addReservation(Customer customer, Room room, DateTime arrivalDate, DateTime departureTime)
        {
            if (customersMap.ContainsValue(customer) && roomsList.Contains(room) && arrivalDate.CompareTo(new DateTime(2015,1,1)) > 0
                && arrivalDate.CompareTo(departureTime) > 0)
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
        }


        public void deleteCustomer(int customerNumber)
        {
            customersMap.Remove(customerNumber);
        }

        public Dictionary<int, Customer> getAllCustomers ()
        {
            return customersMap;
        }

        public List<Room> getAllRooms()
        {
            return roomsList;
        }

        public ObservableCollection<Reservation> getAllReservations()
        {
            return reservationList;
        }

        public Dictionary<int, Customer> getCustomersByLastName(string lastName)
        {
            if (String.IsNullOrEmpty(lastName))
            {
                throw new Exception("Incomplete or wrong parameters list");
            } 
            Dictionary<int, Customer> newList = new Dictionary<int, Customer>();
            foreach(KeyValuePair<int,Customer> entity in customersMap)
            {
                if (entity.Value.LastName.Equals(lastName))
                {
                    newList.Add(entity.Key, entity.Value);
                }
            }
            return newList;
        }

        public Dictionary<int, Customer> getCustomersByCategory(category group)
        {
            Dictionary<int, Customer> newList = new Dictionary<int, Customer>();
            foreach (KeyValuePair<int, Customer> entity in customersMap)
            {
                if (entity.Value.CustomerGroup.Equals(group))
                {
                    newList.Add(entity.Key, entity.Value);
                }
            }
            return newList;
        }
    }


}

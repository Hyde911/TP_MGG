using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
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
        private List<string> log = new List<string>();

        internal void addCustomer(string v, object vip)
        {
            throw new NotImplementedException();
        }

        private IDataGenerator dataGenerator;

        public DataRepository(IDataGenerator aDataGenerator)
        {
            reservationList.CollectionChanged += reservationsListAlteration;
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
            if (roomNumber < 100 || roomNumber >= 300 )
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
            else if (roomsList.Exists(room => room.RoomNumber == roomNumber))
            {
                throw new Exception("Same room number error");
            }
            else
            {
                roomsList.Add(new Room(roomNumber));
            }
        }

        public void addReservation(Customer customer, Room room, DateTime arrivalDate, DateTime departureDate)
        {
            if (customersMap.ContainsValue(customer) && roomsList.Contains(room) && arrivalDate.CompareTo(new DateTime(2015,1,1)) > 0
                && arrivalDate.CompareTo(departureDate) < 0)
            {
                int newResId = reservationList.Max((res) => res.ResID);
                reservationList.Add(new Reservation(customer, room, newResId, arrivalDate, departureDate));
            }
            else
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
        }

        public void deleteAllData()
        {
            customersMap.Clear();
            roomsList.Clear();
            reservationList.Clear();
            log.Clear();
        }


        public void deleteCustomer(int customerNumber)
        {
            customersMap.Remove(customerNumber);
        }

        public int getCustomerIdByFirstAndLastName(string firstName, string lastName)
        {
            int customerId = -1;
            foreach (KeyValuePair<int, Customer> cust in customersMap)
            {
                if (cust.Value.FirstName == firstName && cust.Value.LastName == lastName)
                {
                    customerId = cust.Key;
                }
            }
            return customerId;
        }

        public Dictionary<int, Customer> getAllCustomers ()
        {
            return customersMap;
        }

        public List<Room> getAllRooms()
        {
            return roomsList;
        }

        public void deleteRoom(int roomNumber)
        {
            int room2deleteIndex = roomsList.FindIndex(room => room.RoomNumber == roomNumber);
            if (room2deleteIndex >= 0)
            {
                roomsList.RemoveAt(room2deleteIndex);
            }
            else
            {
                throw new Exception("Niepoprawny numer pokoju");
            }
            
        }

        public ObservableCollection<Reservation> getAllReservations()
        {
            return reservationList;
        }

        public Customer getCustomerById(int id)
        {
            if (customersMap.ContainsKey(id))
            {
                return customersMap[id];
            }
            else
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
        }


        public Customer getCustomerByFirstAndLastName(string firstName, string lastName)
        {
            Customer customer = null;
            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName))
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
            else
            {
                foreach (KeyValuePair<int, Customer> cust in customersMap)
                {
                    if (cust.Value.FirstName == firstName && cust.Value.LastName == lastName)
                    {
                        customer = cust.Value;
                    }
                }
            }
            if (customer == null)
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
            return customer;
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

        public Room getRoomByNumber(int roomNumber)
        {
            if (roomsList.Exists((room) => room.RoomNumber == roomNumber)){
                return roomsList.Find((room) => room.RoomNumber == roomNumber);
            }
            else
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
        }

        public Reservation getReservationById (int id)
        {
            if (reservationList.Any((res) => res.ResID == id))
            {
               foreach(Reservation res in reservationList)
                {
                    if (res.ResID == id) { return res; }
                }
            }
            throw new Exception("Incomplete or wrong parameters list");
        }

        public ObservableCollection<Reservation> getReservationsByCustomerName(string lastName)
        {
            if (!customersMap.Any((cust) => cust.Value.LastName == lastName))
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
            ObservableCollection<Reservation> reservations = new ObservableCollection<Reservation>();
            foreach (Reservation reservation in reservationList)
            {
                if (reservation.Customer.LastName == lastName) reservations.Add(reservation);
            }

            return reservations;
        }

        public ObservableCollection<Reservation> getReservationsByCustomerId(int customerId)
        {
            if (!customersMap.ContainsKey(customerId))
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
            ObservableCollection<Reservation> reservations = new ObservableCollection<Reservation>();
            Customer customer = customersMap[customerId];
            foreach (Reservation reservation in reservationList)
            {
                if (reservation.Customer == customer) reservations.Add(reservation);
            }
            return reservations;
        }

        public ObservableCollection<Reservation> getReservationsByRoomNumber (int roomNumber)
        {
            if (!roomsList.Exists((room) => room.RoomNumber == roomNumber))
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
            ObservableCollection<Reservation> reservations = new ObservableCollection<Reservation>();
            foreach (Reservation reservation in reservationList)
            {
                if (reservation.Room.RoomNumber == roomNumber) reservations.Add(reservation);
            }
            return reservations;
        }

        public ObservableCollection<Reservation> getReservationsByTimeInterval(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom.CompareTo(dateTo) > 0)
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
            ObservableCollection<Reservation> reservations = new ObservableCollection<Reservation>();
            foreach (Reservation reservation in reservationList)
            {
                if (reservation.ArrivalDate.CompareTo(dateFrom) >= 0 && reservation.ArrivalDate.CompareTo(dateTo) <= 0) reservations.Add(reservation);
            }
            return reservations;
        }

        public void deleteReservationById(int resId)
        {
            if (!reservationList.Any((res) => res.ResID == resId))
            {
                throw new Exception("Incomplete or wrong parameters list");
            }
            else
            {
                reservationList.Remove(reservationList.FirstOrDefault((res) => res.ResID == resId));
            }
        }

        public List<string> getLog()
        {
            return log;
        }
        
        public void reservationsListAlteration(object sender, NotifyCollectionChangedEventArgs arg)
        {
            if (arg.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Reservation res in arg.NewItems)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(DateTime.Now.ToShortDateString() + " ");
                    str.Append(DateTime.Now.ToShortTimeString());
                    str.Append(" reservation added: " + res.ToString());
                    log.Add(str.ToString());
                }
            }
            if (arg.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Reservation res in arg.OldItems)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(DateTime.Now.ToShortDateString() + " ");
                    str.Append(DateTime.Now.ToShortTimeString());
                    str.Append(" reservation removed: " + res.ToString());
                    log.Add(str.ToString());
                }
            }
        }
    }
}

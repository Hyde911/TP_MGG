using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_MG.Interfaces;
using TP_MG.Model;
using TP_MG.Repositories;
using TP_MG.View;

namespace TP_MG.Services
{
    public class DataService
    {
        private DataRepository data;
        private IDataPrinter printer;


        public DataService(DataRepository data)
        {
            this.data = data;
            printer = new SimpleCollectionPrinter();
        }

        public void setDataPrinter(IDataPrinter printer)
        {
            if (printer != null)
            {
                this.printer = printer;
            }
        }

        public void printAllData()
        {
            printer.printCustomers(data.getAllCustomers());
            printer.printRooms(data.getAllRooms());
            printer.printReservations(data.getAllReservations());
        }

        public void printRooms()
        {
            printer.printRooms(data.getAllRooms());
        }

        public void printCustomers()
        {
            printer.printCustomers(data.getAllCustomers());
        }

        public void printReservation()
        {
            printer.printReservations(data.getAllReservations());
        }

        public void printCustomersByName(string lastName)
        {
            Dictionary<int, Customer> customers = data.getCustomersByLastName(lastName);
            if (customers.Count() == 0)
            {
                printer.printWarning("Brak klienta o podanym nazwisku");
            }
            else
            {
                printer.printCustomers(customers);
            }
        }

        public void printCustomerByGroup(category group)
        {
            printer.printCustomers(data.getCustomersByCategory(group));
        }

        public void printReservationByRoomNumber(int roomNumber)
        {
            try
            {
                printer.printReservations(data.getReservationsByRoomNumber(roomNumber));
            }
            catch
            {
                printer.printWarning("Brak pokoju o podanym numerze");
            }
        }

        public void printReservationByCustomerId(int customerId)
        {
            try
            {
                printer.printReservations(data.getReservationsByCustomerId(customerId));
            }
            catch
            {
                printer.printWarning("Brak klienta o podanym numerze ID");
            }
        }

        public void printReservationByInterval(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                printer.printReservations(data.getReservationsByTimeInterval(dateFrom, dateTo));
            }
            catch
            {
                printer.printWarning("Podano niepoprawny zakres czasu");
            }
        }

        public void printReservationByCustomerName(string lastName)
        {
            try
            {
                printer.printReservations(data.getReservationsByCustomerName(lastName));
            }
            catch
            {
                printer.printWarning("Brak klienta o podanym nazwisku");
            }
        }

        public void addCustomer(string firstName, string lastName, category group)
        {
            try
            {
                data.addCustomer(firstName, lastName, group);
            }
            catch
            {
                printer.printWarning("Wprowadzoenie niekomplentne dane");
            }
        }

        public void addRoom(int roomNumber)
        {
            try
            {
                data.addRoom(roomNumber);
            }
            catch
            {
                printer.printWarning("Pokój o podanym numerze istnieje albo liczba jest po za zakresem");
            }
        }

        public void addReservation(string firstName, string lastName, int roomNumber, DateTime arrivalDate, DateTime departureDate)
        {
            Customer customer;
            Room room;
            try
            {
                customer = data.getCustomerByFirstAndLastName(firstName, lastName);
                room = data.getRoomByNumber(roomNumber);
            }
            catch
            {
                printer.printWarning("Niepoprawne Dane");
                return;
            }
            
            try
            {
                data.addReservation(customer, room, arrivalDate, departureDate);
            }
            catch
            {
                printer.printWarning("Niepoprawne Dane");
            }
        }

        public void deleteCustomer(string firstName, string lastName)
        {
            int customerId = data.getCustomerIdByFirstAndLastName(firstName, lastName);
            if (customerId == -1)
            {
                printer.printWarning("Niepoprawne Dane");
            }
            else
            {
                data.deleteCustomer(customerId);
            }
        }

        public void deleteRoom(int roomNumber)
        {
            try
            {
                data.deleteRoom(roomNumber);
            }
            catch
            {
                printer.printWarning("Brak pokoju o podanym numerze");
            }
        }

        public void deleteReservation(int resId)
        {
            try
            {
                data.deleteReservationById(resId);
            }
            catch
            {
                printer.printWarning("Brak rezerwacji o podanym numerze");
            }
        }

        public void printLog()
        {
            System.IO.StreamWriter logFile;
            List<string> log = data.getLog();
            using (logFile = new System.IO.StreamWriter(@"..\\log.txt", false))
            {
                foreach (String str in log)
                {
                    logFile.WriteLine(str);
                }
            }
        }
    }
}

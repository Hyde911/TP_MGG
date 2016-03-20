using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_MG.Model
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public category CustomerGroup { get; set; }

        public Customer (string firstName, string lastName, category group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            CustomerGroup = group;
        }

        public override string ToString()
        {
            return String.Format("name: {0} {1} category: {3}", FirstName, LastName, CustomerGroup);
        }
    }
}

public enum category { regular, businesclass, VIP}

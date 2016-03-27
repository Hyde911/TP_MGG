using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_MG.DataGens;
using TP_MG.Repositories;
using TP_MG.View;
using TP_MG.Model;

namespace TP_MG
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRepository data;
            data = new DataRepository(new SmallDataGenerator());
            SimpleCollectionPrinter printer = new SimpleCollectionPrinter();
            printer.printCollections(data);
            Console.ReadKey();
        }
    }
}

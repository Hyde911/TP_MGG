using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_MG.Model;
using TP_MG.Repositories;

namespace TP_MG.Interfaces
{
    public interface IDataPrinter
    {
        void printCollections(DataRepository repository);
    }
}

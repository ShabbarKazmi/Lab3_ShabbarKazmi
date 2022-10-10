using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_ShabbarKazmi
{
    public interface IDatabase
    {
        void AddEntry(Entry entry);

        ObservableCollection<Entry> SortDatabaseEntries();
        bool DeleteEntry(Entry entry);
        Entry FindEntry(int id);
        ObservableCollection<Entry> GetEntries();
        bool EditEntry(Entry replacementEntry);

        
    }

}

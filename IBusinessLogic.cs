using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3_ShabbarKazmi
{

    public interface IBusinessLogic
    {
        InvalidFieldError AddEntry(string clue, string answer, int difficulty, string date);

        ObservableCollection<Entry> SortEntriesBL();

        Boolean IsEntrySelected(Entry entry);
        EntryDeletionError DeleteEntry(int entryId);
        EntryEditError EditEntry(string clue, string answer, int difficulty, string date, int id);
        Entry FindEntry(int id);
        ObservableCollection<Entry> GetEntries();
    }

}

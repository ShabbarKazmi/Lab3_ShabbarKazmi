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
        EntryDeletionError DeleteEntry(int entryId);
        EntryEditError EditEntry(string clue, string answer, int difficulty, string date, int id);
        Microsoft.Maui.Controls.Entry FindEntry(int id);
        ObservableCollection<Microsoft.Maui.Controls.Entry> GetEntries();
    }

}

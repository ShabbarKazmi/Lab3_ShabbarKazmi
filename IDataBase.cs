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
        void AddEntry(Microsoft.Maui.Controls.Entry entry);
        bool DeleteEntry(Microsoft.Maui.Controls.Entry entry);
        Microsoft.Maui.Controls.Entry FindEntry(int id);
        ObservableCollection<Microsoft.Maui.Controls.Entry> GetEntries();
        bool EditEntry(Microsoft.Maui.Controls.Entry replacementEntry);
    }

}

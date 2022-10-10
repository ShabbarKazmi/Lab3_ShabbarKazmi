using System.Data.Common;

namespace Lab3_ShabbarKazmi { 

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        EntriesLV.ItemsSource = MauiProgram.ibl.GetEntries();
    }

    void AddEntry(System.Object sender, System.EventArgs e)
    {
        String clue = clueENT.Text;
        String answer = answerENT.Text;
        String date = dateENT.Text;

        int difficulty;
        bool validDifficulty = int.TryParse(difficultyENT.Text, out difficulty);
        if (validDifficulty)
        {
            InvalidFieldError invalidFieldError = MauiProgram.ibl.AddEntry(clue, answer, difficulty, date);
            if (invalidFieldError != InvalidFieldError.NoError)
            {
                DisplayAlert("An error has occurred while adding an entry", $"{invalidFieldError}", "OK");
            }
        }
        else
        {
            DisplayAlert("Difficulty", $"Please enter a valid number", "OK");
        }
    }

    void DeleteEntry(System.Object sender, System.EventArgs e)
    {
            Entry selectedEntry = EntriesLV.SelectedItem as Entry;

            if (!MauiProgram.ibl.IsEntrySelected(selectedEntry))
            {
                 DisplayAlert("An error has occurred while deleting an entry","No Entry Selected, Please Select Enrty", "OK");
                return;
            }

        EntryDeletionError entryDeletionError = MauiProgram.ibl.DeleteEntry(selectedEntry.Id);
        if (entryDeletionError != EntryDeletionError.NoError)
        {
            DisplayAlert("An error has occurred while deleting an entry", $"{entryDeletionError}", "OK");
        }
    }

    void EditEntry(System.Object sender, System.EventArgs e)
    {

            Entry selectedEntry = EntriesLV.SelectedItem as Entry;

            if (!MauiProgram.ibl.IsEntrySelected(selectedEntry))
            {
                DisplayAlert("An error has occurred while editing an entry", "No Entry Selected, Please Select Enrty", "OK");
                return; 
            }

            selectedEntry.Clue = clueENT.Text;
        selectedEntry.Answer = answerENT.Text;
        selectedEntry.Date = dateENT.Text;


        int difficulty;
        bool validDifficulty = int.TryParse(difficultyENT.Text, out difficulty);
        if (validDifficulty)
        {
            selectedEntry.Difficulty = difficulty;
            Console.WriteLine($"Difficuilt is {selectedEntry.Difficulty}");
            EntryEditError entryEditError = MauiProgram.ibl.EditEntry(selectedEntry.Clue, selectedEntry.Answer, selectedEntry.Difficulty, selectedEntry.Date, selectedEntry.Id);
            if (entryEditError != EntryEditError.NoError)
            {
                DisplayAlert("An error has occurred while editing an entry", $"{entryEditError}", "OK");
            }
        }


    }


        public void SortEntriesByClue(System.Object sender, System.EventArgs e)
        {
            EntriesLV.ItemsSource = MauiProgram.ibl.SortByClue();
        }

        public void SortEntriesByAnswer(System.Object sender, System.EventArgs e)
        {
            EntriesLV.ItemsSource = MauiProgram.ibl.SortByAnswer();
        }

        void EntriesLV_ItemSelected(System.Object sender, SelectedItemChangedEventArgs e)
    {
            Entry selectedEntry = e.SelectedItem as Entry;
        clueENT.Text = selectedEntry.Clue;
        answerENT.Text = selectedEntry.Answer;
        difficultyENT.Text = selectedEntry.Difficulty.ToString();
        dateENT.Text = selectedEntry.Date;

    }
}
}


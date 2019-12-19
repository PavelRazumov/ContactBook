using ContactBook.Model;
using ContactBook.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactBook.ViewModel
{
    public class AlphabetViewModel: ObservableObject
    {
        private List<AvaillabelLetter> _letter;
        
        private AvaillabelLetter _selectedLetter;
        
        public ICommand SearchByLetterCommand { get; set; }

        public ObservableCollection<AvaillabelLetter> SearchAlphabet {
            get;
            set;         
         }
        public AvaillabelLetter SelectedLetter
        {
            get { return _selectedLetter; }
            set { OnPropertyChanged(ref _selectedLetter, value); }
        }

        public List<AvaillabelLetter> SetAvailableLetter(IEnumerable<string> names)
        {
            _letter.Clear();
            foreach (var name in names)
            {
                _letter.Add(new AvaillabelLetter(name.ToUpper()[0]));

            }

            return _letter;
        }

        public AlphabetViewModel()
        {
            
            _letter = new List<AvaillabelLetter>();
            OnPropertyChanged("SearchByLetterCommand");
        }

        public void Search()
        {
            OnPropertyChanged("SelectedLetter");
        }
        public void LoadAlphaBet(IEnumerable<Contact> contacts)
        {
            var availableLetters = SetAvailableLetter(
                contacts.Select(x => x.FirstName));
            SearchAlphabet = new ObservableCollection<AvaillabelLetter>(availableLetters);

            OnPropertyChanged("SearchAlphabet");
        }

      

    }
}

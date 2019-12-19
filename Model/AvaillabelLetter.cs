using ContactBook.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactBook.Model
{
    public class AvaillabelLetter : ObservableObject
    {
        public ICommand SearchByLetterCommand
        {
            get;
            set;
        }

        private char _letter;

        public char Letter
        {
            set
            {
                OnPropertyChanged(ref _letter, value);
            }

            get
            {
                return _letter;
            }
        }

        public AvaillabelLetter(char letter)
        {
            _letter = letter;
            SearchByLetterCommand = new RelayCommand(Search);
        }

        public void Search()
        {
            var i = 0;
        }
    }
}

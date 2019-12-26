using ContactBook.Model;
using ContactBook.Services;
using ContactBook.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ContactBook.ViewModel
{
    public class BookViewModel : ObservableObject
    {
        private ContactViewModel _contactVM;
        public ContactViewModel ContactVM
        {
            get { return _contactVM; }
            set
            {

                OnPropertyChanged(ref _contactVM, value);
            }
        }

        private AlphabetViewModel _alphaBetVM;

        private string _searchQuery;
        public string SearchQuery
        {
            get { return _searchQuery; }
            set { OnPropertyChanged(ref _searchQuery, value); }
        }


        public string CurLetter;
        public Button CurLetterButton;

        public AlphabetViewModel AlphaBetVM
        {
            get;
            set;
        }

        private IContactDataService _service;
        private const int birthdaySoon = 7;

        public ICommand LoadContactsCommand { get; set; }
        public ICommand LoadBirthDayCommand { get; set; }
       

        public BookViewModel(JsonDataService service)
        {
            _contactVM = new ContactViewModel(service);
            AlphaBetVM = new AlphabetViewModel();
            
            _service = service;
            //ContactVM.LoadContacts((await _service.GetContacts()));

            LoadContactsCommand = new RelayCommand(LoadDataContact);
            LoadBirthDayCommand = new RelayCommand(LoadBirthDayContact);
        }

    

        public async void LoadDataContact()
        {

            Func<Contact, bool> searchQueryExpr = Search();
            Func<Contact, bool> searchQueryExprIfLetter = LetterSelect();

            ContactVM.LoadContacts((await _service.GetContacts()).Where(c => searchQueryExpr(c) && searchQueryExprIfLetter(c)));

        }

        Func<Contact, bool> Search()
        {
            if (String.IsNullOrEmpty(SearchQuery))
            {
                return c => true;
            }
            string SearchQueryToLower = SearchQuery.ToLower();

            Func<Contact, bool> searchQueryExpr =
                (Contact c) => String.IsNullOrEmpty(SearchQuery) ||
                    (c.PhoneNumber.Contains(SearchQuery)) ||
                    (c.FirstName.ToLower().Contains(SearchQueryToLower)) ||
                    (c.PhoneNumber.Contains(SearchQuery)) ||
                    (c.Email.Contains(SearchQuery));
            return searchQueryExpr;
        }

        Func<Contact, bool> LetterSelect()
        {
            Func<Contact, bool> searchQueryExprIfLetter =
                (Contact c) => String.IsNullOrEmpty(CurLetter) || c.FirstName.ToLower().StartsWith(CurLetter.ToLower());
            return searchQueryExprIfLetter;
        }

        private async void LoadBirthDayContact()
        {
            
            ContactVM.LoadContacts((await _service.GetContacts()).Where(contact => 
                (new DateTime(
                   DateTime.Today.Year,
                   contact.BirthDate.Month,
                   contact.BirthDate.Day) > DateTime.Today && new DateTime(
                   DateTime.Today.Year,
                   contact.BirthDate.Month,
                   contact.BirthDate.Day) < DateTime.Today.AddDays(birthdaySoon)
                   )           
            ));
        }
    }
}

using ContactBook.Model;
using ContactBook.Services;
using ContactBook.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            LoadContactsCommand = new RelayCommand(LoadDataContact);
            LoadBirthDayCommand = new RelayCommand(LoadBirthDayContact);
        }

    

        public void LoadDataContact()
        {
            
            ContactVM.LoadContacts(_service.GetContacts());
            AlphaBetVM.LoadAlphaBet(_service.GetContacts());
            _contactVM.PropertyChanged += _contactVM_PropertyChanged;

        }

        private void _contactVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            AlphaBetVM.LoadAlphaBet(_service.GetContacts());
        }

        private void LoadBirthDayContact()
        {
            var allContacts = _service.GetContacts();    
            
            ContactVM.LoadContacts(allContacts.Where(contact => 
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

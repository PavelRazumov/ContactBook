using ContactBook.Model;
using ContactBook.Services;
using ContactBook.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ContactBook.ViewModel
{
    public class ContactViewModel : ObservableObject
    {
        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set { OnPropertyChanged(ref _selectedContact, value); }
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                OnPropertyChanged(ref _isEditMode, value);
                OnPropertyChanged("IsDisplayMode");
            }
        }

        public bool IsDisplayMode
        {
            get { return !_isEditMode; }
        }

        public ObservableCollection<Contact> Contacts { get; private set; }

        public ICommand EditCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set;}

        private IContactDataService _dataService;
      
        public ContactViewModel(IContactDataService dataService)
        {
            _dataService = dataService;

            EditCommand = new RelayCommand(Edit, CanEdit);
            SaveCommand = new RelayCommand(Save, IsEdit);
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete, CanDelete);
        }

        private void Add()
        {
            var newContact = new Contact
            {
                FirstName = "N/A",
                LastName = "N/A",
                PhoneNumber = "",
                Email = "",
                BirthDate = new DateTime()
            };
            Contacts.Add(newContact);

            SelectedContact = newContact;
        }
        private void Delete()
        {
            
            Contacts.Remove(SelectedContact);
            Save();
        }

        private bool CanDelete()
        {
            return !(SelectedContact == null);
        }
        private void Save()
        {
            _dataService.Save(Contacts);
            IsEditMode = false;

            OnPropertyChanged("SelectedContact");
        }

        private bool IsEdit()
        {
            return IsEditMode;
        }

        private bool CanEdit()
        {
            if (SelectedContact == null)
                return false;

            return !IsEditMode;
        }

        public void Edit()
        {
            IsEditMode = true;
        }

        public void LoadContacts(IEnumerable<Contact> contacts)
        {
            Contacts = new ObservableCollection<Contact>(contacts);
            OnPropertyChanged("Contacts");
        }
    }
}

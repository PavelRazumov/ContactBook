using ContactBook.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Model
{
    public class Contact : ObservableObject
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                OnPropertyChanged(ref _firstName, value);
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                OnPropertyChanged(ref _lastName, value);
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                OnPropertyChanged(ref _email, value);
            }
        }

        private DateTime _birthDate;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                OnPropertyChanged(ref _birthDate, value);
            }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                OnPropertyChanged(ref _phoneNumber, value);
            }
        }
    }
}

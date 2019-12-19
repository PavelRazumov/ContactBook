using ContactBook.Services;
using ContactBook.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.ViewModel
{
    public class AppViewModel: ObservableObject
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView;  }
            set 
            {
                OnPropertyChanged(ref _currentView, value);
            }
        }

        private BookViewModel _bookViewModel;
        public BookViewModel BookVm
        {
            get { return _bookViewModel;  }
            set
            {
                OnPropertyChanged(ref _bookViewModel, value);
            }
        }

        public AppViewModel()
        {
            var contactDataService = new JsonDataService();

            BookVm = new BookViewModel(contactDataService);
            CurrentView = BookVm;
        }

    }
}

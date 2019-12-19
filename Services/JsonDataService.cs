using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Model;
using Newtonsoft.Json;

namespace ContactBook.Services
{
    public class JsonDataService : IContactDataService
    {
        private string filePath = $"{Environment.CurrentDirectory}\\contacts.json";
        public IEnumerable<Contact> GetContacts()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
          
            var deserializeData = File.ReadAllText(filePath);

            var contacts = JsonConvert.DeserializeObject<List<Contact>>(deserializeData);

            if (contacts == null)
            {
                return new List<Contact>();
            }
            return contacts;
           
                        
        }

        public void Save(IEnumerable<Contact> contacts)
        {
            var serializedContacts = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(filePath, serializedContacts);
        }
    }
}

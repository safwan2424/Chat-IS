
using ChatUI.Core;
using ChatUI.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ChatUI.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<ContactModel> Contacts { get; set; }
        public RelayCommand SendCommand { get; set; }

        private string _message;
        public string Message
        {
            get => _message;
            set { _message = value; OnPropertyChanged(); }
        }

        private ContactModel _selectedContact;
        public ContactModel SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedContactMessages));
            }
        }

        public ObservableCollection<MessageModel> SelectedContactMessages => SelectedContact?.Messages;

        private readonly string[] RandomNames = new string[]
        {
            "Rohan", "Bob", "Charan", "Diana", "Goutham", "Fiona", "George", "Hannah", "Ivan", "Julia"
        };

        public MainViewModel()
        {
            Contacts = new ObservableCollection<ContactModel>();

            // Generate dummy users
            Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                var randomName = RandomNames[random.Next(RandomNames.Length)];
                var gender = (i % 2 == 0) ? "women" : "men"; // alternate gender for fun
                var randomImageIndex = random.Next(1, 99); // random image id between 1 and 99

                var contact = new ContactModel
                {
                    Username = randomName,
                    ImageSource = $"https://randomuser.me/api/portraits/{gender}/{randomImageIndex}.jpg"
                };

                // Each contact starts with a welcome message
                contact.Messages.Add(new MessageModel
                {
                    Username = contact.Username,
                    Message = $"Hello! I'm {contact.Username}",
                    Time = DateTime.Now,
                    ISNativeOrigin = false,
                    FirstMessage = true,
                    UsernameColor = "#409aff",
                    ImageSource = contact.ImageSource
                });

                Contacts.Add(contact);
            }

            SendCommand = new RelayCommand(o =>
            {
                if (SelectedContact != null && !string.IsNullOrWhiteSpace(Message))
                {
                    SelectedContact.Messages.Add(new MessageModel
                    {
                        Username = "Me",
                        Message = Message,
                        Time = DateTime.Now,
                        ISNativeOrigin = true,
                        FirstMessage = false,
                        UsernameColor = "#ffffff",
                        ImageSource = "https://randomuser.me/api/portraits/men/10.jpg" // your profile pic
                    });

                    Message = "";
                    OnPropertyChanged(nameof(SelectedContactMessages));
                }
            });
        }
    }
}

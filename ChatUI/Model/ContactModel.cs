using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatUI.Model
{
    public class ContactModel
    {

        public string Username { get; set; }
        public string ImageSource { get; set; }

        // Each contact has their own message list
        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();

        public string LastMessage => Messages.LastOrDefault()?.Message ?? "No message yet";
    }
}

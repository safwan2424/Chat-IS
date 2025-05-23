﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatUI.Model
{
   public  class MessageModel
    {
        public string Username { get; set; }

        public string UsernameColor { get; set; }

        public string ImageSource { get; set; }
        public string Message { get; set; }

        public DateTime Time { get; set; }

        public bool ISNativeOrigin { get; set;  }

        public bool? FirstMessage { get; set; }
    }
}

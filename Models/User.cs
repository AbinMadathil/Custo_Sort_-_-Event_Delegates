using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delegates_Events.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }

    public class UserEventArgs : EventArgs
    {
        public User AffectedUser { get; set; }
        public string Message {get;set;}
        public UserEventArgs(User affecteduser,string message)
        {
            AffectedUser = affecteduser;
            Message =message;
        }
    }
}
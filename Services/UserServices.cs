using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Delegates_Events.Models;

namespace Delegates_Events.Services
{
    public class UserServices
    {

        public event EventHandler<UserEventArgs> UserAdded;
        public event EventHandler<UserEventArgs> UserUpdated;
        public event EventHandler<UserEventArgs> UserRemoved;
        List<User> users= new List<User>();
        public void AddUser(User user){
            users.Add(user);
            OnUserAdded(new UserEventArgs(user,"user Added Successfully")); 
            return;
        }

        public void UpdateUserProperty(int userId, string propertyName, string newValue)
        {
            var user = GetuserbyId(userId);
            if (user != null)
            {
                switch (propertyName)
                {
                    case "Name":
                        user.Name = newValue;
                        break;
                    case "Email":
                        user.Email = newValue;
                        break;
                    case "Contact":
                        user.Contact = newValue;
                        break;
                    default:
                        Console.WriteLine($"Invalid property name: {propertyName}");
                        return;
                }
                OnUserUpdated(new UserEventArgs(user,"user Updated successfully"));
                return;
            }
            else
            {
                Console.WriteLine($"User with Id {userId} not found.");
            }
        }
        public User? RemoveUser(int userId){
            var UserSearched=GetuserbyId(userId);
            users.Remove(UserSearched);
            OnUserRemoved(new UserEventArgs(UserSearched,"user removed successfully"));
            return UserSearched;
        }
        private User? GetuserbyId(int userId)
        {
            var FoundUser= users.FirstOrDefault(e=>e.Id==userId);
            if(FoundUser!=null){
                return FoundUser;
            }
            return null;
        }

        public void GetAllUsers(){
            foreach(var user in  users){
                Console.WriteLine($"{user.Name}  {user.Id} {user.Email}");
            }
            return;
        }


        protected virtual void OnUserAdded(UserEventArgs e)
    {
        UserAdded?.Invoke(this, e);
    }

    protected virtual void OnUserUpdated(UserEventArgs e)
    {
        UserUpdated?.Invoke(this, e);
    }

    protected virtual void OnUserRemoved(UserEventArgs e)
    {
        UserRemoved?.Invoke(this, e);

    }
    
    }
}
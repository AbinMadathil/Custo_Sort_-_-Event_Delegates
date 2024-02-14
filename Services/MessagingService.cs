using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delegates_Events.Models;

namespace Delegates_Events.Services
{
    
        public class SMSService
{
    public void HandleUserEvent(object sender, UserEventArgs e)
    {
        Console.WriteLine($"SMSService: {e.Message} - User {e.AffectedUser.Id} - {e.AffectedUser.Name}");
    }
}

public class EmailService
{
    public void HandleUserEvent(object sender, UserEventArgs e)
    {
        Console.WriteLine($"EmailService: {e.Message} - User {e.AffectedUser.Id} - {e.AffectedUser.Name}");
    }
}

public class PushNotificationService
{
    public void HandleUserEvent(object sender, UserEventArgs e)
    {
        Console.WriteLine($"PushNotificationService: {e.Message} - User {e.AffectedUser.Id} - {e.AffectedUser.Name}");
    }
}


}

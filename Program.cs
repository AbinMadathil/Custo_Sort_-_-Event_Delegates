using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using Delegates_Events.Models;
using System.Collections.Generic;
using Delegates_Events.Services;
namespace Delegates_Events;

class Program{

    static int identity=100;
    public delegate int ComparisonDelegate<T>(T x, T y);
    public static void Main(String[] args){
        
        List<Student> students = new List<Student>
        {
            new Student { Id = 100, Name = "Ram", Age = 15, Score = 99 },
            new Student { Id = 121, Name = "Arjun", Age = 19, Score = 89.8 },
            new Student { Id = 101, Name = "Rahul", Age = 15, Score = 99.9 },
            new Student { Id = 102, Name = "Riya", Age = 16, Score = 78.5 }
        };

        
        students = GenericSort(students, (s1, s2) => s1.Score.CompareTo(s2.Score));//gives the output in ascending order
        foreach(var student in students){
            Console.WriteLine(student.Name);
        }
    //also we can change the score field to any other for other objects...we can give objects in the comareto method also.
    

        //<-------------------------User Project------------------->
        var _userservice=new UserServices();
        var smsService = new SMSService();
        var emailService = new EmailService();
        var pushNotificationService = new PushNotificationService();

        _userservice.UserAdded += smsService.HandleUserEvent;
        _userservice.UserAdded += emailService.HandleUserEvent;
        _userservice.UserAdded += pushNotificationService.HandleUserEvent;

        _userservice.UserUpdated += smsService.HandleUserEvent;
        _userservice.UserUpdated += emailService.HandleUserEvent;
        _userservice.UserUpdated += pushNotificationService.HandleUserEvent;

        _userservice.UserRemoved += smsService.HandleUserEvent;
        _userservice.UserRemoved += emailService.HandleUserEvent;
        _userservice.UserRemoved += pushNotificationService.HandleUserEvent;

        bool loop=true;
        while(loop){
        Console.WriteLine("Enter the Function you want to do with User Repo:\n"+
                                 $"1)Add User\n" +
                                 $"2)Update user\n" +
                                 $"3)Remove User\n"+
                                 $"4)Get All users\n"+
                                 $"5)exit the console");
        Console.WriteLine("Enter your choice");
        var choice= Convert.ToInt32(Console.ReadLine());
        
        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter the Name of the User:");
                var name=Console.ReadLine();
                Console.WriteLine("Enter the Email of the User");
                var email = Console.ReadLine();
                Console.WriteLine("Enter the contact of the employee");
                var contact= Console.ReadLine();
                User user=new User{
                    Id=identity++,
                    Name=name,
                    Email=email,
                    Contact=contact

                };
                _userservice.AddUser(user);
                break;
            case 2:
                Console.WriteLine("Enter the id of the person you want to update:");
                int id=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the field you want to alter");
                var field=Console.ReadLine();
                Console.WriteLine("Enter the Updated data for the field:");
                var data=Console.ReadLine();
                _userservice.UpdateUserProperty(id,field,data);
                break;
            case 3:
                Console.WriteLine("Enter the id of the person you want to remove:");
                int person_id=Convert.ToInt32(Console.ReadLine());
                _userservice.RemoveUser(person_id);
                break;
            case 4:
                _userservice.GetAllUsers();
                break;
            case 5:
                loop=false;
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a valid option.");
                break;
        }
        }
    }

    public static List<T> GenericSort<T>(List<T> collection, Comparison<T> comparison)
    {
        collection.Sort(comparison);
        return collection;
    }
}
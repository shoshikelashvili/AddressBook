using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Data;
using System.Net;
using System.Net.Mail;

namespace AddressBook.Core
{
    public class CoreFunctions
    {
       
        //This function creates a User object and returns it
        public static Domain.User CreateUser(string firstname, string lastname, string username, string password, string email)
        {
            Domain.User user = new Domain.User();
            user.ID = Data.DataFunctions.nextID;
            user.FirstName = firstname;
            user.LastName = lastname;
            user.Username = username;
            user.Password = password;
            user.Email = email;
            return user;
        }

        //This function is used for sending email
        public static void send_Email(string yourMessage, string address)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("shoshikelashvili.rati.test@gmail.com");
            message.To.Add(new MailAddress(address));
            message.Subject = "Recover lost password!";
            message.Body = yourMessage;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("shoshikelashvili.rati.test@gmail.com", "testpassword111");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }
}

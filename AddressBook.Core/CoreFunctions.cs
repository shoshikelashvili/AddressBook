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
    public static class CoreFunctions
    {
        public static string LoggedinUsername = null;

        public static bool FieldsFilled(List<string> fields)
        {
            foreach (string item in fields)
            {
                if (string.IsNullOrWhiteSpace(item)) return false;
            }
            return true;
        }

        public static int Register(List<string> all_fields)
        {
            if (FieldsFilled(all_fields) && DataFunctions.IsUnique(all_fields[0], all_fields[4]))
            {
                Domain.User user = CreateUser(all_fields[0], all_fields[1], all_fields[2], all_fields[3], all_fields[4]);
                DataFunctions.AddUser(user);
                return 1;
            }
            else if (!FieldsFilled(all_fields))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public static int LogIn(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password == "Password" || string.IsNullOrWhiteSpace(username) || username == "Username")
            {
                return -1;
            }
            else if (Data.DataFunctions.CheckCredentials(username, password))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //This function creates a User object and returns it
        public static Domain.User CreateUser(string firstname, string lastname, string username, string password, string email)
        {
            Domain.User user = new Domain.User();
            user.ID = Data.DataFunctions.returnNextID();
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

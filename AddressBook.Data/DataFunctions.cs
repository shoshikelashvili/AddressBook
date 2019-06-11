using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AddressBook.Domain;

namespace AddressBook.Data
{
    public static class DataFunctions
    {
        private static string _usersFilePath = @"E:\G02\Users.dat"; //We save all User credentials here
        private static string _contactsFilePath = @"E:\G02\Contacts.dat"; // We save all Contacts here
        private static List<User> Users { get; set; }
        private static List<Contact> Contacts { get; set; }

        //This function ensures that file path Directory exists and creates it in case it doesn't
        private static void EnsureDirectory(string path)
        {
            string directoryPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        //This functions transfers information from Dat file to users List
        public static void LoadUserData()
        {
            if (!File.Exists(_usersFilePath))
            {
                return;
            }
            Users.Clear();
            using (BinaryReader binaryReader = new BinaryReader(File.Open(_usersFilePath, FileMode.Open)))
            {
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    User processedUser = new User();
                    processedUser.ID = binaryReader.ReadInt32();
                    processedUser.FirstName = binaryReader.ReadString();
                    processedUser.LastName = binaryReader.ReadString();
                    processedUser.Username = binaryReader.ReadString();
                    processedUser.Password = binaryReader.ReadString();
                    processedUser.Email = binaryReader.ReadString();
                    Users.Add(processedUser);
                }
            }
        }

        //This function transfers data from Users list to Dat file
        public static void SaveUserData()
        {
            EnsureDirectory(_usersFilePath);
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(_usersFilePath, FileMode.Create)))
            {
                foreach (User user in Users)
                {
                    int latestID = FindNextID();
                    binaryWriter.Write(latestID);
                    binaryWriter.Write(user.FirstName);
                    binaryWriter.Write(user.LastName);
                    binaryWriter.Write(user.Username);
                    binaryWriter.Write(user.Password);
                    binaryWriter.Write(user.Email);
                }
            }
        }


        public static string[] FindByEmail(string email)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(_usersFilePath, FileMode.Open)))
            {
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    binaryReader.ReadInt32();
                    string firstName = binaryReader.ReadString();
                    string lastName = binaryReader.ReadString();
                    string username = binaryReader.ReadString();
                    string password = binaryReader.ReadString();
                    if (email == binaryReader.ReadString())
                    {
                        string[] result = new string[] { $"{firstName} {lastName}", username, password };
                        return result;
                    }
                }
                string[] tufta = new string[0];
                return tufta;
            }
        }

        public static string ReturnFullName(string username)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(_usersFilePath, FileMode.Open)))
            {
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    binaryReader.ReadInt32();
                    string Firstname = binaryReader.ReadString();
                    string Lastname = binaryReader.ReadString();
                    if (username == binaryReader.ReadString()) return Firstname + " " + Lastname;
                    binaryReader.ReadString();
                    binaryReader.ReadString();
                }
                return "For some reason, we couldn't find you name";
            }
        }
        //This function reads through Users database and returns true if given user exists
        public static bool CheckCredentials(string username, string password)
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(_usersFilePath, FileMode.Open)))
            {
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    bool username_check = false, password_check = false;
                    binaryReader.ReadInt32();
                    binaryReader.ReadString();
                    binaryReader.ReadString();
                    if (username == binaryReader.ReadString()) username_check = true; 
                    if (password == binaryReader.ReadString()) password_check = true;
                    binaryReader.ReadString();
                    if (username_check && password_check) return true;
                }
                return false;
            }
        }

        //This function returns the next ID that you should use for adding a user
        public static int FindNextID()
        {
            int ID = 0;
            foreach (User user in Users)
            {
                ID = user.ID + 1;
            }
            return ID;
        }
        //This function checks if given username and email are already in database
        public static bool IsUnique(string username, string email)
        {
            if (File.Exists(_usersFilePath))
            {
                using (BinaryReader binaryReader = new BinaryReader(File.Open(_usersFilePath, FileMode.Open)))
                {
                    while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                    {
                        binaryReader.ReadInt32();
                        binaryReader.ReadString();
                        binaryReader.ReadString();
                        if (username == binaryReader.ReadString()) return false;
                        binaryReader.ReadString();
                        if (email == binaryReader.ReadString()) return false;
                    }
                    return true;
                }
            }
            return false;
        }

        //This function writes user info at the end of the text
        public static void Write(User user)
        {
            int latestID = FindNextID();
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(_usersFilePath, FileMode.Append)))
            {
                binaryWriter.Write(latestID);
                binaryWriter.Write(user.FirstName);
                binaryWriter.Write(user.LastName);
                binaryWriter.Write(user.Username);
                binaryWriter.Write(user.Password);
                binaryWriter.Write(user.Email);
            }
        }
        
        //Functions for testing and troubleshooting
        public static void Test()
        {
            int a =0; string b = "", c = "", d = "", e = "", f = "";
            using (BinaryReader binaryReader = new BinaryReader(File.Open(_usersFilePath, FileMode.Open)))
            {
                using (StreamWriter streamWriter = new StreamWriter(File.Open(@"E:\Test.txt", FileMode.Create)))
                {
                    while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                    {
                        a = binaryReader.ReadInt32();
                        b = binaryReader.ReadString();
                        c = binaryReader.ReadString();
                        d = binaryReader.ReadString();
                        e = binaryReader.ReadString();
                        f = binaryReader.ReadString();


                        streamWriter.Write(a);
                        streamWriter.Write(b);
                        streamWriter.Write(c);
                        streamWriter.Write(d);
                        streamWriter.Write(e);
                        streamWriter.Write(f);
                    }   
                }
            }
          
        }

    }
}

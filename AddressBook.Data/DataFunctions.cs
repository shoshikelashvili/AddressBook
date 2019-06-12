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
        private static List<User> Users = new List<User>();

        public static int returnUsersLength() { return Users.Count; }

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
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(_usersFilePath, FileMode.Create)))
            {
                for (int i= 0; i<Users.Count;i++)
                {
                    binaryWriter.Write(Users[i].ID);
                    binaryWriter.Write(Users[i].FirstName);
                    binaryWriter.Write(Users[i].LastName);
                    binaryWriter.Write(Users[i].Username);
                    binaryWriter.Write(Users[i].Password);
                    binaryWriter.Write(Users[i].Email);
                }
            }
        }

        public static void AddUser(User user)
        {
            if (user.Email == user.Username) throw new Exception("Username and email must be different");
            foreach (User u in Users)
            {
                if (u.ID == user.ID || u.Username == user.Username || u.Email == user.Email)
                {
                    throw new Exception("Such user already exists.");
                }
            }
            Users.Add(user);
            SaveUserData();
        }

        public static void EditUser(User user)
        {
            LoadUserData();
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].ID == user.ID)
                {
                    Users[i] = user;
                    SaveUserData();
                    return;
                }
            }
            throw new Exception("Such user doesn't exist.");
        }

        public static void DeleteUser(User user)
        {
            DeleteUser(user.ID);
        }

        public static void DeleteUser(int id)
        {
            LoadUserData();
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].ID == id)
                {
                    Users.RemoveAt(i);
                    SaveUserData();
                    return;
                }
            }
        }
        //This function finds user based on username or email

        public static User FindUser(string usernameORemail)
        {
            LoadUserData();
            foreach (User u in Users)
            {
                if (u.Email == usernameORemail || u.Username == usernameORemail) return u;
            }
            throw new Exception("Such user doesn't exist.");
        }

        //This function reads through Users database and returns true if user exists
        public static bool CheckCredentials(string username, string password)
        {
            LoadUserData();
            foreach (User u in Users)
            {
                if (u.Username == username && u.Password == password) return true;
            }
            return false;
        }

        //This function checks if username and email are unique and returns True if so
        public static bool IsUnique(string username, string email)
        {
            LoadUserData();
            foreach (User u in Users)
            {
                if (u.Username == username || u.Email == email) return false;
            }
            return true;
        }
        

        //Functions for testing and troubleshooting. This function translate DAT file into a simple Txt one
        public static void Test()
        {
            int a = 0; string b = "", c = "", d = "", e = "", f = "";
            using (BinaryReader binaryReader = new BinaryReader(File.Open(_usersFilePath, FileMode.Open)))
            {
                using (StreamWriter streamWriter = new StreamWriter(File.Open(@"E:\G02\Test.txt", FileMode.Create)))
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

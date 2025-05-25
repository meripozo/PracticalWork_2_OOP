using System;
using System.IO;

namespace PracticalWork_2
{    
    public class User
    {
        private string name;
        private string username;
        private string password;
        private string email;
        private int numberOfOperations;
        public User(string name, string username, string password, string email)
        {
            this.name = name;
            this.username = username;
            this.password = password;
            this.email = email;
            this.numberOfOperations = 0; //I initialize to 0, because it will be used as a counter
        }
        public void UserWriteToFile()
        {
            string filePath = "src/PracticalWork_2/UserInfoSaved.txt";
            StreamWriter sw = File.AppendText(filePath);
            sw.WriteLine($"{this.name};{this.username};{this.password};{this.email};{this.numberOfOperations}");
            sw.Close();
        }
    }
}

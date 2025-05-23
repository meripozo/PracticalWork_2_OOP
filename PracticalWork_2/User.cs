using System;
using System.IO;

namespace PracticalWork_2
{     //cada cosa que meta el usuario por la interfaz, lo guardo en los atributos del user, y eso lo uso para luego meterlo en el txt
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

            string filePath = "PracticalWork_2/UserInfoSaved.txt";
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine($"{this.name};{this.username};{this.password};{this.email}");
            sw.Close();
        }
        public string GetName()
        {
            this.name = name;
            return this.name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetUsername(string username) 
        {
            this.username = username;
        }
        public string GetUsername()
        {
            this.username = username;
            return this.username;
        }
        public string GetPassword()
        {
            this.password = password;
            return this.password;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public string GetEmail()
        {
            this.email = email;
            return this.email;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2___Data_Sorting_Module
{
    public class FacebookAccount : IComparable<FacebookAccount>
    {
        // Fields
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }

        // Constructor
        public FacebookAccount(string username, string email, string password, int age)
        {
            Username = username;
            Email = email;
            Password = password;
            Age = age;
        }

        //Never used, as we use a more generic lambda function, yet it is here,
        public int CompareTo(FacebookAccount other)
        {
            return this.Email.CompareTo(other.Email);
        }
    }
}

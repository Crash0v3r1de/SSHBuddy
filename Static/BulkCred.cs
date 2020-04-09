using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHBuddy.Static
{
    public static class BulkCred
    {
        private static string username { get; set; }
        private static string password { get; set; }
        public static bool UsingCreds = false;

        private static void SetUsingCreds()
        {
            UsingCreds = true;
        }
        private static bool SetPassword(string pass)
        {
            try
            {
                password = pass;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string GetPassword()
        {
            return password;
        }
        private static bool SetUsername(string user)
        {
            try
            {
                username = user;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string Getusername()
        {
            return username;
        }

        public static bool SetValues(string user,string pass)
        {
            bool userSet = SetUsername(user);
            bool passSet = SetPassword(pass);
            if (userSet & passSet)SetUsingCreds();
            return (userSet&passSet);
        }
    }
}

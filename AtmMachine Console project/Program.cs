using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMachine_Console_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>()
            {
                new Account("fayaz",1234,5000),
                new Account("Ahmad",4321,3000)
            }; 

            Console.Write("Enter Username :");
            string inputuser = Console.ReadLine();
            Console.Write("Enter Pin :");
            int inputpin =Convert.ToInt32(Console.ReadLine());

            Account currentaccont = accounts.FirstOrDefault(a => a.Username == inputuser && a.Pin==inputpin );
            if (currentaccont != null)
            {
                Console.WriteLine("Login Successfully");
            }
            else
            {
                Console.WriteLine("Invalid username or pin "+"Exiting");
                return;
            }
        }

        public class Account
        {
            public string Username {  get; set; }
            public int Pin { get; set; }
            public decimal Balance { get; set; }

            public Account(string username,int pin,decimal balance)
            {
                Username = username;
                Pin = pin;
                Balance = balance;
            }

        }
    }
}

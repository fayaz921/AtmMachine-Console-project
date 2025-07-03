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
            Console.WriteLine("\n * Wellcome to ATM *\n");
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

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\n===ATM Menu===\n");
                    Console.WriteLine("1:Check Balance :");
                    Console.WriteLine("2:Deposit :");
                    Console.WriteLine("3:Withdraw :");
                    Console.WriteLine("4:Exit :");
                    Console.Write("Select an Option :");
                    string option = Console.ReadLine();
                    switch(option)
                    {
                        case "1":
                            Console.WriteLine($"Your current Balance is : {currentaccont.Balance}");
                            break;
                        case "2":
                            Console.Write("Enter Deposit Amount :");
                            decimal deposit = Convert.ToDecimal(Console.ReadLine());
                            currentaccont.Balance += deposit;
                            Console.WriteLine("Amount Deposited Successfully");
                            break;
                        case "3":
                            Console.Write("Enter Withdrawal Amount :");
                            decimal withdraw = Convert.ToDecimal(Console.ReadLine());
                            if (currentaccont.Balance >= withdraw)
                            {

                                currentaccont.Balance -= withdraw;
                                Console.WriteLine("Amount Withdrawal successfully ");
                            }
                            else
                            {
                                Console.WriteLine("Balance is insufficient ");
                            }
                            break;
                        case "4":
                            Console.WriteLine("Thanks for using ATM \n" + "Exiting");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option try again ");
                            break;
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid username or pin \n"+"Exiting");
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

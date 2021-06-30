﻿using System;
using ExceptionChallenge.Entities;
using ExceptionChallenge.Entities.Exception;
using System.Globalization;

namespace ExceptionChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data:");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account acc = new Account(number, holder, balance, withdrawLimit);
                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                acc.Withdraw(amount);
                Console.WriteLine($"New balance: {acc.Balance.ToString("F2", CultureInfo.InvariantCulture)}");         
            }
            catch (DomainException e)
            {
                Console.WriteLine($"Withdraw error: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

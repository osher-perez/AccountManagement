using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement
{
    public class BankAccount
    {
        private string accountNumber; // מספר החשבון
        private double balance; // יתרת החשבון
        protected Customer customerOwner; // בעל החשבון (הוגדר כ-protected לשימוש במחלקות יורשות)

        // בנאי - אתחול חשבון בנק עם מספר חשבון, בעל חשבון, ויתרה התחלתית (ברירת מחדל היא 0)
        public BankAccount(string accountNumber, Customer customerOwner, double initialBalance = 0)
        {
            this.accountNumber = accountNumber;
            this.customerOwner = customerOwner;
            this.balance = initialBalance;
        }

        // פעולה שמחזירה את מספר החשבון
        public string GetAccountNumber()
        {
            return accountNumber;
        }

        // פעולה שמחזירה את יתרת החשבון
        public double GetBalance()
        {
            return balance;
        }

        // פעולה שמחזירה את בעל החשבון
        public Customer GetCustomerOwner()
        {
            return customerOwner;
        }

        // פעולה שמגדירה מספר חדש לחשבון
        public void SetAccountNumber(string accountNumber)
        {
            this.accountNumber = accountNumber;
        }

        // פעולה שמגדירה יתרה לחשבון (גישה מוגבלת - מיועדת למחלקות יורשות)
        protected void SetBalance(double value)
        {
            balance = value;
        }

        // פעולה שמגדירה בעל חשבון חדש (גישה מוגבלת - מיועדת למחלקות יורשות)
        protected void SetCustomerOwner(Customer value)
        {
            customerOwner = value;
        }

        // פעולה להפקדת כסף לחשבון
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount; // עדכון היתרה
                Console.WriteLine($"Deposited {amount} currency units into account number {accountNumber}. Current balance: {balance}.");
            }
            else
            {
                Console.WriteLine("Deposit amount must be greater than 0.");
            }
        }

        // פעולה להפקדת כסף עם תאריך
        public void Deposit(double amount, DateTime date)
        {
            Deposit(amount); // קריאה לפעולת ההפקדה הרגילה
            Console.WriteLine($"Deposit made on: {date.ToShortDateString()}.");
        }

        // פעולה למשיכת כסף מהחשבון (וירטואלית - ניתנת לשינוי במחלקות יורשות)
        public virtual void Withdraw(double amount)
        {
            if (amount > 0 && balance >= amount)
            {
                balance -= amount; // עדכון היתרה לאחר משיכה
                Console.WriteLine($"Withdrawn {amount} currency units from account number {accountNumber}. Current balance: {balance}.");
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than 0.");
            }
            else
            {
                Console.WriteLine($"Insufficient funds in account number {accountNumber}. Current balance: {balance}.");
            }
        }

        // פעולה להצגת יתרת החשבון (וירטואלית - ניתנת לשינוי במחלקות יורשות)
        public virtual void PrintBalance()
        {
            Console.WriteLine($"Account number {accountNumber} balance: {balance}.");
        }
    }

}

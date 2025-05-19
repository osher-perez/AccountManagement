using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement
{
    

    public class BankBranch : IBankBranch
    {
        private int branchNumber; // מספר הסניף
        private string address; // כתובת הסניף
        private CheckingAccount[] accounts; // מערך של חשבונות עו"ש
        private int accountCount; // מספר החשבונות שנוספו לסניף

        // פעולה בונה - יוצרת אובייקט של סניף עם מספר וכתובת, ומאתחלת את מערך החשבונות
        public BankBranch(int branchNumber, string address)
        {
            this.branchNumber = branchNumber;
            this.address = address;
            this.accounts = new CheckingAccount[20]; // ניתן להוסיף עד 20 חשבונות
            this.accountCount = 0; // בתחילת הדרך אין חשבונות
        }

        // פעולה שמחזירה את מספר הסניף
        public int GetBranchNumber() { return branchNumber; }

        // פעולה שמחזירה את כתובת הסניף
        public string GetAddress() { return address; }

        // פעולה שמגדירה מספר חדש לסניף
        public void SetBranchNumber(int branchNumber) { this.branchNumber = branchNumber; }

        // פעולה שמגדירה כתובת חדשה לסניף
        public void Setaddress(string address) { this.address = address; }

        // פעולה להוספת חשבון לסניף
        public void AddAccount(BankAccount account)
        {
            // בדיקה אם יש מקום פנוי להוספת חשבון נוסף
            CheckingAccount checkingAccount = account as CheckingAccount;
            if (accountCount < accounts.Length && checkingAccount != null)
            {
                accounts[accountCount] = (CheckingAccount)account; // המרת החשבון לסוג CheckingAccount והוספתו למערך
                accountCount++; // הגדלת מונה החשבונות
                Console.WriteLine($"Account number {account.GetAccountNumber()} added to branch {branchNumber}."); // הודעה על הצלחה
            }
            else
            {
                Console.WriteLine($"Only CheckingAccount type can be added to branch {branchNumber}."); // הודעה במקרה שאין מקום לחשבונות נוספים
            }
        }

        // פעולה להדפסת כל החשבונות בסניף
        public void PrintAccounts()
        {
            Console.WriteLine($"List of accounts in branch number {branchNumber}:"); // הודעה המציינת את מספר הסניף
            if (accountCount == 0) // אם אין חשבונות בסניף
            {
                Console.WriteLine("There are no accounts in this branch."); // הצגת הודעה מתאימה
                return;
            }

            // לולאה העוברת על כל החשבונות ומדפיסה את פרטיהם
            for (int i = 0; i < accountCount; i++)
            {
                Console.WriteLine($"Account number: {accounts[i].GetAccountNumber()}, Owner: {accounts[i].GetCustomerOwner().GetName()}, Balance: {accounts[i].GetBalance()}");
            }
        }
    }

}

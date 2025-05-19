namespace AccountManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // יצירת לקוחות
            Customer customer1 = new Customer(123456789, "Avi Cohen", "050-1234567"); // יצירת לקוח עם מספר תעודת זהות, שם, וטלפון
            Customer customer2 = new Customer(987654321, "Sarah Levi", "052-9876543"); // יצירת לקוח נוסף



            // יצירת סניף בנק
            BankBranch branch1 = new BankBranch(101, "10 Herzl Street, Tel Aviv");// יצירת סניף עם מספר וכתובת
            Console.WriteLine($"Branch details: Number {branch1.GetBranchNumber()}, Address: {branch1.GetAddress()}");// הצגת פרטי הסניף


            // יצירת חשבונות עו"ש
            CheckingAccount account1 = new CheckingAccount("CH1001", customer1, 1000, 500); // יצירת חשבון עבור אבי כהן עם יתרה התחלתית של 1000 ושירות אשראי של 500
            CheckingAccount account2 = new CheckingAccount("CH1002", customer2, 5000, 1000); // יצירת חשבון עבור שרה לוי עם יתרה התחלתית של 5000 ומסגרת אשראי של 1000

            // הוספת חשבונות לסניף
            branch1.AddAccount(account1); // הוספת חשבון ראשון לסניף
            branch1.AddAccount(account2); // הוספת חשבון שני לסניף

            Console.WriteLine("Customer details:");
            customer1.PrintDetails(); // הצגת פרטי הלקוח הראשון
            customer2.PrintDetails(); // הצגת פרטי הלקוח השני

            Console.WriteLine("Operations on Account 1:");
            account1.Deposit(200); // הפקדת 200 ש"ח לחשבון הראשון
            account1.Withdraw(700); // משיכת 700 ש"ח מחשבון הראשון
            account1.Withdraw(1000); // ניסיון משיכה של 1000 ש"ח מעבר למסגרת האשראי
            account1.PrintBalance(); // הדפסת יתרת החשבון הראשון
            account1.Deposit(500, DateTime.Now); // שימוש בפעולת הפקדה עם תאריך

            Console.WriteLine("Operations on Account 2:");
            account2.Withdraw(100); // משיכת 100 ש"ח מחשבון השני
            account2.PrintBalance(); // הדפסת יתרת חשבון השני

            // הדפסת כל החשבונות בסניף
            branch1.PrintAccounts(); // הצגת כל החשבונות הקיימים בסניף

        }
    }
}

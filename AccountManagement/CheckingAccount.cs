namespace AccountManagement
{
    public class CheckingAccount : BankAccount
    {
        private double overdraftLimit; // מסגרת האשראי שמותרת בחשבון

        // בנאי - יצירת חשבון עו"ש עם מספר חשבון, בעל חשבון, יתרה התחלתית, ומסגרת אשראי
        public CheckingAccount(string accountNumber, Customer customerOwner, double initialBalance, double overdraftLimit)
           : base(accountNumber, customerOwner, initialBalance)
        {
            this.overdraftLimit = overdraftLimit;
        }

        // פעולה שמחזירה את מסגרת האשראי
        public double GetOverdraftLimit()
        {
            return overdraftLimit;
        }

        // פעולה שמגדירה מסגרת אשראי חדשה
        public void SetOverdraftLimit(double value)
        {
            this.overdraftLimit = value;
        }

        // פעולה למשיכת כסף מהחשבון - מאפשרת מינוס עד גובה מסגרת האשראי
        public override void Withdraw(double amount)
        {
            if (amount > 0 && (GetBalance() + overdraftLimit) >= amount) // בדיקה אם ניתן למשוך (כולל אפשרות להיכנס למינוס)
            {
                SetBalance(GetBalance() - amount); // עדכון היתרה לאחר המשיכה
                Console.WriteLine($"Withdrawn {amount} currency units from account number {GetAccountNumber()}. Current balance: {GetBalance()}.");

                // בדיקה אם החשבון נכנס למינוס
                if (GetBalance() < 0)
                {
                    Console.WriteLine($"Warning: The account is overdrawn by {-GetBalance()} currency units (Overdraft limit: {overdraftLimit}).");
                }
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than 0.");
            }
            else
            {
                Console.WriteLine($"Withdrawal of {amount} currency units is not allowed. Current balance: {GetBalance()}, overdraft limit: {overdraftLimit}.");
            }
        }

        // פעולה להצגת יתרת החשבון - מציגה גם את מסגרת האשראי
        public override void PrintBalance()
        {
            Console.WriteLine($"Checking account number {GetAccountNumber()} balance: {GetBalance()}. Overdraft limit: {overdraftLimit}.");
        }
    }
}
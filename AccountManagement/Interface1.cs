using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement
{
    public interface IBankBranch
    {
        // ממשק שמגדיר את הפעולות שחייבות להיות בכל סניף בנק
        void AddAccount(BankAccount account); // הוספת חשבון לבנק
        void PrintAccounts(); // הצגת כל החשבונות בסניף
    }
}

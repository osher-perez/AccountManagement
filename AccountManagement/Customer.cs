using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement
{
    public class Customer
    {
        private int id;
        private string name;
        private string phoneNumber;
        public Customer(int id, string name, string phoneNumber)
        {
            this.id = id;
            this.name = name;
            this.phoneNumber = phoneNumber;
        }
        public int GetId() { return id; }
        public string GetName() { return name; }
        public string GetPhoneNumber() {  return phoneNumber; }
        public void SetId(int id) { this.id = id;}
        public void  SetName(string name) { this.name = name;}
        public void SetPhoneNumber(string phoneNumber) { this.phoneNumber = phoneNumber;}
        public void PrintDetails()
        {
            Console.WriteLine($"id: {id}, name: {name}, phone: {phoneNumber}");
        }
    }
}

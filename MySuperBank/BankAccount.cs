using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
    internal class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get
            { 
            decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance = balance + item.Amount;
                }
            return balance;
            
            } }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();
        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "initial balance");
       
        }
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount < 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "amount of withdrawal must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "amount of withdrawal must be positive");

            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("there is no sufficient funds for withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
        public string getAccHistory() {
            var report = new StringBuilder();
            report.AppendLine("Data\t\tAmount\t\tNote");
            foreach (var item in allTransactions) {
                report.AppendLine($"{item.Date}\t {item.Amount} \t {item.Notes}");
            
            }
        return report.ToString();
        }
    }
}

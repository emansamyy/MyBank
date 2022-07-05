using MySuperBank;



var account2 = new BankAccount("Eman", 1000);
account2.MakeWithdrawal(300, DateTime.Now, "withdrawal");
Console.WriteLine(account2.getAccHistory() );

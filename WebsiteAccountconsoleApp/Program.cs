using System;
using System.Security.Cryptography.X509Certificates;

public class Account
{
    string FirstName;
    string LastName;
    string Email;
    string Password;


   public Account(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
    public string GetFirstName()
    {
        return FirstName;
    }    
    public string GetLastName()
    {
        return LastName;
    }    
    public string GetEmail()
    {
        return Email;
    }    
    public string GetPassword()
    {
        return Password;
    }
    public void SetFirstName(string newFirstName)
    {
        FirstName=newFirstName;
    }
    public void SetLastName(string newLastName)
    {
        LastName=newLastName;
    }
    public void SetEmail(string newEmail)
    {
        Email=newEmail;
    }
    public void SetPassword(string newPassword)
    {
        Password=newPassword;
    }

    public static void Main(String[] args)
    {

        int optionOptions;
        void Options()
        {
            Console.WriteLine("Wybierz jedna z poniżych opcji...");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Rejestracja");
            try {
                optionOptions = int.Parse(Console.ReadLine());
                while (true)
                {
                    if (optionOptions == 1)
                    {
                        Login();
                        break;
                    }
                    else if (optionOptions == 2)
                    {
                        CreateAccount();
                        break;
                    }
                    else { }
                }
            }
            catch
            {
            }
            
        }

        string[] newAccount = new string[5];
        List<Account> accounts = new List<Account>();

        // przykladowe konta juz stworzone
        accounts.Add(new Account("Kamil", "Pies", "Frajer60@gmail.com", "jablko"));
        accounts.Add(new Account("Marta", "Okno", "Muszla@gmail.com", "ocean12"));


        foreach (var item in accounts)
        {
            Console.WriteLine(item);
        }
        void CreateAccount()
        {
            Console.WriteLine("-===--===-\nRejestracja :0");
            Console.WriteLine("Podaj Imie: ");
            newAccount[0] = Console.ReadLine();            
            
            Console.WriteLine("Podaj Nazwisko: ");
            newAccount[1] = Console.ReadLine();

            Console.WriteLine("Podaj Email: ");
            newAccount[2] = Console.ReadLine();

            Console.WriteLine("Podaj Haslo (1): ");
            newAccount[3] = Console.ReadLine();
            
            Console.WriteLine("Podaj Haslo (2): ");
            newAccount[4] = Console.ReadLine();

            if (newAccount[3] != newAccount[4]) { Console.WriteLine("Hasla sie nie zgadzają :(\n"); CreateAccount(); }
            else {
                try {
                    accounts.Add(new Account(newAccount[0], newAccount[1], newAccount[2], newAccount[3]));
                    Console.WriteLine("Konto stworzone :)");
                    Options();
                }
                catch { Console.WriteLine("error"); }
            }

        }
        string email;
        string password;
        Account account;

        void Login()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Podaj Email: ");
                    email = Console.ReadLine();


                    account = accounts.FirstOrDefault(a => a.Email == email);
                    if (account != null) {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nie istnieje Email");
                    }
                }
                catch { Console.WriteLine("Nie istnieje Email"); }
            }

            int opcjaLogin;
            bool dzialanie = true;
            while (dzialanie)
            {
                    Console.WriteLine("Wybierz jedno z dwoch opcji...");
                    Console.WriteLine("1. Wpisz Haslo");
                    Console.WriteLine("2. Zapomnialem Hasla");
                    Console.WriteLine("3. Cofnij");

                    opcjaLogin = int.Parse(Console.ReadLine());
                dzialanie = false;
                if (opcjaLogin == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("Logowanie");
                        Console.WriteLine("Podaj Haslo: ");
                        password = Console.ReadLine();

                        if (account.GetPassword().Equals(password))
                        {
                            AfterLogin(account);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Zle haslo");
                        }
                    }
                }
                else if( opcjaLogin == 2)
                {
                    ForgotPassword(account);
                    break;
                }
                else { Options(); break; }
            }

        }


        string[] newPassword = new string[2];

        void ForgotPassword(Account account)
        {
            Console.WriteLine("Podaj nowe haslo (1): ");
            newPassword[0] = Console.ReadLine();      
            
            Console.WriteLine("Podaj nowe haslo (2): ");
            newPassword[1] = Console.ReadLine();

            if (newPassword[0] != newPassword[1]) { ForgotPassword(account); }
            else
            {
                try {
                    account.SetPassword(newPassword[0]);
                    Console.WriteLine($"Haslo maila: '{account.Email}' zostało zmienione :)");
                    Options();
                }
                catch { Console.WriteLine("Haslo nie zostalo zmienione "); }
            }
        }


        Console.WriteLine("------CULWEBSITE------");
        Options();
        void AfterLogin(Account account)
        {
            Console.WriteLine($"------CULWEBSITE------\nWitamy ponownie Panie/ią: {account.GetFirstName()} {account.GetLastName()}\nTwoj email : {account.GetEmail()}");
        }
    }
}


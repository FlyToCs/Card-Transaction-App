// See https://aka.ms/new-console-template for more information

using Bank_Management_System.Extensions;
using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;
using Quiz2.Enums;
using Quiz2.Infrastructure.Persestens;
using Quiz2.Infrastructure.Repositories;
using Quiz2.Services;

AppDbContext context = new AppDbContext();

ICardRepository cardRepository = new CardRepository(context);
ITransactionRepository transactionRepository = new TransactionRepository(context);

ICardService cardService = new CardService(cardRepository);
ITransactionService transactionService = new TransactionService(transactionRepository, cardService);





AuthenticationMenu();










void AuthenticationMenu()
{
    while (true)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");

            Console.Write("\nEnter an option: ");
            int selectedOption = int.Parse(Console.ReadLine()!);

            switch (selectedOption)
            {
                case 1:
                    {
                        Console.Write("CardNumber: ");
                        var cardNumber = Console.ReadLine()!;

                        Console.Write("Password: ");
                        var password = Console.ReadLine()!;

                        var card = cardService.GetCardByNumber(cardNumber);
                        if (card.Password == password)
                            TransactionMenu();
                        else
                        {
                            ConsolePainter.RedMessage("the card number or password is incorrect");
                            Console.ReadKey();
                        }
                        
                        break;
                    }


                case 3:
                    Environment.Exit(1);
                    break;
            }
        }
        catch (Exception e)
        {
            ConsolePainter.RedMessage(e.Message);
            Console.ReadKey();
        }
    }
}



void TransactionMenu()
{
    while (true)
    {
        try
        {
            Console.Clear();
            Console.WriteLine("1. Transfer Money");
            Console.WriteLine("2. Show Transactions");
            Console.WriteLine("3. Logout");


            Console.Write("\nEnter an option: ");
            int selectedOption = int.Parse(Console.ReadLine()!);

            switch (selectedOption)
            {
                case 1:
                {
                    
                    break;
                }

                case 2:
                {
                    break;
                }


                case 3:
                    AuthenticationMenu();
                    break;
            }
        }
        catch (Exception e)
        {
            ConsolePainter.RedMessage(e.Message);
            Console.ReadKey();
        }
    }
}
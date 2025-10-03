// See https://aka.ms/new-console-template for more information

using Bank_Management_System.Extensions;
using Figgle.Fonts;
using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;
using Quiz2.Entities;
using Quiz2.Enums;
using Quiz2.Infrastructure.Persestens;
using Quiz2.Infrastructure.Repositories;
using Quiz2.Services;
using Spectre.Console;
using System;
using System.Xml;
Console.OutputEncoding = System.Text.Encoding.UTF8;

AppDbContext context = new AppDbContext();

ICardRepository cardRepository = new CardRepository(context);
ITransactionRepository transactionRepository = new TransactionRepository(context);

ICardService cardService = new CardService(cardRepository);
ITransactionService transactionService = new TransactionService(transactionRepository, cardService,context);




Console.WriteLine("version 0.0.1");
await AnsiConsole.Progress()
    .Columns(new ProgressColumn[]
    {
        new TaskDescriptionColumn(),
        new ProgressBarColumn(),
        new PercentageColumn(),
        new SpinnerColumn()
    })
    .StartAsync(async ctx =>
    {
        var dbTask = ctx.AddTask("[red]Connecting to database[/]");
        var appTask = ctx.AddTask("[yellow]Loading application[/]");
        var uiTask = ctx.AddTask("[green]Building UI[/]");

        while (!ctx.IsFinished)
        {
            await Task.Delay(150);

            dbTask.Increment(4.5);
            appTask.Increment(2.5);
            uiTask.Increment(3.5);
        }
    });

AnsiConsole.MarkupLine("[bold cyan]✔ Application started successfully![/]");
Console.ReadKey();


AuthenticationMenu();







Card? currentCard = null;


void AuthenticationMenu()
{
    while (true)
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(FiggleFonts.Standard.Render("Login"));
            Console.ResetColor();
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
                        {
                            currentCard = card;
                            TransactionMenu();
                        }
                        else
                        {
                            ConsolePainter.RedMessage("the card number or password is incorrect");
                            Console.ReadKey();
                        }
                        
                        break;
                    }


                case 2:
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(FiggleFonts.Standard.Render("Account Panel"));
            Console.ResetColor();
            Console.WriteLine("1. Transfer Money");
            Console.WriteLine("2. Show Transactions");
            Console.WriteLine("3. Logout");


            Console.Write("\nEnter an option: ");
            int selectedOption = int.Parse(Console.ReadLine()!);

            switch (selectedOption)
            {
                case 1:
                {
                    Console.Write("enter the destination Card: ");
                    var destinationCard = Console.ReadLine()!;

                    Console.Write("Enter amount: ");
                    var amount = int.Parse(Console.ReadLine()!);

                    var result = transactionService.TransferMoney(currentCard.CardNumber, destinationCard, amount);
                    if (result)
                    {
                        Console.WriteLine("the Operation finished successfully");
                    }
                    else
                    {
                        Console.WriteLine("failed");
                    }

                    Console.ReadKey();
                    break;
                }

                case 2:
                {
                    var transactions = transactionService.GetTransactionsByCardNumber(currentCard.CardNumber);

                    if (transactions == null || !transactions.Any())
                    {
                        AnsiConsole.MarkupLine("[red]No transactions found for this card.[/]");
                        Console.ReadKey();
                        break;
                    }

                    var table = new Table();
                    table.Border = TableBorder.Rounded;
                    table.Title("[bold cyan]Transaction History[/]");
                    table.AddColumn("[yellow]Amount[/]");
                    table.AddColumn("[yellow]Source Card[/]");
                    table.AddColumn("[yellow]Destination Card[/]");
                    table.AddColumn("[yellow]Transfer Time[/]");
                    table.AddColumn("[yellow]Status[/]");

                    foreach (var tx in transactions)
                    {
                        table.AddRow(
                            $"[green]{tx.Amount:C}[/]",
                            tx.SourceCard,
                            tx.DestinationCard,
                            tx.TransferTime.ToString("yyyy-MM-dd HH:mm"),
                            tx.IsSuccess ? "[bold green]✔ Success[/]" : "[bold red]✘ Failed[/]"
                        );
                    }

                    AnsiConsole.Write(table);
                    Console.ReadKey();
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
// See https://aka.ms/new-console-template for more information


using Figgle.Fonts;
using Quiz2.Contracts.Repository_Interfaces;
using Quiz2.Contracts.Service_Interfaces;
using Spectre.Console;
using Infrastructure.Persestens;
using DTOs;
using Infrastructure.Repositories;
using Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

AppDbContext context = new AppDbContext();

ICardRepository cardRepository = new CardRepository(context);
ITransactionRepository transactionRepository = new TransactionRepository(context);

ICardService cardService = new CardService(cardRepository);
ITransactionService transactionService = new TransactionService(transactionRepository, cardService,context);
IAuthenticationService authenticationService = new AuthenticationService(cardService);




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







GetCardDto? currentCard = null;


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

            var select = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Select an option[/]")
                    .HighlightStyle("yellow")
                    .AddChoices(new[] { "Login", "Exit" })
            );

            switch (select)
            {
                case "Login":
                    Console.WriteLine();
                    var cardNumber = AnsiConsole.Ask<string>("Enter your [yellow]Card Number[/]:");

                    var password = AnsiConsole.Prompt(
                        new TextPrompt<string>("Enter your [yellow]Password[/]:")
                            .PromptStyle("red")
                            .Secret('*')
                    );
                    currentCard = authenticationService.Login(cardNumber, password);

                    var card = cardService.GetCardByCardNumber(cardNumber);


                    
                    TransactionMenu();
                    break;

                case "Exit":
                    Environment.Exit(0);
                    break;
            }
        }
        catch (Exception e)
        {
            AnsiConsole.MarkupLine($"[bold red]❌ Error: {e.Message}[/]");
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

            var select = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold green]Select an option[/]")
                    .HighlightStyle("yellow")
                    .AddChoices(new[]
                    {
                        "💸 Transfer Money",
                        "📑 Show Transactions",
                        "🔑 Change Password",
                        "🚪 Logout"
                    })
            );

            switch (select)
            {
                case "💸 Transfer Money":
                {
                    var destinationCardNumber = AnsiConsole.Ask<string>("[yellow]Enter destination Card:[/]");
                    var amount = AnsiConsole.Ask<float>("[yellow]Enter amount:[/]");

                    if (amount <= 0)
                    {
                        AnsiConsole.MarkupLine("[bold red]✘ Amount must be greater than 0![/]");
                        Console.ReadKey();
                        break;
                    }

                    var destinationCard = cardService.GetCardDetails(destinationCardNumber);

                    float feePercent = amount > 1000 ? 0.015f : 0.005f;
                    float fee = amount * feePercent;
                    float totalDeduction = amount + fee;

                    var table = new Table().Border(TableBorder.Rounded);
                    table.AddColumn("Field");
                    table.AddColumn("Value");

                    table.AddRow("To (card)", destinationCard.CardNumber);
                    table.AddRow("Recipient name", destinationCard.PersonName ?? "-");

                    table.AddRow("Amount", $"{amount:0.00}");
                    table.AddRow("Fee (%)", $"{feePercent * 100:0.##}%");
                    table.AddRow("Fee (Amount)", $"{fee:0.00}");
                    table.AddRow("Total Deducted", $"{totalDeduction:0.00}");

                    AnsiConsole.Write(table);

                    bool confirm = AnsiConsole.Confirm("[green]Do you want to proceed with this transfer?[/]");
                    if (!confirm)
                    {
                        AnsiConsole.MarkupLine("[yellow]Transfer cancelled by user.[/]");
                        Console.ReadKey();
                        break;
                    }

                    var result = transactionService.TransferMoney(currentCard.CardNumber, destinationCardNumber, amount);

                    AnsiConsole.MarkupLine(result
                        ? "[bold green]✔ The operation finished successfully![/]"
                        : "[bold red]✘ Failed to complete the operation.[/]");

                    Console.ReadKey();
                    break;
                }



                case "📑 Show Transactions":
                    {
                        var transactions = transactionService.GetTransactionsByCardNumber(currentCard.CardNumber);

                        if (transactions == null || !transactions.Any())
                        {
                            AnsiConsole.MarkupLine("[red]No transactions found for this card.[/]");
                            Console.ReadKey();
                            break;
                        }

                        var table = new Table()
                            .Border(TableBorder.Rounded)
                            .Title("[bold cyan]📜 Transaction History[/]")
                            .Expand();

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

                case "🔑 Change Password":
                    
                    var newPassword = AnsiConsole.Ask<string>("[yellow]Enter new pass: [/]");

                    cardService.ChangePassword(currentCard.CardNumber, newPassword);
                    AnsiConsole.MarkupLine("[green]Password changed successfully[/]");
                    Console.ReadKey();
                    break;
                case "🚪 Logout":
                    AuthenticationMenu();
                    break;
            }
        }
        catch (Exception e)
        {
            AnsiConsole.MarkupLine($"[bold red]❌ Error: {e.Message}[/]");
            Console.ReadKey();
        }
    }
}

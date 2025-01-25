using ClassLibrary;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Bot;

public class TelegramBotService : IHostedService
{
    private static readonly ScheduleManager _scheduleManager = new();
    private readonly TelegramBotClient _botClient;

    public TelegramBotService()
    {
        var token = Token.GetToken();
        _botClient = new TelegramBotClient(token);
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var cts = new CancellationTokenSource();

        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        await _scheduleManager.ForceUpdateSchedule();

        _botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions,
            cancellationToken
        );

        var botInfo = await _botClient.GetMe();
        Console.WriteLine($"Bot {botInfo.Username} is running...");

        Console.ReadLine();

        await StopAsync(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        var cts = new CancellationTokenSource();
        cts.Cancel();
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        if (update.Message == null) return;
        var chatId = update.Message.Chat.Id;
        var messageText = update.Message.Text.ToLower();
        var firstName = update.Message.Chat.FirstName;
        Console.WriteLine($"Received a message from {firstName} {update.Message.Chat.Id}: {messageText}");
        var response = "";
        var isAdmin = update.Message.Chat.Id.ToString().Equals("427905464");

        switch (messageText)
        {
            case "/info":
                if (isAdmin)
                {
                    var amount = _scheduleManager.Schedule.Count.ToString();
                    response = $"Done. Amount of classes is: {amount}";
                }
                else
                {
                    response = "You are not allowed to use this command.";
                }

                break;
            case "/update":
                if (isAdmin)
                {
                    await _scheduleManager.ForceUpdateSchedule();
                    var amount = _scheduleManager.Schedule.Count.ToString();
                    response = $"Schedule is successfully updated! Amount of classes is: {amount}";
                }
                else
                {
                    response = "You are not allowed to use this command.";
                }
                break;
            case "/schedule":
                foreach (var scheduleItem in await _scheduleManager.GetScheduleFromDb("М411"))
                {
                    response += scheduleItem.GetString();
                }
                break;
            case "/start":
                response = "Welcome to Shitposted Bot!";
                break;
            default:
                messageText = messageText
                    .Replace('c', 'с')
                    .Replace('s', 'с')
                    .Replace('v', 'в')
                    .Replace('r', 'р')
                    .Replace('m', 'м')
                    .Replace('k', 'к')
                    .Replace('a', 'а')
                    .Replace('e', 'е')
                    .Replace('o', 'о')
                    .Replace('p', 'р')
                    .Replace('x', 'ч')
                    .Replace('b', 'в');
                foreach (var scheduleItem in await _scheduleManager.GetScheduleFromDb(messageText))
                {
                    response += scheduleItem.GetString();
                }
                break;
        }
        Console.WriteLine($"Sending message to {firstName} {chatId}: {response}");
        await botClient.SendMessage(chatId, response, cancellationToken: cancellationToken);
    }

    private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiEx => $"Telegram API Error:\n[{apiEx.ErrorCode}]\n{apiEx.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(errorMessage);
        return Task.CompletedTask;
    }
}
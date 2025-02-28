# SuaiScheduleBot
## Telegram Bot Token

The project uses [user-secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=windows) to store TelegramBotToken.  
How to use your token:
```shell
 
cd Bot
dotnet user-secrets init --id "11ee3ca7-2b58-45ee-80cb-a582881aa9b5"
dotnet user-secrets set "TelegramBot:Token" "YOUR_BOT_TOKEN"
```


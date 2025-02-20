# SuaiProject
## Telegram Bot Token

The project uses [user-secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=windows) to store TelegramBotToken.  
How to use your token:
```shell
 
cd Bot
dotnet user-secrets init
dotnet user-secrets set "TelegramBot:Token" "YOUR_BOT_TOKEN"
```


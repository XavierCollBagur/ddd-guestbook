using System;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Infrastructure.Services
{
    public class ConsoleMessageSenderService : IMessageSender
    {
        public void SendGuestbookNotificationEmail(string toAddress, string messageBody)
        {
            Console.WriteLine($"\n-------\nSend an email to {toAddress}: {messageBody}\n-------\n");
        }
    }
}
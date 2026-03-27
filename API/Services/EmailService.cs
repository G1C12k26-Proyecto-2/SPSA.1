using AppLogic.Interfaces;
using Azure;
using Azure.Communication.Email;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace API.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _connectionString;
        private readonly string _fromEmail;

        public EmailService(IConfiguration config)
        {
            _connectionString = config["AzureEmail:ConnectionString"];
            _fromEmail = config["AzureEmail:FromEmail"];
        }

        public void Send(string to, string subject, string plainTextBody, string htmlBody)
        {
            var client = new EmailClient(_connectionString);

            var emailContent = new EmailContent(subject)
            {
                PlainText = plainTextBody,
                Html = htmlBody
            };

            var emailMessage = new EmailMessage(
                senderAddress: _fromEmail,
                content: emailContent,
                recipients: new EmailRecipients(
                    new List<EmailAddress> { new EmailAddress(to) }
                )
            );

            EmailSendOperation operation = client.Send(
                WaitUntil.Completed,
                emailMessage
            );

            if (operation.HasCompleted && operation.Value.Status != EmailSendStatus.Succeeded)
            {
                throw new Exception("Email failed to send");
            }
        }
    }
}

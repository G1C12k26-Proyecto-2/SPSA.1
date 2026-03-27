using System;
using System.Collections.Generic;
using System.Text;

namespace AppLogic.Interfaces
{
    public interface IEmailService
    {
        void Send(string to, string subject, string plainTextBody, string htmlBody);
    }
}

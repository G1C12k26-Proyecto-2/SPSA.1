using System;
using System.Collections.Generic;
using System.Text;

namespace API.Interfaces
{
    public interface IEmailService
    {
        void Send(string to, string subject, string body);
    }
}

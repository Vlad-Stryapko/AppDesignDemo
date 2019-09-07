using ServicesAndRepos.Services.Interfaces.Emails;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAndRepos.Services
{
    public class EmailService : IEmailService
    {
        public Task SendAsync(object obj)
        {
            System.Diagnostics.Debug.WriteLine("Email has been sent");
            return Task.CompletedTask;
        }
    }
}

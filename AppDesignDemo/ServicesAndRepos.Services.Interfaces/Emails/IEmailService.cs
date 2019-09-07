using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAndRepos.Services.Interfaces.Emails
{
    public interface IEmailService
    {
        Task SendAsync(object obj);
    }
}

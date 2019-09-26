using Serilog;
using ServicesAndRepos.Services.Interfaces.Emails;
using System.Threading.Tasks;

namespace ServicesAndRepos.Services
{
    public class EmailService : IEmailService
    {
        public Task SendAsync(object obj)
        {
            Log.Information("Email will be sent");
            //some actual work
            Log.Information("Email has been sent");
            return Task.CompletedTask;
        }
    }
}

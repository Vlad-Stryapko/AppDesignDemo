using Serilog;
using System.Threading.Tasks;

namespace WorkflowsAndCqrs.Integration.Email
{
    public interface ISendEmailCommand
    {
        Task ExecuteAsync(object obj);
    }

    public sealed class SendEmailCommand : ISendEmailCommand
    {
        public Task ExecuteAsync(object obj)
        {
            Log.Information("Email will be sent");
            //some actual work
            Log.Information("Email has been sent");
            return Task.CompletedTask;
        }
    }
}

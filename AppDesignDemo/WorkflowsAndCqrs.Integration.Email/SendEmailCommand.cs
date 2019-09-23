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
            System.Diagnostics.Debug.WriteLine("Email has been sent");
            return Task.CompletedTask;
        }
    }
}

using System.Threading.Tasks;

namespace ServicesAndRepos.Services.Interfaces.Emails
{
    public interface IEmailService
    {
        Task SendAsync(object obj);
    }
}

using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrAndCqrs.Web.Application.Commands
{
    public class SendEmailCommandHandler : AsyncRequestHandler<SendEmailCommand>
    {
        protected override Task Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            Log.Information("Email will be sent");
            //some actual work
            Log.Information("Email has been sent");
            return Task.CompletedTask;
        }
    }
}

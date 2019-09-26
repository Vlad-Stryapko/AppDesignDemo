using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrAndCqrs.Web.Application.Commands
{
    public class SendEmailCommandHandler : AsyncRequestHandler<SendEmailCommand>
    {
        protected override Task Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine("Email has been sent");
            return Task.CompletedTask;
        }
    }
}

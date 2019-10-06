using MediatR;
using MediatrAndCqrs.Web.Application.Commands;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrAndCqrs.UnitTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleTest().Wait();
        }

        private static async Task ExampleTest()
        {
            //Discuss what happens
            var mediatrMock = new Mock<IMediator>();

            IRequestHandler<MakeOrderCommand> sut = new MakeOrderCommandHandler(mediatrMock.Object);

            await sut.Handle(new MakeOrderCommand { }, CancellationToken.None);
        }
    }
}

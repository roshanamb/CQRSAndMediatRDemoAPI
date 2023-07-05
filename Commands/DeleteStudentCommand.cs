using MediatR;

namespace CQRSAndMediatRDemoAPI.Commands
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}

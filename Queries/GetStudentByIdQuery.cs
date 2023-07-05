using CQRSAndMediatRDemoAPI.Models;
using MediatR;

namespace CQRSAndMediatRDemoAPI.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDetails>
    {
        public int Id { get; set; }
    }
}

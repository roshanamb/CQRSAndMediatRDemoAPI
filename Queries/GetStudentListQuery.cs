using CQRSAndMediatRDemoAPI.Models;
using MediatR;

namespace CQRSAndMediatRDemoAPI.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentDetails>>
    {
    }
}

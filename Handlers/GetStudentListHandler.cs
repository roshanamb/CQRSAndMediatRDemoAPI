using CQRSAndMediatRDemoAPI.Models;
using CQRSAndMediatRDemoAPI.Queries;
using CQRSAndMediatRDemoAPI.Repositories;
using MediatR;

namespace CQRSAndMediatRDemoAPI.Handlers
{
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery ,List<StudentDetails>>
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentListHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDetails>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentListAsync();
        }
    }
}

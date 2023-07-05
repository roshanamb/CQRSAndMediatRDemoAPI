using CQRSAndMediatRDemoAPI.Models;
using CQRSAndMediatRDemoAPI.Queries;
using CQRSAndMediatRDemoAPI.Repositories;
using MediatR;

namespace CQRSAndMediatRDemoAPI.Handlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<StudentDetails> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudentByIdAsync(request.Id);
        }
    }
}

using CQRSAndMediatRDemoAPI.Commands;
using CQRSAndMediatRDemoAPI.Models;
using CQRSAndMediatRDemoAPI.Repositories;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRSAndMediatRDemoAPI.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;
        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<StudentDetails> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetails = new StudentDetails()
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                Age = request.Age
            };

            return await _studentRepository.AddStudentAsync(studentDetails);
        }
    }
}

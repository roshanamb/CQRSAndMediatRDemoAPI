using CQRSAndMediatRDemoAPI.Commands;
using CQRSAndMediatRDemoAPI.Models;
using CQRSAndMediatRDemoAPI.Repositories;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRSAndMediatRDemoAPI.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(request.Id);
            if (studentDetails == null)
                return default;

            studentDetails.Name = request.Name;
            studentDetails.Email = request.Email;
            studentDetails.Address = request.Address;
            studentDetails.Age = request.Age;

            return await _studentRepository.UpdateStudentAsync(studentDetails);
        }
    }
}

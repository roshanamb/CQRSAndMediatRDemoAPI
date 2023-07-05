using CQRSAndMediatRDemoAPI.Models;
using MediatR;

namespace CQRSAndMediatRDemoAPI.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public UpdateStudentCommand(int studentId, string studentName, string studentEmail, string studentAddress, int studentAge)
        {
            Id = studentId;
            Name = studentName;
            Email = studentEmail;
            Address = studentAddress;
            Age = studentAge;
        }
    }
}

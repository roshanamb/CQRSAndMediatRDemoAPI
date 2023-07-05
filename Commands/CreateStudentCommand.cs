using CQRSAndMediatRDemoAPI.Models;
using MediatR;

namespace CQRSAndMediatRDemoAPI.Commands
{
    public class CreateStudentCommand : IRequest<StudentDetails>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public CreateStudentCommand(string studentName, string studentEmail, string studentAddress, int studentAge)
        {
            Name = studentName;
            Email = studentEmail;
            Address = studentAddress;
            Age = studentAge;
        }
    }
}

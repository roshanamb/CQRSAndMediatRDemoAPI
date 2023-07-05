using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CQRSAndMediatRDemoAPI.Data;
using CQRSAndMediatRDemoAPI.Models;
using MediatR;
using CQRSAndMediatRDemoAPI.Queries;
using CQRSAndMediatRDemoAPI.Commands;

namespace CQRSAndMediatRDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<IEnumerable<StudentDetails>> GetStudentListAsync()
        {
            return await mediator.Send(new GetStudentListQuery()); ;
        }

        // GET: api/Student/5
        [HttpGet("{studentId}")]
        public async Task<StudentDetails> GetStudentByIdAsync(int studentId)
        {
          return await mediator.Send(new GetStudentByIdQuery() { Id = studentId });
        }

        // POST: api/Student
        [HttpPost]
        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var studentDetail = await mediator.Send(new CreateStudentCommand( studentDetails.Name,studentDetails.Email,studentDetails.Address,studentDetails.Age));
            return studentDetail;
        }

        // PUT: api/Student
        [HttpPut]
        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            var isStudentDetailUpdated = await mediator.Send(new UpdateStudentCommand(studentDetails.Id, studentDetails.Name, studentDetails.Email, studentDetails.Address, studentDetails.Age));
            return isStudentDetailUpdated;
        }

        // DELETE: api/Student
        [HttpDelete("{studentId}")]
        public async Task<int> DeleteStudentAsync(int studentId)
        {
            return await mediator.Send(new DeleteStudentCommand() { Id = studentId });
        }
    }
}

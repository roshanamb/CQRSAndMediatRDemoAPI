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
        public async Task<IEnumerable<StudentDetails>> GetStudents()
        {
            return await mediator.Send(new GetStudentListQuery()); ;
        }

        // GET: api/Student/5
        [HttpGet("{studentId}")]
        public async Task<StudentDetails> GetStudentDetails(int studentId)
        {
          return await mediator.Send(new GetStudentByIdQuery() { Id = studentId });
        }

        
    }
}

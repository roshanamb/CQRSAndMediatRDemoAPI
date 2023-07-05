using CQRSAndMediatRDemoAPI.Data;
using CQRSAndMediatRDemoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CQRSAndMediatRDemoAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext dbContext;

        public StudentRepository(StudentDbContext studentDbContext)
        {
            dbContext = studentDbContext;
        }

        public async Task<StudentDetails> AddStudentAsync(StudentDetails studentDetails)
        {
            var result = dbContext.Students.Add(studentDetails); 
            await dbContext.SaveChangesAsync();
            return result.Entity; 
        }

        public async Task<int> DeleteStudentAsync(int Id)
        {
            var filteredData = dbContext.Students.Where(x => x.Id == Id).FirstOrDefault();
            dbContext.Students.Remove(filteredData);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int Id)
        {
            return await dbContext.Students.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<StudentDetails>> GetStudentListAsync()
        {
            return await dbContext.Students.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(StudentDetails studentDetails)
        {
            dbContext.Students.Update(studentDetails);
            return await dbContext.SaveChangesAsync();
        }
    }
}

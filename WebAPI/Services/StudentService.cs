using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.ViewModel;

namespace WebAPI.Services
{
    public class StudentService
    {
        private readonly WebAPIContext _context;
        public StudentService(WebAPIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StudentVm>> GetAllStudentsAsync()
        {
            return await _context.Student
                                    .Select(s => new StudentVm { Address = s.Address, FullName = $"{s.FirstName} {s.LastName}" })
                                    .ToListAsync();
        }

        public async Task<StudentVm> CreateNewStudentAsync(NewStudentVm studentVm)
        {
            var student = new Student
            {
                FirstName = studentVm.FirstName,
                LastName = studentVm.LastName,
                Address = studentVm.Address
            };

            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
            var responseStudent = new StudentVm
            {
                Address = student.Address,
                FullName = $"{student.FirstName} {student.LastName}"
            };

            return await Task.FromResult(responseStudent);
        }
        
    }
}

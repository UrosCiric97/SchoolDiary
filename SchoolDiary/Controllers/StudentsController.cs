using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDiary.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private DataContext _context;
        private Mapper _mapper;
        private IStudentRepository _studentRepository;
        public StudentsController(DataContext context, Mapper mapper, IStudentRepository studentRepository)
        {
            _context = context;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddStudents(IEnumerable<Student> students)
		{
            if (!ValidateStudentsInput(students))
            {
                return BadRequest("Invalid students input");
            }
			var result = await _studentRepository.AddStudentsAsync(students);
            if (result)
            {
                return Ok();
            }
            return NotFound();
		}
        private bool ValidateStudentsInput(IEnumerable<Student> students)
        {
            var fifthGradeCounter = 0;
            var sixthGradeCounter = 0;
            foreach (var student in students)
            {
                if (student.Class.Value == 5)
                {
                    fifthGradeCounter = fifthGradeCounter++;  
                }
                if (student.Class.Value == 6)
                {
                    sixthGradeCounter = sixthGradeCounter++;
                }
            }
            if (fifthGradeCounter == 20 && sixthGradeCounter == 20 && students.Count() == 40)
            {
                return true;
            }
            return false;
        }
	}
}

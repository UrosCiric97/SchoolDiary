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
    public class TeachersController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;
        private ITeacherRepository _teacherRepository;
        public TeachersController(DataContext context, IMapper mapper, ITeacherRepository teacherRepository)
        {
            _context = context;
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddRange(IEnumerable<Teacher> teachers)
        {
            if (teachers.Count() != 5)
            {
                return NotFound("You need to add 5 teachers");
            }
            var result = await _teacherRepository.AddRangeAsync(teachers);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

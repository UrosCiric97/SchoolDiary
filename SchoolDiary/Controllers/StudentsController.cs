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
    }
}

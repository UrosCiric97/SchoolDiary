using AutoMapper;
using Domain;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementations
{
    public class StudentRepository : Repository<User>, IStudentRepository
    {
        private DataContext _context;
        private IMapper _mapper;
        public StudentRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

		public async Task<bool> AddStudentsAsync(IEnumerable<User> students)
		{
            _context.Students.AddRange(students);
            return await _context.SaveChangesAsync() > 0;

		}
	}
}

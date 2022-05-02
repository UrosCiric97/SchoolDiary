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
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private DataContext _context;
        private IMapper _mapper;
        public TeacherRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}

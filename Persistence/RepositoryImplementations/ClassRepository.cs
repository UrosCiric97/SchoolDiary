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
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        private DataContext _context;
        private IMapper _mapper;
        public ClassRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}

using AutoMapper;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.RepositoryImplementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _context;
        private IMapper _mapper;
        public Repository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

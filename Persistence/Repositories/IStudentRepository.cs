using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IStudentRepository : IRepository<User>
    {
        Task<bool> AddStudentsAsync(IEnumerable<User> students);
    }
}

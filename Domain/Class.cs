using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Class
    {
        public Guid Id { get; set; }
        public ICollection<Student> Students { get; set; }
        public Teacher ClassElder { get; set; }
    }
}

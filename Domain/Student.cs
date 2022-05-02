using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Class Class { get; set; }
        public Address Address { get; set; }
        public ICollection<int> Grades { get; set; }

    }
}

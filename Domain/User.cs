using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class User : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string DisplayName { get; set; }

		public Guid? ClassId { get; set; }
		public Guid? AddressId { get; set; }
		public string RoleId { get; set; }
		public Guid? GradeId { get; set; }

		public Class Class { get; set; }
		public Address Address { get; set; }
		public Role Role { get; set; }
		public List<StudentGrade> Grades { get; set; }
	}
}

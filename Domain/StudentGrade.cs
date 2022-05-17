using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class StudentGrade
	{
		public Guid StudentId { get; set; }
		public Guid GradeId { get; set; }
		public Student Student { get; set; }
		public Grade Grade { get; set; }
	}
}

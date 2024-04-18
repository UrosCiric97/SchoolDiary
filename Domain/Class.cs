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
		public ICollection<User> Students { get; set; }
		public string ClassElderId { get; set; }
		public User ClassElder { get; set; }
		public int Value { get; set; }
	}
}

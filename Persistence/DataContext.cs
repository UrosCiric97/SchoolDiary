using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
	public class DataContext : IdentityDbContext<User>
	{
		public DataContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<User> Students { get; set; }
		public DbSet<User> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<StudentGrade>(x => x.HasKey(sg => new { sg.StudentId, sg.GradeId }));

			modelBuilder.Entity<StudentGrade>()
				.HasOne(s=> s.Student)
				.WithMany(g=> g.Grades)
				.HasForeignKey(s=>s.StudentId)
				.OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<StudentGrade>()
				.HasOne(g => g.Grade)
				.WithMany(s => s.Students)
				.HasForeignKey(g => g.GradeId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}

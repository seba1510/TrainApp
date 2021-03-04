using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainApp.Models
{
	public class ExerciseManagerContext : DbContext
	{
		public ExerciseManagerContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<ExerciseModel> Exercises { get; set; }
	}
}

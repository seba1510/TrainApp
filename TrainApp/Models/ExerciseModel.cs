using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainApp.Models
{
	[Table("Exercises")]
	public class ExerciseModel
	{
		[Key]
		[DisplayName("Exercise Number")]
		public int ExerciseId { get; set; }
		[Required(ErrorMessage ="Enter name")]
		[MaxLength(50)]
		public string Name { get; set; }
		[Required(ErrorMessage = "Enter muscle")]
		[MaxLength(50)]
		public string Muscle { get; set; }
		[DisplayName("Add to training")]
		public bool Add { get; set; }
		public bool Done { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainApp.Models;

namespace TrainApp.Repositories
{
	public class ExerciseRepository : IExerciseRepository
	{
		private readonly ExerciseManagerContext _context;
		public ExerciseRepository(ExerciseManagerContext context)
		{
			_context = context;
		}

		public void  Add(ExerciseModel exercise)
		{
			_context.Exercises.Add(exercise);
			_context.SaveChanges();
		}

		public void Delete(int exerciseId)
		{
			var result = _context.Exercises.SingleOrDefault(x => x.ExerciseId == exerciseId);
			if (result != null)
			{
				_context.Exercises.Remove(result);
				_context.SaveChanges();
			}
		}

		public ExerciseModel Get(int exerciseId)
		=> _context.Exercises.SingleOrDefault(x => x.ExerciseId == exerciseId);

		public IQueryable<ExerciseModel> GetAllActive()
		=> _context.Exercises;
		public IQueryable<ExerciseModel> GetAllActiveTraining()
		=> _context.Exercises.Where(x => x.Add == true);

		public void Update(int exerciseId, ExerciseModel exercise)
		{
			var result = _context.Exercises.SingleOrDefault(x => x.ExerciseId == exerciseId);
			if(result != null)
			{
				result.Name = exercise.Name;
				result.Muscle = exercise.Muscle;
				result.Add = exercise.Add;
				result.Done = exercise.Done;

				_context.SaveChanges();
			}
		}
	}
}

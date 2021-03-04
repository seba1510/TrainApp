using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainApp.Models;

namespace TrainApp.Repositories
{
	public interface IExerciseRepository
	{
		ExerciseModel Get(int ExerciseId);
		IQueryable<ExerciseModel> GetAllActive();
		IQueryable<ExerciseModel> GetAllActiveTraining();
		void Add(ExerciseModel exercise);
		void Update(int exerciseId, ExerciseModel exercise);
		void Delete(int exerciseId);
	}
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainApp.Models;
using TrainApp.Repositories;

namespace TrainApp.Controllers
{
	public class ExerciseController : Controller
	{
		private readonly IExerciseRepository _exerciseRepository;
		public ExerciseController(IExerciseRepository exerciseRepository)
		{
			_exerciseRepository = exerciseRepository;
		}
		
		public ActionResult Index()
		{
			return View(_exerciseRepository.GetAllActive());
		}

		
		public ActionResult IndexTraining()
		{
			return View(_exerciseRepository.GetAllActiveTraining());
		}

		public ActionResult MainIndex()
		{
			return View();
		}

		public ActionResult Details(int id)
		{
			return View(_exerciseRepository.Get(id));
		}

		public ActionResult Create()
		{
			return View(new ExerciseModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ExerciseModel exerciseModel)
		{
			_exerciseRepository.Add(exerciseModel);

			return RedirectToAction(nameof(Create));
		}

		public ActionResult Edit(int id)
		{
			return View(_exerciseRepository.Get(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, ExerciseModel exerciseModel)
		{
			_exerciseRepository.Update(id, exerciseModel);
			return RedirectToAction(nameof(Index));
		}

		public ActionResult Delete(int id)
		{
			return View(_exerciseRepository.Get(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, ExerciseModel exerciseModel)
		{
			_exerciseRepository.Delete(id);
			return RedirectToAction(nameof(Index));
		}

		public ActionResult Add(int id)
		{
			ExerciseModel exercise = _exerciseRepository.Get(id);
			exercise.Add = true;
			_exerciseRepository.Update(id, exercise);
			return RedirectToAction(nameof(Index));
		}
		public ActionResult Remove(int id)
		{
			ExerciseModel exercise = _exerciseRepository.Get(id);
			exercise.Add = false;
			_exerciseRepository.Update(id, exercise);
			return RedirectToAction(nameof(IndexTraining));
		}


	}
}

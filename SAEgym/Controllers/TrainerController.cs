using Microsoft.AspNetCore.Mvc;
using SAEgym.App_Data;
using SAEgym.Models;

namespace SAEgym.Controllers
{
    public class TrainerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTrainer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainer(DataContext dataContext, Trainer trainer)
        {
            Trainer trainerModel = new Trainer()
            {
                Id = trainer.Id,
                Username = trainer.Username,
                Password = trainer.Password,
                Member = trainer.Member
            };

            await dataContext
                .Trainers
                .AddAsync(trainerModel);

            await dataContext
                .SaveChangesAsync();

            return View("AddTrainer");
        }

        [HttpGet]
        public IActionResult UpdateTrainer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTrainer(DataContext dataContext, Trainer trainer)
        {
            var trainerModel = await dataContext.Trainers.FindAsync(trainer.Id);

            if (trainerModel != null)
            {
                trainerModel.Username = trainer.Username;
                trainerModel.Password = trainer.Password;
                trainerModel.Member = trainer.Member;

                await dataContext.SaveChangesAsync();
                return RedirectToAction("TrainerList");
            }

            return RedirectToAction("TrainerList");
        }

        [HttpGet]
        public IActionResult DeleteTrainer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTrainer(DataContext dataContext, Trainer trainer)
        {
            var trainerModel = await dataContext.Trainers.FindAsync(trainer.Id);

            if (trainerModel != null)
            {
                dataContext.Remove(trainer);

                await dataContext.SaveChangesAsync();
            }

            return View("DeleteTrainer");
        }
    }
}

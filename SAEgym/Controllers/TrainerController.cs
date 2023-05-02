using Microsoft.AspNetCore.Mvc;
using SAEgym.App_Data;
using SAEgym.Models;
using System.Diagnostics;

namespace SAEgym.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

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
        public async Task<IActionResult> AddTrainer(Trainer trainer)
        {
            Trainer trainerModel = new Trainer()
            {
                Id = trainer.Id,
                Username = trainer.Username,
                Password = trainer.Password,
                Member = trainer.Member
            };

            await _dataContext
                .Trainers
                .AddAsync(trainerModel);

            await _dataContext
                .SaveChangesAsync();

            return View("AddTrainer");
        }

        [HttpGet]
        public IActionResult UpdateTrainer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTrainer(Trainer trainer)
        {
            var trainerModel = await _dataContext.Trainers.FindAsync(trainer.Id);

            if (trainerModel != null)
            {
                trainerModel.Username = trainer.Username;
                trainerModel.Password = trainer.Password;
                trainerModel.Member = trainer.Member;

                await _dataContext.SaveChangesAsync();
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
        public async Task<IActionResult> DeleteTrainer(Trainer trainer)
        {
            var trainerModel = await _dataContext.Trainers.FindAsync(trainer.Id);

            if (trainerModel != null)
            {
                _dataContext.Remove(trainer);

                await _dataContext.SaveChangesAsync();
            }

            return View("DeleteTrainer");
        }
    }
}

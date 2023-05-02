using Microsoft.AspNetCore.Mvc;
using SAEgym.App_Data;
using SAEgym.Models;
using System.Diagnostics;

namespace SAEgym.Controllers
{
    public class ClassController : Controller
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
        public IActionResult AddClass()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClass(Class clasa)
        {
            Class classModel = new Class()
            {
                Id = clasa.Id,
                ClassName = clasa.ClassName,
                OrganisationDate = clasa.OrganisationDate,
                Trainer = clasa.Trainer
            };

            await _dataContext
                .Classes
                .AddAsync(classModel);

            await _dataContext
                .SaveChangesAsync();

            return View("AddClass");
        }

        [HttpGet]
        public IActionResult UpdateClass()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClass(Class clasa)
        {
            var classModel = await _dataContext.Classes.FindAsync(clasa.Id);

            if (classModel != null)
            {
                classModel.ClassName = clasa.ClassName;
                classModel.OrganisationDate = clasa.OrganisationDate;
                classModel.Trainer = clasa.Trainer;

                await _dataContext.SaveChangesAsync();
                return RedirectToAction("ClassList");
            }

            return RedirectToAction("ClassList");
        }

        [HttpGet]
        public IActionResult DeleteClass()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClass(Class clasa)
        {
            var classModel = await _dataContext.Classes.FindAsync(clasa.Id);

            if (classModel != null)
            {
                _dataContext.Remove(clasa);

                await _dataContext.SaveChangesAsync();
            }

            return View("DeleteClass");
        }
    }
}
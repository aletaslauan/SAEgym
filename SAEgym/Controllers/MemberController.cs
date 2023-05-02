using Microsoft.AspNetCore.Mvc;
using SAEgym.App_Data;
using SAEgym.Models;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace SAEgym.Controllers
{
    public class MemberController : Controller
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
        public IActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(Member member)
        {
            Member memberModel = new Member()
            {
                Id = member.Id,
                Username = member.Username,
                Password = member.Password,
                Email = member.Email,
                Subscription = member.Subscription,
                FirstSubscriptionDay = member.FirstSubscriptionDay,
                Trainer = member.Trainer
            };

            await _dataContext
                .Members
                .AddAsync(memberModel);

            await _dataContext
                .SaveChangesAsync();

            return View("AddMember");
        }

        [HttpGet]
        public IActionResult UpdateMember()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMember(Member member)
        {
            var memberModel = await _dataContext.Members.FindAsync(member.Id);

            if (memberModel != null)
            {
                memberModel.Username = member.Username,
                memberModel.Password = member.Password,
                memberModel.Email = member.Email,
                memberModel.Subscription = member.Subscription,
                memberModel.FirstSubscriptionDay = member.FirstSubscriptionDay,
                memberModel.Trainer = member.Trainer

                await _dataContext.SaveChangesAsync();
                return RedirectToAction("MemberList");
            }

            return RedirectToAction("MemberList");
        }

        [HttpGet]
        public IActionResult DeleteMember()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMember(Member member)
        {
            var memberModel = await _dataContext.Members.FindAsync(member.Id);

            if (memberModel != null)
            {
                _dataContext.Remove(member);

                await _dataContext.SaveChangesAsync();
            }

            return View("DeleteMember");
        }
    }
}

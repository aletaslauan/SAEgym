using Microsoft.AspNetCore.Mvc;
using SAEgym.App_Data;
using SAEgym.Models;
using System.Diagnostics;

namespace SAEgym.Controllers
{
    public class SubscriptionController : Controller
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
        public IActionResult AddSubscription()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscription(Subscription subscription)
        {
            Subscription subscriptionModel = new Subscription()
            {
                Id = subscription.Id,
                SubscriptionName = subscription.SubscriptionName,
                Price = subscription.Price,
                IsStudent = subscription.IsStudent
            };

            await _dataContext
                .Subscriptions
                .AddAsync(subscriptionModel);

            await _dataContext
                .SaveChangesAsync();

            return View("AddSubscription");
        }

        [HttpGet]
        public IActionResult UpdateSubscription()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscription(Subscription subscription)
        {
            var subscriptionModel = await _dataContext.Subscriptions.FindAsync(subscription.Id);

            if (subscriptionModel != null)
            {
                subscriptionModel.SubscriptionName = subscription.SubscriptionName;
                subscriptionModel.Price = subscription.Price;
                subscriptionModel.IsStudent = subscription.IsStudent;

                await _dataContext.SaveChangesAsync();
                return RedirectToAction("SubscriptionList");
            }

            return RedirectToAction("SubscriptionList");
        }

        [HttpGet]
        public IActionResult DeleteSubscription()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSubscription(Subscription subscription)
        {
            var subscriptionModel = await _dataContext.Subscriptions.FindAsync(subscription.Id);

            if (subscriptionModel != null)
            {
                _dataContext.Remove(subscription);

                await _dataContext.SaveChangesAsync();
            }

            return View("DeleteSubscription");
        }
    }
}

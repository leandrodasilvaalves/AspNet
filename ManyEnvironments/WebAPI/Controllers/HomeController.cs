using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClock _clock;

        public HomeController(IClock clock) => _clock = clock;

        public string Index() => $"It is { _clock.GetTime().ToString()}";
    }
}

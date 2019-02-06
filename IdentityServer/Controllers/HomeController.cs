using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityServer4.Services;
using IdentityServer4.Quickstart.UI.Models;
using IdentityServer.Resources;
using IdentityServer.Models;
using Microsoft.Extensions.Options;

namespace IdentityServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly LocService _locService;
        private readonly GeneralConfig _generalConfig;

        public HomeController(IIdentityServerInteractionService interaction, LocService locService, IOptions<GeneralConfig> generalConfig)
        {
            _interaction = interaction;
            _locService = locService;
            _generalConfig = generalConfig.Value;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = _locService.GetLocalizedHtmlString("WELCOME_BACK");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult NavigateToTheApp()
        {
            return Redirect(_generalConfig.AppUri);
        }

        /// <summary>
        /// Shows the error page
        /// </summary>
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;
            }

            return View("Error", vm);
        }
    }
}

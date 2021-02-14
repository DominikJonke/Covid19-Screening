﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CoronaTest.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostRegistrationBtn_Click()
        {
            return RedirectToPage("./Participants/Registration");
        }

        public IActionResult OnPostLogInBtn_Click()
        {
            return RedirectToPage("./Security/Login");
        }
    }
}

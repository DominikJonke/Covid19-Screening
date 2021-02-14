using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaTest.Web.Pages.Security
{
    public class SuccessModel : PageModel
    {
        public void OnGet(Guid verificationIdentifier)
        {
            //TODO: Token verifizieren
        }
    }
}

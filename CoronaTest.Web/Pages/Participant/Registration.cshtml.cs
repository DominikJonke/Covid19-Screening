using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CoronaTest.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaTest.Web.Pages.Participant
{
    public class RegistrationModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Participant Participant { get; set; }

        public void OnGet()
        {
            Participant = new Participant();
        }

        public async Task<IActionResult> OnPost()
        {
            await _unitOfWork.ParticipantRepository.AddAsync(Participant);
            try
            {
                await _unitOfWork.SaveChangesAsync();

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
                return Page();
            }
            return RedirectToPage("../Index");
        }


    }
}
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CoronaTest.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaTest.Web.Pages.Participant
{
    public class EditParticipantModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Participant Participant { get; set; }

        public EditParticipantModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var participantInDb = await _unitOfWork.ParticipantRepository.GetByIdAsync(Participant.Id);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");
                return Page();
            }

            return RedirectToPage("./Participant/LogIn");
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CoronaTest.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaTest.Web.Pages.Participant
{
        public class EditParticipantsModel : PageModel
        {
            private readonly IUnitOfWork _unitOfWork;
            [BindProperty]
            public Core.Entities.Participant Participant { get; set; }

            public EditParticipantsModel(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IActionResult> OnGet()
            {

                // Participant = new Participant();
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
                return RedirectToPage("./Participants/LogIn");
            }
        }
    }

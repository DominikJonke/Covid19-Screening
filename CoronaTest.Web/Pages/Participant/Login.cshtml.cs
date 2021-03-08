using System.Threading.Tasks;
using CoronaTest.Core.Contracts;
using CoronaTest.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoronaTest.Web.Pages.Participant
{
    public class LoginModel : PageModel
    {
        public class LogInModel : PageModel
        {

            private readonly IUnitOfWork _unitOfWork;

            public Examination[] Examinations { get; set; }

            [BindProperty]
            public Core.Entities.Participant Participant { get; set; }


            public LogInModel(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IActionResult> OnGet()
            {
                Examinations = await _unitOfWork.ExaminationRepository.GetExaminationByParticipant(Participant.Id);

                return Page();
            }

            public IActionResult OnPostNewExaminationBtn_Click()
            {
                return RedirectToPage("./Examination/Create");
            }

            public IActionResult OnPostCancelBtn_Click()
            {
                return RedirectToPage("../Index");
            }
        }
    }
}

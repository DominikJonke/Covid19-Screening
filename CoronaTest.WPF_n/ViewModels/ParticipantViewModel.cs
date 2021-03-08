using CoronaTest.WPF_n.Common;
using CoronaTest.WPF_n.Common.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoronaTest.WPF_n.ViewModels
{
    public class ParticipantViewModel : BaseViewModel
    {
        public ParticipantViewModel(IWindowController controller) : base(controller)
        {
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}

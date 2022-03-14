using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.Application.Commands
{
    public class CreateFileCommandValidator :AbstractValidator<CreateFileCommand>
    {
        public CreateFileCommandValidator()
        {
            RuleFor(x => x.FormFile).NotNull().WithMessage("Form File Is Required");
        }
    }
}

using FluentValidation;

namespace TaskFlow.Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MinimumLength(10).WithMessage("Açıklama en az 10 karakter olmalıdır.");

            RuleFor(x => x.DueDate)
                .NotNull().WithMessage("Son teslim tarihi boş olamaz.")
                .GreaterThan(DateTime.Now).WithMessage("Son teslim tarihi bugünden ileri olmalı.");
        }
    }
}

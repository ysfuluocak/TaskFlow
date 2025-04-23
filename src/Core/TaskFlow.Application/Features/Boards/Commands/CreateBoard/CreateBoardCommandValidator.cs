using FluentValidation;
using TaskFlow.Application.Features.Boards.Commands.CreateBoard;

public class CreateBoardCommandValidator : AbstractValidator<CreateBoardCommand>
{
    public CreateBoardCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Board adı boş olamaz.")
            .MaximumLength(150).WithMessage("Board adı 150 karakterden uzun olamaz.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Board açıklaması 1000 karakterden uzun olamaz.");

        RuleFor(x => x.CreatedById)
            .NotEmpty().WithMessage("Oluşturan kullanıcı ID boş olamaz.");
    }
}
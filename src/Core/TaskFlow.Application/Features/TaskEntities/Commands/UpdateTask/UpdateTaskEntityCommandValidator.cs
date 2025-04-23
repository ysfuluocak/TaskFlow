using FluentValidation;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Features.TaskEntities.Commands.UpdateTask
{
    public class UpdateTaskEntityCommandValidator : AbstractValidator<UpdateTaskEntityCommand>
    {
        public UpdateTaskEntityCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Güncellenecek Task ID'si boş olamaz.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(200).WithMessage("Başlık 200 karakterden uzun olamaz.");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Açıklama 2000 karakterden uzun olamaz.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Görev tipi belirtilmelidir.")
                .IsEnumName(typeof(TaskType), caseSensitive: false).WithMessage("Geçersiz görev tipi.");

            RuleFor(x => x.Priority)
                .NotEmpty().WithMessage("Öncelik seviyesi belirtilmelidir.")
                .IsEnumName(typeof(TaskPriority), caseSensitive: false).WithMessage("Geçersiz öncelik seviyesi.");

            RuleFor(x => x.AssignedToId)
                .NotEmpty().WithMessage("Atanan kullanıcı ID boş olamaz.");

            RuleFor(x => x.AssignedById)
                .NotEmpty().WithMessage("Atayan kullanıcı ID boş olamaz.");

            RuleFor(x => x.BoardId)
                .NotEmpty().WithMessage("Board ID boş olamaz.");

            RuleFor(x => x.StatusStepId)
                .NotEmpty().WithMessage("Durum Adımı ID boş olamaz."); ;
        }
    }
}

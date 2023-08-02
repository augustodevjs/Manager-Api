using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("A Entidade não pode ser vazia.")
            .NotNull().WithMessage("A Entidade não pode ser nula.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O Nome não pode ser vazio.")
            .NotNull().WithMessage("O Nome não pode Ser nulo.")
            .MinimumLength(3).WithMessage("O Nome deve ter no minimo 3 caracteres.")
            .MaximumLength(80).WithMessage("O Nome deve ter no máximo 80 caracteres.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O Email não pode ser vazio")
            .NotNull().WithMessage("O Email não pode Ser nulo")
            .MinimumLength(3).WithMessage("O Email deve ter no minimo 3 caracteres")
            .MaximumLength(80).WithMessage("O Email deve ter no máximo 100 caracteres")
            .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
            .WithMessage("Email inválido");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("A senha não pode ser vazia")
            .NotNull().WithMessage("A senha não pode ser vazia")
            .MinimumLength(3).WithMessage("A senha deve ter no minimo 3 caracteres")
            .MaximumLength(80).WithMessage("A senha deve ter no máximo 80 caracteres");
    }
}
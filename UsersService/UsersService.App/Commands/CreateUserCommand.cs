using FluentValidation;
using MediatR;
using UsersService.Domain.Enums;

namespace UsersService.App.Commands
{
    public class CreateUserCommand : IRequest<bool>
    {
        protected CreateUserCommand() : base() { }

        public CreateUserCommand(string nome, string sobrenome, string email, DateTime dataNascimento, Escolaridade escolaridade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
    }

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(i => i.DataNascimento)
                .LessThanOrEqualTo(DateTime.Today)
                .WithMessage(Messages.Birthday_GreaterThanToday);

            RuleFor(i => i.Escolaridade)
                .IsInEnum()
                .WithMessage(Messages.Schooling_NotInEnum);

            RuleFor(i => i.Email)
                .EmailAddress()
                .WithMessage(Messages.Email_Incorrect);
        }
    }
}

using FluentValidation;
using MediatR;
using UsersService.Domain.Enums;

namespace UsersService.App.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        protected UpdateUserCommand() : base() { }

        public UpdateUserCommand(int id, string nome, string sobrenome, string email, DateTime dataNascimento, Escolaridade escolaridade)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
    }

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
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

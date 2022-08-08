using UsersService.Domain.Enums;

namespace UsersService.App.ViewModel
{
    public class UserView
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Escolaridade Escolaridade { get; private set; }
    }
}

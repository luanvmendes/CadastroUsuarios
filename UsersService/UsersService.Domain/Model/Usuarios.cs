using UsersService.Domain.Enums;

namespace UsersService.Domain.Model
{
    public class Usuarios
    {
        public Usuarios(string nome, string sobrenome, string email, DateTime dataNascimento
            , Escolaridade escolaridade)
        {
            SetFields(nome, sobrenome, email, dataNascimento, escolaridade);
        }

        public Usuarios Update(int id, string nome, string sobrenome, string email, DateTime dataNascimento
            , Escolaridade escolaridade)
        {
            Id = id;
            SetFields(nome, sobrenome, email, dataNascimento, escolaridade);
            return this;
        }

        protected void SetFields(string nome, string sobrenome, string email, DateTime dataNascimento
            , Escolaridade escolaridade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Escolaridade Escolaridade { get; private set; }
    }
}

using AutoMapper;
using UsersService.App.Commands;
using UsersService.App.ViewModel;
using UsersService.Domain.Model;

namespace UsersService.App.Adapter
{
    public class UserAdapter : IUserAdapter
    {
        private readonly IMapper _mapper;

        public UserAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Usuarios ConvertToDomain(CreateUserCommand command)
        {
            if (command == null) return null;

            return new Usuarios(command.Nome, command.Sobrenome, command.Email, command.DataNascimento
                , command.Escolaridade);
        }

        public Usuarios ConvertToDomain(UpdateUserCommand command, Usuarios existing)
        {
            if (command == null || existing == null) return null;

            return existing.Update(existing.Id, command.Nome, command.Sobrenome, command.Email, command.DataNascimento
                , command.Escolaridade);
        }

        public ICollection<UserView> ConvertToView(ICollection<Usuarios> domains)
        {
            return _mapper.Map<ICollection<UserView>>(domains);
        }

        public UserView ConvertToView(Usuarios domain)
        {
            return _mapper.Map<UserView>(domain);
        }
    }

    public class UserAdapterMapper : Profile
    {
        public UserAdapterMapper()
        {
            CreateMap<Usuarios, UserView>();
        }
    }
}

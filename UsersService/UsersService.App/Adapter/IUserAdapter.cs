using UsersService.App.Commands;
using UsersService.App.ViewModel;
using UsersService.Domain.Model;

namespace UsersService.App.Adapter
{
    public interface IUserAdapter
    {
        Usuarios ConvertToDomain(CreateUserCommand command);
        Usuarios ConvertToDomain(UpdateUserCommand command, Usuarios existing);
        ICollection<UserView> ConvertToView(ICollection<Usuarios> domains);
        UserView ConvertToView(Usuarios domains);
    }
}

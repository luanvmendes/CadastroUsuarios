using UsersService.App.ViewModel;

namespace UsersService.App.Application
{
    public interface IUserApplication
    {
        ICollection<UserView> GetAll();
        Task<UserView> GetByIdAsync(int id);
    }
}

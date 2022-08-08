using UsersService.App.Adapter;
using UsersService.App.ViewModel;
using UsersService.Domain.Model;
using UsersService.Infra.UnitOfWork;

namespace UsersService.App.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUsersUnitOfWork _unitOfWork;
        private readonly IUserAdapter _userAdapter;

        public UserApplication(IUsersUnitOfWork unitOfWork, IUserAdapter userAdapter)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userAdapter = userAdapter ?? throw new ArgumentNullException(nameof(userAdapter));
        }

        public ICollection<UserView> GetAll()
        {
            var users = _unitOfWork.Repository<Usuarios>().GetAll();
            return _userAdapter.ConvertToView(users);
        }

        public async Task<UserView> GetByIdAsync(int id)
        {
            var existing = await _unitOfWork.Repository<Usuarios>().GetById(id);
            return _userAdapter.ConvertToView(existing);
        }
    }
}

using MediatR;
using UsersService.App.Adapter;
using UsersService.Domain.Model;
using UsersService.Infra.UnitOfWork;

namespace UsersService.App.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUsersUnitOfWork _unitOfWork;
        private readonly IUserAdapter _userAdapter;

        public CreateUserCommandHandler(IUsersUnitOfWork unitOfWork, IUserAdapter userAdapter)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userAdapter = userAdapter ?? throw new ArgumentNullException(nameof(userAdapter));
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null) return false;

                var domain = _userAdapter.ConvertToDomain(request);

                _unitOfWork.Repository<Usuarios>().Add(domain);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

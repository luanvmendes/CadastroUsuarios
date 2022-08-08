using MediatR;
using UsersService.App.Adapter;
using UsersService.Domain.Model;
using UsersService.Infra.UnitOfWork;

namespace UsersService.App.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUsersUnitOfWork _unitOfWork;
        private readonly IUserAdapter _userAdapter;

        public UpdateUserCommandHandler(IUsersUnitOfWork unitOfWork, IUserAdapter userAdapter)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userAdapter = userAdapter ?? throw new ArgumentNullException(nameof(userAdapter));
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null) return false;

                var existing = await _unitOfWork.Repository<Usuarios>().GetById(request.Id);

                if (existing == null) return false;

                var domain = _userAdapter.ConvertToDomain(request, existing);

                _unitOfWork.Repository<Usuarios>().Update(domain);
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

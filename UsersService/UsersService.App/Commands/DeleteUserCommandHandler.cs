using MediatR;
using UsersService.Domain.Model;
using UsersService.Infra.UnitOfWork;

namespace UsersService.App.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUsersUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUsersUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null) return false;

                var existing = await _unitOfWork.Repository<Usuarios>().GetById(request.Id);

                if (existing == null) return false;

                _unitOfWork.Repository<Usuarios>().Delete(existing);
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

﻿using MediatR;

namespace UsersService.App.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        protected DeleteUserCommand() : base() { }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

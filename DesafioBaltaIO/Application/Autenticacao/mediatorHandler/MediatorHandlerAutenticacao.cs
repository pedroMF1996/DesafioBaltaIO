using DesafioBaltaIO.Application.Autenticacao.Commands.Abstract;
using DesafioBaltaIO.Application.Autenticacao.DTOs;
using MediatR;

namespace DesafioBaltaIO.Application.Autenticacao.mediatorHandler
{
    public interface IMediatorHandlerAutenticacao
    {
        Task<AutenticarUsuarioResponseDTO> SendCommand<T>(T command) where T : Command;
    }
    public class MediatorHandlerAutenticacao : IMediatorHandlerAutenticacao
    {
        private readonly IMediator _mediator;

        public MediatorHandlerAutenticacao(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<AutenticarUsuarioResponseDTO> SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command, default);
        }
    }
}

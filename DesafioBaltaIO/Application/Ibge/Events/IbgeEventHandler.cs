using DesafioBaltaIO.Application.Ibge.Commands;
using DesafioBaltaIO.Domain.IBGE.Interfaces;
using MediatR;
using NetDevPack.Identity.User;
using NetDevPack.Mediator;

namespace DesafioBaltaIO.Application.Ibge.Events
{
    public class IbgeEventHandler : INotificationHandler<LocalidadeCadastradaEvent>,
                                    INotificationHandler<LocalidadeEditadaEvent>
    {
        private readonly ILocalidadeReository _localidadeReository;
        private readonly IAspNetUser _user;
        private readonly IMediatorHandler _mediatorHandler;

        public IbgeEventHandler(ILocalidadeReository localidadeReository, IAspNetUser user, IMediatorHandler mediatorHandler)
        {
            _localidadeReository = localidadeReository;
            _user = user;
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(LocalidadeCadastradaEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                var localidade = _localidadeReository.ObterLocalidadeEmVigencia(notification.LocalidadeId);

                if (localidade == null)
                    throw new ArgumentException("Erro ao cadastrar a localidade");

                var cadastranteId = _user.GetUserId();

                if (!localidade.AssociarCadastrante(cadastranteId, notification.DataCadastro))
                    throw new ArgumentException("Erro ao cadastrar a localidade");

                _localidadeReository.AtualizarLocalidade(localidade);

                await _localidadeReository.UnitOfWork.Commit();
            }
            catch (ArgumentException err)
            {
                await CreateRollBack(err.Message, notification.CodigoLocalidade);
            }
        }

        public async Task Handle(LocalidadeEditadaEvent notification, CancellationToken cancellationToken)
        {
            var localidade = _localidadeReository.ObterLocalidadeEmVigencia(notification.LocalidadeId);

            if (localidade == null)
                return;

            var cadastranteId = _user.GetUserId();

            if (!localidade.AssociarEditor(cadastranteId, notification.DataEdicao))
                return;

            _localidadeReository.AtualizarLocalidade(localidade);

            await _localidadeReository.UnitOfWork.Commit();
        }

        public async Task CreateRollBack(string mensagemErro, string codigoLocalidade)
        {
            var command = new RemoverLocalidadeCommand(codigoLocalidade);
            await _mediatorHandler.SendCommand(command);
            throw new ArgumentException(mensagemErro);
        }
    }
}

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
                var localidade = await _localidadeReository.ObterLocalidadePorCodigoAsync(notification.CodigoLocalidade);

                if (localidade == null)
                    throw new Exception();

                var cadastranteId = _user.GetUserId();

                if (!localidade.AssociarCadastrante(cadastranteId, notification.DataCadastro))
                    throw new Exception();
                                
                _localidadeReository.AtualizarLocalidade(localidade);

                await _localidadeReository.UnitOfWork.Commit();
            }
            catch (InvalidOperationException)
            {
                await CreateRollBack("Erro ao cadastrar a localidade", notification.CodigoLocalidade);
            }
            catch (Exception)
            {
                await CreateRollBack("Erro ao cadastrar a localidade", notification.CodigoLocalidade);
            }
        }

        public async Task Handle(LocalidadeEditadaEvent notification, CancellationToken cancellationToken)
        {
            var localidade = await _localidadeReository.ObterLocalidadePorCodigoAsync(notification.CodigoLocalidade);

            if (localidade == null)
                return;

            var cadastranteId = _user.GetUserId();

            if (!localidade.AssociarEditor(cadastranteId, notification.DataEdicao))
            {
                var command = new RemoverLocalidadeCommand(notification.CodigoLocalidade);
                await _mediatorHandler.SendCommand(command);
            }

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

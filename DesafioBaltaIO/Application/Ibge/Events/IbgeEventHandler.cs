using DesafioBaltaIO.Domain.IBGE.Interfaces;
using MediatR;
using NetDevPack.Identity.User;

namespace DesafioBaltaIO.Application.Ibge.Events
{
    public class IbgeEventHandler : INotificationHandler<LocalidadeCadastradaEvent>
    {
        private readonly ILocalidadeReository _localidadeReository;
        private readonly IAspNetUser _user;

        public IbgeEventHandler(ILocalidadeReository localidadeReository, IAspNetUser user)
        {
            _localidadeReository = localidadeReository;
            _user = user;
        }

        public async Task Handle(LocalidadeCadastradaEvent notification, CancellationToken cancellationToken)
        {
            var localidade = await _localidadeReository.ObterLocalidadePorCodigoAsync(notification.CodigoLocalidade);

            if(localidade == null)
                return;

            var cadastranteId = _user.GetUserId();

            if (!localidade.AssociarCadastrante(cadastranteId))
                return;

            _localidadeReository.AtualizarLocalidade(localidade);

            await _localidadeReository.UnitOfWork.Commit();
        }
    }
}

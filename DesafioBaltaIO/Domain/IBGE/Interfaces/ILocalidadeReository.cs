using DesafioBaltaIO.Domain.IBGE.Models;
using NetDevPack.Data;

namespace DesafioBaltaIO.Domain.IBGE.Interfaces
{
    public interface ILocalidadeReository : IRepository<LocalidadeModel>
    {
        Task CadastrarLocalidadeAsync(LocalidadeModel model);
        Task<LocalidadeModel> ObterLocalidadePorCodigoAsync(string codigo);
        LocalidadeModel ObterLocalidadeEmVigencia(Guid id);
        void AtualizarLocalidade(LocalidadeModel localidade);
        void RemoverLocalidade(LocalidadeModel localidade);
    }
}

using NetDevPack.Data;

namespace DesafioBaltaIO.Domain.Models.IBGE.Interfaces
{
    public interface ILocalidadeReository : IRepository<LocalidadeModel>
    {
        Task CadastrarLocalidadeAsync(LocalidadeModel model);
        Task<IEnumerable<LocalidadeModel>> ObterLocalidadesPorEstadoAsync(string estado);
        Task<LocalidadeModel> ObterLocalidadePorCidadeAsync(string cidade);
        Task<LocalidadeModel> ObterLocalidadePorCodigoAsync(string codigo);
        void AtualizarLocalidade(LocalidadeModel localidade);
        void RemoverLocalidade(LocalidadeModel localidade);
    }
}

using DesafioBaltaIO.Application.Ibge.DTOs;

namespace DesafioBaltaIO.Application.Ibge.Query.Interface
{
    public interface ILocalidadeQueries
    {
        Task<LocalidadeDTO> ObterLocalizacaoPorCodigo(string codigo);
        Task<LocalidadeDTO> ObterLocalizacaoPorCidade(string cidade);
        Task<IEnumerable<LocalidadeDTO>> ObterLocalizacoesPorEstado(string cidade);
    }
}

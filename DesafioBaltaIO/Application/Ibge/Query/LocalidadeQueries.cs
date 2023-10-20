using DesafioBaltaIO.Application.Ibge.DTOs;
using DesafioBaltaIO.Application.Ibge.Query.Interface;
using DesafioBaltaIO.Data.IBGE;
using Microsoft.EntityFrameworkCore;

namespace DesafioBaltaIO.Application.Ibge.Query
{
    public class LocalidadeQueries : ILocalidadeQueries
    {

        private readonly IbgeDbContext _context;

        public LocalidadeQueries(IbgeDbContext context)
        {
            _context = context;
        }

        public async Task<LocalidadeDTO> ObterLocalizacaoPorCidade(string cidade)
        {
            var localidadeModel = await _context.Localidades.AsNoTracking().FirstOrDefaultAsync(x => x.Cidade == cidade);

            if (localidadeModel == null)
                return new();
            

            LocalidadeDTO localidadeDTO = new()
            {
                Codigo = localidadeModel.Codigo,
                Cidade = localidadeModel.Cidade,
                Estado = localidadeModel?.Estado
            };

            return localidadeDTO;
        }

        public async Task<LocalidadeDTO> ObterLocalizacaoPorCodigo(string codigo)
        {
            var localidadeModel = await _context.Localidades.AsNoTracking().FirstOrDefaultAsync(x => x.Codigo == codigo);

            if (localidadeModel == null)
                return new();


            LocalidadeDTO localidadeDTO = new()
            {
                Codigo = localidadeModel.Codigo,
                Cidade = localidadeModel.Cidade,
                Estado = localidadeModel?.Estado
            };

            return localidadeDTO;
        }

        public async Task<IEnumerable<LocalidadeDTO>> ObterLocalizacoesPorEstado(string estado)
        {
            List<LocalidadeDTO> localidadeDTOs = new();
            var localidades = await _context.Localidades.AsNoTracking()
                                                        .Where(x => x.Estado == estado)
                                                        .ToListAsync();
            if (localidades.Count == 0)
                return localidadeDTOs;

            localidades.ForEach(localidadeModel =>
            {
                localidadeDTOs.Add(new(){
                                            Codigo = localidadeModel.Codigo,
                                            Cidade = localidadeModel.Cidade,
                                            Estado = localidadeModel?.Estado
                                        });
            });

            return localidadeDTOs;
        }
    }
}

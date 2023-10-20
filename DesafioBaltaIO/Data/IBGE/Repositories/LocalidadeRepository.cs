using DesafioBaltaIO.Domain.IBGE.Interfaces;
using DesafioBaltaIO.Domain.IBGE.Models;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace DesafioBaltaIO.Data.IBGE.Repositories
{
    public class LocalidadeRepository : ILocalidadeReository
    {

        private readonly IbgeDbContext _dbContext;

        public LocalidadeRepository(IbgeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void AtualizarLocalidade(LocalidadeModel localidade)
        {
            _dbContext.Localidades.Update(localidade);
        }

        public async Task CadastrarLocalidadeAsync(LocalidadeModel localidade)
        {
            await _dbContext.Localidades.AddAsync(localidade);
        }

        public async Task<LocalidadeModel> ObterLocalidadePorCidadeAsync(string cidade)
        {
            return await _dbContext.Localidades.AsNoTracking().FirstOrDefaultAsync(x => x.Cidade == cidade);
        }

        public async Task<LocalidadeModel> ObterLocalidadePorCodigoAsync(string codigo)
        {
            return await _dbContext.Localidades.AsNoTracking().FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        public async Task<IEnumerable<LocalidadeModel>> ObterLocalidadesPorEstadoAsync(string estado)
        {
            return await _dbContext.Localidades.AsNoTracking().Where(x => x.Estado ==  estado).ToListAsync();
        }

        public void RemoverLocalidade(LocalidadeModel localidade)
        {
            _dbContext.Localidades.Remove(localidade);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}

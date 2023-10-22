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
            _dbContext.Entry(localidade).State = EntityState.Detached;
            _dbContext.Localidades.Update(localidade);
            _dbContext.Entry(localidade).State = EntityState.Modified;
        }

        public async Task CadastrarLocalidadeAsync(LocalidadeModel localidade)
        {
            await _dbContext.Localidades.AddAsync(localidade);
        }

        public async Task<LocalidadeModel> ObterLocalidadePorCodigoAsync(string codigo)
        {
            return await _dbContext.Localidades.AsNoTracking().FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        public void RemoverLocalidade(LocalidadeModel localidade)
        {
            _dbContext.Localidades.Remove(localidade);
        }

        public LocalidadeModel ObterLocalidadeEmVigencia(Guid id)
        {
            return _dbContext.ChangeTracker.Entries<LocalidadeModel>().SingleOrDefault(e => e.Entity.Id == id).Entity;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}

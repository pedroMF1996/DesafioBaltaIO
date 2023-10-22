using DesafioBaltaIO.Domain.IBGE.Models;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Domain;
using NetDevPack.Mediator;
using NetDevPack.Messaging;

namespace DesafioBaltaIO.Data.IBGE
{
    public class IbgeDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediator;

        public IbgeDbContext(DbContextOptions<IbgeDbContext> options, IMediatorHandler mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<LocalidadeModel> Localidades { get; set; }

        public async Task<bool> Commit()
        {
            var sucesso = await SaveChangesAsync() > 0;

            if (sucesso)
                await _mediator.PublicarEventos(this);

            return sucesso;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IbgeDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }

    #region Mediator_Extensions
    public static class MediatorExtension
    {
        public static async Task PublicarEventos<T>(this IMediatorHandler mediatorHandler, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(e =>
                {
                    e.Entity.ClearDomainEvents();
                });

            var task = domainEvents.
                Select(async domainEvent =>
                {
                    await mediatorHandler.PublishEvent(domainEvent);
                });

            await Task.WhenAll(task);
        }
    } 
    #endregion
}

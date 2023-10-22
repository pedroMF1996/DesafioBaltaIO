using DesafioBaltaIO.Application.Autenticacao.Commands;
using DesafioBaltaIO.Application.Autenticacao.DTOs;
using DesafioBaltaIO.Application.Autenticacao.mediatorHandler;
using DesafioBaltaIO.Application.Ibge.Commands;
using DesafioBaltaIO.Application.Ibge.Events;
using DesafioBaltaIO.Application.Ibge.Query;
using DesafioBaltaIO.Application.Ibge.Query.Interface;
using DesafioBaltaIO.Data.Atenticacao;
using DesafioBaltaIO.Data.IBGE;
using DesafioBaltaIO.Data.IBGE.Repositories;
using DesafioBaltaIO.Domain.IBGE.Interfaces;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Identity.User;
using NetDevPack.Mediator;

namespace DesafioBaltaIO.Configurations
{
    public static class RegisterServiceConfiguration
    {
        public static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            #region API

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IMediatorHandlerAutenticacao, MediatorHandlerAutenticacao>();

            #endregion

            #region Events

            services.AddScoped<INotificationHandler<LocalidadeCadastradaEvent>, IbgeEventHandler>();
            services.AddScoped<INotificationHandler<LocalidadeEditadaEvent>, IbgeEventHandler>();

            #endregion

            #region Commands

            services.AddScoped<IRequestHandler<CadastrarLocalidadeCommand, ValidationResult>, IbgeCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarCodigoLocalidadeCommand, ValidationResult>, IbgeCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarEstadoLocalidadeCommand, ValidationResult>, IbgeCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarCidadeLocalidadeCommand, ValidationResult>, IbgeCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverLocalidadeCommand, ValidationResult>, IbgeCommandHandler>();

            services.AddScoped<IRequestHandler<RegistrarUsuarioCommand, AutenticarUsuarioResponseDTO>, AutenticacaoCommandHandler>();
            services.AddScoped<IRequestHandler<AutenticarUsuarioCommand, AutenticarUsuarioResponseDTO>, AutenticacaoCommandHandler>();

            #endregion

            #region Queries

            services.AddScoped<ILocalidadeQueries, LocalidadeQueries>();

            #endregion

            #region Datas

            services.AddScoped<IbgeDbContext>();
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<ILocalidadeReository, LocalidadeRepository>();

            #endregion
            return services;
        }
    }
}
